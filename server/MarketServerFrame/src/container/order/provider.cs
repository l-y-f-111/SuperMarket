namespace SuperMarket.Container.Order.Provider;

using Entity;
using Goods.Entity;
using User.Entity;

//resolver : LYF
//asm file : OrderContainerImpl
//impl :: SuperMarket.Container.Order.Provider.OrderProvider
//impl proj struct :
//src/container/provider.cs
public interface IOrderProvider
{
    public IOrderEntity? CreateOrder
    (
        IUserEntity user,
        double payAmount,
        IGoodsEntity goods
    );

    public IOrderEntity? GetOrder(long id);
    public List<IOrderEntity> GetAllOrder();
    public List<IOrderEntity> FilterOrderByGoods(IGoodsEntity goods);
    public List<IOrderEntity> FilterOrderByGoodsTypes(List<string> goodsTypes);
}