using SuperMarket.Container.Order.Provider;
using AlipayF2F;

namespace SuperMarket.Server.Api.Order;

using WebSocketSharp;
using WebSocketSharp.Server;
using MarketServerUtil;

public struct GetAllOrderReq
{
}

public struct OrderRsp
{
    public long OrderId;
    public long OrderUserId;
    public long OrderGoodsId;
    public long OrderCinemaId;
    public long OrderScheduleId;
    public DateTime OrderTime;
    public string OrderSeat;
    public double OrderPayAmount;
    public string OrderStatus;
}

public struct GetAllOrderRsp
{
    public List<OrderRsp> Collection;
}

//api : get_all_order
public class GetAllOrder : WebSocketBehavior
{
    private IOrderProvider _orderProvider;
    private F2FClient _f2fClient;

    public void Set(IOrderProvider orderProvider, F2FClient f2fClient)
    {
        _orderProvider = orderProvider;
        _f2fClient = f2fClient;
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        Console.WriteLine($"get_all_order req:\n{e.Data}");

        var req = JsonHelper.Parse<GetAllOrderReq>(e.Data);
        var orders = _orderProvider.GetAllOrder();

        var orderRspList = new List<OrderRsp>();

        foreach (var order in orders)
        {
            if (order.Status == "created")
            {
                var f2fReq = F2FRequest.QueryTrade(order.Id.ToString());
                var f2fRsp = _f2fClient.ExecuteRequest(f2fReq);
                var isSuccess = F2FResponse.IsTradeSuccess(f2fRsp);
                if (isSuccess)
                {
                    order.Status = "paid";
                }
            }

            var orderRsp = new OrderRsp
            {
                OrderId = order.Id,
                OrderUserId = order.User.Id,
                OrderGoodsId = order.Goods.Id,
                OrderPayAmount = order.PayAmount,
                OrderStatus = order.Status,
                OrderTime = order.Time.Value
            };
            orderRspList.Add(orderRsp);
        }

        var rsp = new GetAllOrderRsp
        {
            Collection = orderRspList
        };

        var json = JsonHelper.Stringify(rsp);
        Console.WriteLine($"get_all_order rsp:\n{json}");
        Send(json);
    }
}