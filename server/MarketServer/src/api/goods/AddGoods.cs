
namespace SuperMarket.Server.Api.Goods;

using Container.Goods.Provider;
using WebSocketSharp;
using WebSocketSharp.Server;
using MarketServerUtil;

public struct AddGoodsReq
{
    public string GoodsName;
    public string GoodsCoverImg;
    public string GoodsPreviewVideoUrl;
    public double GoodsPrice;
    public bool GoodsIsReady;
    public List<string> GoodsTypes;
    public long GoodsStock;
}

public struct AddGoodsRsp
{
    public bool Ok;
    public long GoodsId;
}

//api : add_goods
public class AddGoods : WebSocketBehavior
{
    private IGoodsProvider _goodsProvider;

    public void Set(IGoodsProvider GoodsProvider)
    {
        _goodsProvider = GoodsProvider;
    }

    protected override void OnMessage(MessageEventArgs e)
    {
        Console.WriteLine($"add_goods req:\n{e.Data}");

        var req = JsonHelper.Parse<AddGoodsReq>(e.Data);

        var Goods = _goodsProvider.CreateGoods
        (
            req.GoodsName,
            req.GoodsIsReady,
            req.GoodsPrice
        );

        AddGoodsRsp rsp;

        if (Goods != null)
        {
            Goods.CoverImg = req.GoodsCoverImg;
            Goods.PreviewVideoUrl = req.GoodsPreviewVideoUrl;

            foreach (var type in req.GoodsTypes)
                Goods.AddType(type);


            rsp = new AddGoodsRsp
            {
                Ok = true,
                GoodsId = Goods.Id
            };
        }
        else
        {
            rsp = new AddGoodsRsp
            {
                Ok = false,
                GoodsId = 0
            };
        }

        var json = JsonHelper.Stringify(rsp);
        Console.WriteLine($"add_goods rsp:\n{json}");
        Send(json);
    }
}