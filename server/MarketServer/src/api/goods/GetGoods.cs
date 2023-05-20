namespace SuperMarket.Server.Api.Goods;

using Container.Goods.Provider;
using WebSocketSharp;
using WebSocketSharp.Server;
using MarketServerUtil;

public struct GetGoodsReq
{
    public long GoodsId;
}

public struct GetGoodsRsp
{
    public bool Ok;
    public string GoodsName;
    public string GoodsCoverImg;
    public string GoodsPreviewVideoUrl;
    public double GoodsPrice;
    public bool GoodsIsReady;
    public List<string> GoodsTypes;
    public long GoodsStock;
}

//api : get_goods
public class GetGoods : WebSocketBehavior
{
    private IGoodsProvider _goodsProvider;

    public void Set(IGoodsProvider GoodsProvider)
    {
        _goodsProvider = GoodsProvider;
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        Console.WriteLine($"get_goods req:\n{e.Data}");

        var req = JsonHelper.Parse<GetGoodsReq>(e.Data);
        var Goods = _goodsProvider.GetGoods(req.GoodsId);

        GetGoodsRsp rsp;

        if (Goods != null)
        {
            rsp = new GetGoodsRsp
            {
                Ok = true,
                GoodsName = Goods.Name,
                GoodsCoverImg = Goods.CoverImg,
                GoodsPreviewVideoUrl = Goods.PreviewVideoUrl,
                GoodsPrice = Goods.Price,
                GoodsIsReady = Goods.IsReady,
                GoodsTypes = Goods.Types,
            };
        }
        else
        {
            rsp = new GetGoodsRsp
            {
                Ok = false,
                GoodsName = "",
                GoodsCoverImg = "",
                GoodsPreviewVideoUrl = "",
                GoodsPrice = -1,
                GoodsIsReady = false
            };
        }

        var json = JsonHelper.Stringify(rsp);
        Console.WriteLine($"get_goods rsp:\n{json}");
        Send(json);
    }
}