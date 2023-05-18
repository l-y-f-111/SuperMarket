namespace SuperMarket.Db.Order.Model;

//resolver : LYF
//asm file : OrderDbImpl
//impl :: SuperMarket.Db.Order.Model.OrderModel
//impl proj struct :
//src/db/model.cs
public interface IOrderModel
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public double PayAmount { get; set; }
    public DateTime Time { get; set; }
    public long GoodsId { get; set; }
    public string Status { get; set; }
}