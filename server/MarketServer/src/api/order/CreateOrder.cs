
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

public struct CreateOrderReq
{
    public long OrderGoodsId;
    public long OrderUserId;
    public long OrderCinemaId;
    public long OrderScheduleId;
    public string OrderSeat;
    public double OrderPayAmount;
}

public struct CreateOrderRsp
{
    public bool Ok;
    public long OrderId;
    public string AlipayQrCodePath;
}

//api : create_order
public class CreateOrder : WebSocketBehavior
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
        Console.WriteLine($"create_order req:\n{e.Data}");

        var req = JsonHelper.Parse<CreateOrderReq>(e.Data);
        var user = _userProvider.GetUser(req.OrderUserId);
        var Goods = _goodsProvider.GetGoods(req.OrderGoodsId);

        CreateOrderRsp rsp;

        if (user != null && Goods != null)
        {
            var order = _orderProvider.CreateOrder
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

                rsp = new CreateOrderRsp
                {
                    Ok = true,
                    OrderId = order.Id,
                    AlipayQrCodePath = f2fRsp.QrCode
                };
            }
            else
            {
                rsp = new CreateOrderRsp
                {
                    Ok = false,
                    OrderId = 0,
                    AlipayQrCodePath = ""
                };
            }
        }
        else
        {
            rsp = new CreateOrderRsp
            {
                Ok = false,
                OrderId = 0,
                AlipayQrCodePath = ""
            };
        }

        var json = JsonHelper.Stringify(rsp);
        Console.WriteLine($"create_order rsp:\n{json}");
        Send(json);
    }
}