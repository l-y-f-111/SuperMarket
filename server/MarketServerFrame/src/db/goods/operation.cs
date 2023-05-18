namespace SuperMovie.Db.Goods.Operation;

using Model;

//resolver : ZTY
//asm file : GoodsDbImpl
//impl :: SuperMovie.Db.Goods.Operation.GoodsOperation
//impl proj struct :
//src/db/operation.cs
public interface IGoodsOperation
{
    public bool CreateGoods(IGoodsModel model);
    public bool DeleteGoods(long filmId);
    public IGoodsModel? GetGoods(long filmId);
    public List<IGoodsModel> GetAllGoods();
    public List<IGoodsModel> FilterGoodsByIsPreorder(bool isPreorder);
    public List<IGoodsModel> FilterGoodsByTypes(List<string> types);
    public List<IGoodsModel> FilterGoodsByName(string name);
    public List<IGoodsModel> MatchGoodsByName(string name);
    public bool UpdateGoodsName(long filmId, string newValue);
    public bool UpdateGoodsIsPreorder(long filmId, bool newValue);
    public bool UpdateGoodsTypes(long filmId, List<string> newValue);
    public bool UpdateGoodsPrice(long filmId, double newValue);
    public bool UpdateGoodsCoverImg(long filmId, string newValue);
    public bool UpdateGoodsPreviewVideoUrl(long filmId, string newValue);
}