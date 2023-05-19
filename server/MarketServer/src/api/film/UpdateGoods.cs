namespace SuperMarket.Server.Api.Goods;

using Container.Goods.Provider;
using WebSocketSharp;
using WebSocketSharp.Server;
using MarketServerUtil;

public struct UpdateGoodsReq
{
    public long GoodsId;
    public string GoodsName;
    public string GoodsCoverImg;
    public string GoodsPreviewVideoUrl;
    public double GoodsPrice;
    public bool GoodsIsPreorder;
    public DateTime GoodsOnlineTime;
    public List<string> GoodsTypes;
    public List<string> GoodsActors;
}

public struct UpdateGoodsRsp
{
    public bool Ok;
}

//api : update_goods
public class UpdateGoods : WebSocketBehavior
{
    private IGoodsProvider _goodsProvider;

    public void Set(IGoodsProvider GoodsProvider)
    {
        _goodsProvider = GoodsProvider;
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        Console.WriteLine($"update_goods req:\n{e.Data}");

        var req = JsonHelper.Parse<UpdateGoodsReq>(e.Data);
        var Goods = _goodsProvider.GetGoods(req.GoodsId);

        UpdateGoodsRsp rsp;

        if (Goods != null)
        {
            Goods.Name = req.GoodsName;
            Goods.CoverImg = req.GoodsCoverImg;
            Goods.PreviewVideoUrl = req.GoodsPreviewVideoUrl;
            Goods.Price = req.GoodsPrice;
            Goods.IsPreorder = req.GoodsIsPreorder;

            Goods.ClearType();
            foreach (var type in req.GoodsTypes)
                Goods.AddType(type);
            
            rsp = new UpdateGoodsRsp
            {
                Ok = true
            };
        }
        else
        {
            rsp = new UpdateGoodsRsp
            {
                Ok = false
            };
        }

        var json = JsonHelper.Stringify(rsp);
        Console.WriteLine($"update_goods rsp:\n{json}");
        Send(json);
    }
}