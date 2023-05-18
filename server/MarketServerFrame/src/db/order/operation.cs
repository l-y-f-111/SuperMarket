namespace SuperMovie.Db.Order.Operation;

using Model;

//resolver : LYF
//asm file : OrderDbImpl
//impl :: SuperMovie.Db.Order.Operation.OrderOperation
//impl proj struct :
//src/db/operation.cs
public interface IOrderOperation
{
    public bool CreateOrder(IOrderModel model);
    public bool DeleteOrder(long orderId);
    public IOrderModel? GetOrder(long orderId);
    public List<IOrderModel> GetAllOrder();
    public List<IOrderModel> FilterOrderByUserId(long userId);
    public List<IOrderModel> FilterOrderByGoodsId(long filmId);
    public List<IOrderModel> FilterOrderByGoodsTypes(List<string> filmTypes);
    public bool IsOrderIdValid(long orderId);
    public bool UpdateOrderUserId(long orderId, long newValue);
    public bool UpdateOrderPayAmount(long orderId, double newValue);
    public bool UpdateOrderTime(long orderId, DateTime newValue);
    public bool UpdateOrderGoodsId(long orderId, long newValue);
    public bool UpdateOrderStatus(long orderId, string newValue);
}