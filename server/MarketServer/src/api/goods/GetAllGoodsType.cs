namespace SuperMarket.Server.Api.Goods;

using Container.Goods.Provider;
using WebSocketSharp;
using WebSocketSharp.Server;
using MarketServerUtil;

public struct GetAllGoodsTypeReq
{
}

public struct GetAllGoodsTypeRsp
{
    public List<string> Collection;
}

//api : get_all_goods_type
public class GetAllGoodsType : WebSocketBehavior
{
    private IGoodsProvider _goodsProvider;

    public void Set(IGoodsProvider GoodsProvider)
    {
        _goodsProvider = GoodsProvider;
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        Console.WriteLine($"get_all_goods_type req:\n{e.Data}");

        var req = JsonHelper.Parse<GetAllGoodsTypeReq>(e.Data);
        var typeList = _goodsProvider.GetAllGoodsType();

        var rsp = new GetAllGoodsTypeRsp
        {
            Collection = typeList
        };

        var json = JsonHelper.Stringify(rsp);
        Console.WriteLine($"get_all_goods_type rsp:\n{json}");
        Send(json);
    }
}