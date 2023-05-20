using SuperMarket.Container.Goods.Entity;

namespace SuperMarket.Server.Api.Goods;

using Container.Goods.Provider;
using WebSocketSharp;
using WebSocketSharp.Server;
using MarketServerUtil;

public struct SearchGoodsReq
{
    public bool EnableScheduleSearch;
    public List<string> GoodsTypes;
    public string GoodsNameKeyWord;
}

public struct SearchGoodsRsp
{
    public List<GoodsRsp> Collection;
}

//api : search_goods
public class SearchGoods : WebSocketBehavior
{
    private IGoodsProvider _goodsProvider;

    public void Set(IGoodsProvider GoodsProvider)
    {
        _goodsProvider = GoodsProvider;
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        Console.WriteLine($"search_goods req:\n{e.Data}");

        var req = JsonHelper.Parse<SearchGoodsReq>(e.Data);
        var filterByGoodsName = _goodsProvider
            .MatchGoodsByName(req.GoodsNameKeyWord);
        var filterByGoodsTypes = _goodsProvider
            .FilterGoodsByTypes(req.GoodsTypes);
        var filterByScheduleTimeF = () =>
        {
            var Goodss = new List<IGoodsEntity>();

            return Goodss;
        };
        var filterByScheduleTime = filterByScheduleTimeF();

        var GoodssUnion = new List<IGoodsEntity>();
        GoodssUnion.AddRange(filterByGoodsName);
        GoodssUnion.AddRange(filterByGoodsTypes);
        if (req.EnableScheduleSearch)
            GoodssUnion.AddRange(filterByScheduleTime);
        Console.WriteLine(JsonHelper.Stringify(GoodssUnion));
        var GoodssIntersection = new List<IGoodsEntity>();
        foreach (var Goods in GoodssUnion.DistinctBy(x => x.Id))
        {
            if (filterByGoodsName.Exists(x => x.Id == Goods.Id) &&
                filterByGoodsTypes.Exists(x => x.Id == Goods.Id)
               )
            {
                if (req.EnableScheduleSearch)
                {
                    if (filterByScheduleTime.Exists(x => x.Id == Goods.Id))
                        GoodssIntersection.Add(Goods);
                }
                else
                {
                    GoodssIntersection.Add(Goods);
                }
            }
        }

        var GoodsRspList = new List<GoodsRsp>();

        foreach (var Goods in GoodssIntersection.DistinctBy(x => x.Id))
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
            };

            GoodsRspList.Add(GoodsRsp);
        }

        var rsp = new SearchGoodsRsp
        {
            Collection = GoodsRspList
        };

        var json = JsonHelper.Stringify(rsp);
        Console.WriteLine($"search_goods rsp:\n{json}");
        Send(json);
    }
}