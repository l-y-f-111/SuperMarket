using SuperMarket.Container.Order.Provider;

namespace SuperMarket.Server.Api.Order;

using WebSocketSharp;
using WebSocketSharp.Server;
using MarketServerUtil;

public struct IsOrderIdValidReq
{
    public long OrderId;
}

public struct IsOrderIdValidRsp
{
    public bool Ok;
}

//api : is_order_id_valid
public class IsOrderIdValid : WebSocketBehavior
{
    private IOrderProvider _orderProvider;

    public void Set(IOrderProvider orderProvider)
    {
        _orderProvider = orderProvider;
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        Console.WriteLine($"is_order_valid req:\n{e.Data}");

        var req = JsonHelper.Parse<IsOrderIdValidReq>(e.Data);
        var order = _orderProvider.GetOrder(req.OrderId);
        var rsp = new IsOrderIdValidRsp
        {
            Ok = order != null
        };

        var json = JsonHelper.Stringify(rsp);
        Console.WriteLine($"is_order_valid rsp:\n{json}");
        Send(json);
    }
}