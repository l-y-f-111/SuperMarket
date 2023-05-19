namespace SuperMarket.Server.Api.Goods;

using Container.Goods.Provider;
using WebSocketSharp;
using WebSocketSharp.Server;
using MarketServerUtil;

public struct DeleteGoodsReq
{
    public long GoodsId;
}

public struct DeleteGoodsRsp
{
    public bool Ok;
}

//api : delete_goods
public class DeleteGoods : WebSocketBehavior
{
    private IGoodsProvider _goodsProvider;

    public void Set(IGoodsProvider GoodsProvider)
    {
        _goodsProvider = GoodsProvider;
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        Console.WriteLine($"delete_goods req:\n{e.Data}");

        var req = JsonHelper.Parse<DeleteGoodsReq>(e.Data);
        var Goods = _goodsProvider.GetGoods(req.GoodsId);

        DeleteGoodsRsp rsp;

        if (Goods != null && Goods.Drop())
        {
            rsp = new DeleteGoodsRsp
            {
                Ok = true
            };
        }
        else
        {
            rsp = new DeleteGoodsRsp
            {
                Ok = false
            };
        }

        var json = JsonHelper.Stringify(rsp);
        Console.WriteLine($"delete_goods rsp:\n{json}");
        Send(json);
    }
}