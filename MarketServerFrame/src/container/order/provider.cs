namespace SuperMovie.Container.Order.Provider;

using Entity;
using Goods.Entity;
using User.Entity;

//resolver : LYF
//asm file : OrderContainerImpl
//impl :: SuperMovie.Container.Order.Provider.OrderProvider
//impl proj struct :
//src/container/provider.cs
public interface IOrderProvider
{
    public IOrderEntity? CreateOrder
    (
        IUserEntity user,
        double payAmount,
        IGoodsEntity film,
        string seat
    );

    public IOrderEntity? GetOrder(long id);
    public List<IOrderEntity> GetAllOrder();
    public List<IOrderEntity> FilterOrderByGoods(IGoodsEntity film);
    public List<IOrderEntity> FilterOrderByGoodsTypes(List<string> filmTypes);

    public List<(string filmActor, double boxOffice)> GetReleasedGoodsActorBor();
    public List<(string filmName, double boxOffice)> GetReleasedGoodsNameBor();
    public List<(string filmType, double boxOffice)> GetReleasedGoodsTypeBor();
}