
using SuperMarket.Container.Goods.Provider;
using SuperMarket.Container.Order.Provider;
using SuperMarket.Container.User.Provider;
using Aop.Api;
using AlipayF2F;
using Aop.Api.Request;
using Aop.Api.Response;
using Aop.Api.Domain;

namespace SuperMarket.Server.Api.Order;

using WebSocketSharp;
using WebSocketSharp.Server;
using MarketServerUtil;

public struct AddOrderReq
{
    public long OrderGoodsId;
    public long OrderUserId;
    public double OrderPayAmount;
}

public struct AddOrderRsp
{
    public bool Ok;
    public long OrderId;
    public string AlipayQrCodePath;
}

//api : add_order
public class AddOrder : WebSocketBehavior
{
    private IUserProvider _userProvider;
    private IGoodsProvider _goodsProvider;
    private IOrderProvider _orderProvider;
    private F2FClient _f2fClient;

    public void Set(
        IUserProvider userProvider,
        IGoodsProvider GoodsProvider,
        IOrderProvider orderProvider,
        F2FClient f2fCLient
    )
    {
        _userProvider = userProvider;
        _goodsProvider = GoodsProvider;
        _orderProvider = orderProvider;
        _f2fClient = f2fCLient;
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        Console.WriteLine($"add_order req:\n{e.Data}");

        var req = JsonHelper.Parse<AddOrderReq>(e.Data);
        var user = _userProvider.GetUser(req.OrderUserId);
        var Goods = _goodsProvider.GetGoods(req.OrderGoodsId);

        AddOrderRsp rsp;

        if (user != null && Goods != null)
        {
            var order = _orderProvider.AddOrder
            (
                user,
                req.OrderPayAmount,
                Goods
            );

            if (order != null)
            {
                //var orderMsg = $@"超级电影购票: {Goods.Name}";
                //订单号: {order.Id}影厅: {cinema.Name}座位: {order.Seat}";
                //场次: {order.Schedule.StartTime} to {order.Schedule.EndTime}";

                var f2fReq = F2FRequest.PreCreateTrade(
                    order.Id.ToString(),
                    "超级电影购票",
                    req.OrderPayAmount
                );
                var f2fRsp = _f2fClient.ExecuteRequest(f2fReq);

                rsp = new AddOrderRsp
                {
                    Ok = true,
                    OrderId = order.Id,
                    AlipayQrCodePath = f2fRsp.QrCode
                };
            }
            else
            {
                rsp = new AddOrderRsp
                {
                    Ok = false,
                    OrderId = 0,
                    AlipayQrCodePath = ""
                };
            }
        }
        else
        {
            rsp = new AddOrderRsp
            {
                Ok = false,
                OrderId = 0,
                AlipayQrCodePath = ""
            };
        }

        var json = JsonHelper.Stringify(rsp);
        Console.WriteLine($"add_order rsp:\n{json}");
        Send(json);
    }
}