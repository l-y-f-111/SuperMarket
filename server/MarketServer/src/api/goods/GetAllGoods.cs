namespace SuperMarket.Server.Api.Goods;

using Container.Goods.Provider;
using WebSocketSharp;
using WebSocketSharp.Server;
using MarketServerUtil;

public struct GetAllGoodsReq
{
}

public struct GoodsRsp
{
    public long GoodsId;
    public string GoodsName;
    public string GoodsCoverImg;
    public string GoodsPreviewVideoUrl;
    public double GoodsPrice;
    public bool GoodsIsReady;
    public List<string> GoodsTypes;
    public long GoodsStock;
}

public struct GetAllGoodsRsp
{
    public List<GoodsRsp> Collection;
}

//api : get_all_goods
public class GetAllGoods : WebSocketBehavior
{
    private IGoodsProvider _goodsProvider;

    public void Set(IGoodsProvider GoodsProvider)
    {
        _goodsProvider = GoodsProvider;
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        Console.WriteLine($"get_all_goods req:\n{e.Data}");

        var req = JsonHelper.Parse<GetAllGoodsReq>(e.Data);
        var Goodss = _goodsProvider.GetAllGoods();

        var GoodsRspList = new List<GoodsRsp>();

        foreach (var Goods in Goodss)
        {
            var GoodsRsp = new GoodsRsp
            {
                GoodsId = Goods.Id,
                GoodsName = Goods.Name,
                GoodsCoverImg = Goods.CoverImg,
                GoodsPreviewVideoUrl = Goods.PreviewVideoUrl,
                GoodsPrice = Goods.Price,
                GoodsIsReady = Goods.IsReady,
                GoodsTypes = Goods.Types,
                GoodsStock = Goods.Stock,
            };
            GoodsRspList.Add(GoodsRsp);
        }

        var rsp = new GetAllGoodsRsp
        {
            Collection = GoodsRspList
        };

        var json = JsonHelper.Stringify(rsp);
        Console.WriteLine($"get_all_goods rsp:\n{json}");
        Send(json);
    }
}