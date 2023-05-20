namespace SuperMarket.Container.Goods.Provider;

using Entity;

//resolver : ZTY
//asm file : GoodsContainerImpl
//impl :: SuperMarket.Container.Goods.Provider.GoodsProvider
//impl proj struct :
//src/container/provider.cs
public interface IGoodsProvider
{
    public IGoodsEntity? CreateGoods
    (
        string name,
        bool isReady,
        double price
    );

    public IGoodsEntity? GetGoods(long id);
    public List<IGoodsEntity> GetAllGoods();

    public List<string> GetAllGoodsType();
    public List<IGoodsEntity> FilterGoodsByIsReady(bool isReady);
    public List<IGoodsEntity> FilterGoodsByTypes(List<string> types);
    public List<IGoodsEntity> FilterGoodsByName(string name);
    public List<IGoodsEntity> MatchGoodsByName(string name);
}