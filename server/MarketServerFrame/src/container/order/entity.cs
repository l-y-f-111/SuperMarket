namespace SuperMovie.Container.Order.Entity;

using User.Entity;
using Goods.Entity;

//resolver : LYF
//asm file : OrderContainerImpl
//impl :: SuperMovie.Container.Order.Entity.OrderEntity
//impl proj struct :
//src/container/entity.cs
public interface IOrderEntity
{
    /// <summary>
    /// 释放实体
    /// </summary>
    /// <returns></returns>
    public bool Drop();

    /// <summary>
    /// 实体是否合法
    /// </summary>
    /// <returns></returns>
    public bool IsValid();

    public long Id { get; }
    public IUserEntity? User { get; set; }
    public double PayAmount { get; set; }
    public DateTime? Time { get; set; }
    public IGoodsEntity? Goods { get; set; }

    //created:表示订单刚被创建，等待支付
    //paid:表示订单已经被支付，没有被退款
    //refunded:表示订单已被支付，但被退款
    public string? Status { get; set; }
}