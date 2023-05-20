namespace SuperMarket.Db.Goods.Operation;

using Model;

//resolver : ZTY
//asm file : GoodsDbImpl
//impl :: SuperMarket.Db.Goods.Operation.GoodsOperation
//impl proj struct :
//src/db/operation.cs
public interface IGoodsOperation
{
    public bool CreateGoods(IGoodsModel model);
    public bool DeleteGoods(long goodsId);
    public IGoodsModel? GetGoods(long goodsId);
    public List<IGoodsModel> GetAllGoods();
    public List<IGoodsModel> FilterGoodsByIsReady(bool isReady);
    public List<IGoodsModel> FilterGoodsByTypes(List<string> types);
    public List<IGoodsModel> FilterGoodsByName(string name);
    public List<IGoodsModel> MatchGoodsByName(string name);
    public bool UpdateGoodsName(long goodsId, string newValue);
    public bool UpdateGoodsIsReady(long goodsId, bool newValue);
    public bool UpdateGoodsTypes(long goodsId, List<string> newValue);
    public bool UpdateGoodsPrice(long goodsId, double newValue);
    public bool UpdateGoodsCoverImg(long goodsId, string newValue);
    public bool UpdateGoodsPreviewVideoUrl(long goodsId, string newValue);
    public bool UpdateGoodsStock(long goodsId, long newValue);
}