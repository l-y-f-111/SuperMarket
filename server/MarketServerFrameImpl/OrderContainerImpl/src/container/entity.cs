// Decompiled with JetBrains decompiler
// Type: SuperMarket.Container.Order.Entity.OrderEntity
// Assembly: OrderContainerImpl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6892D3A6-3714-4FB0-9364-31019630CFFE
// Assembly location: /home/thaumy/data/dev/repo/SuperMarketSDK/_build/OrderContainerImpl.dll

using DbMiddleware;
using SuperMarket.Container.Goods.Entity;
using SuperMarket.Container.Goods.Provider;
using SuperMarket.Container.User.Entity;
using SuperMarket.Container.User.Provider;
using SuperMarket.Db.Goods.Operation;
using SuperMarket.Db.Order.Operation;
using System;


#nullable enable
namespace SuperMarket.Container.Order.Entity
{
    public class OrderEntity : IOrderEntity
    {
        public IDatabase Db;
        public long id;
        public Func<IUserProvider> userProviderF;
        public IGoodsProvider goodsProvider;

        internal OrderEntity(
            long id,
            double payAmount,
            DateTime time,
            Func<IUserProvider> userProviderF,
            IGoodsProvider goodsProvider,
            IDatabase db)
        {
            this.userProviderF = userProviderF;
            this.goodsProvider = goodsProvider;
            this.id = id;
            this.Db = db;
        }

        public bool Drop() =>
            new OrderOperation(this.Db, (IGoodsOperation)new GoodsOperation(this.Db)).DeleteOrder(this.id);

        public long Id => this.id;

        public IUserEntity? User
        {
            get
            {
                object id = this.Db.QueryForFirstValue(
                    "SELECT order_user_id FROM  public.order WHERE order_id = :order_id",
                    new (string, object)[1]
                    {
                        ("order_id", (object)this.id)
                    });
                return id == null ? (IUserEntity)null : this.userProviderF().GetUser((long)id) ?? (IUserEntity)null;
            }
            set
            {
                if (value == null)
                    return;
                new OrderOperation(this.Db, (IGoodsOperation)new GoodsOperation(this.Db)).UpdateOrderUserId(this.id,
                    value.Id);
            }
        }

        public double PayAmount
        {
            get
            {
                object obj = this.Db.QueryForFirstValue(
                    "SELECT order_pay_amount FROM public.order WHERE order_id = :id",
                    new (string, object)[1]
                    {
                        ("id", (object)this.id)
                    });
                return obj == null ? -1.0 : (double)obj;
            }
            set
            {
                if (value < 0.0)
                    return;
                new OrderOperation(this.Db, (IGoodsOperation)new GoodsOperation(this.Db)).UpdateOrderPayAmount(this.id,
                    value);
            }
        }

        public IGoodsEntity? Goods
        {
            get
            {
                object id = this.Db.QueryForFirstValue(
                    "SELECT order_goods_id FROM  public.order WHERE order_id = :order_id",
                    new (string, object)[1]
                    {
                        ("order_id", (object)this.id)
                    });
                return id == null ? (IGoodsEntity)null : this.goodsProvider.GetGoods((long)id) ?? (IGoodsEntity)null;
            }
            set
            {
                if (value == null)
                    return;
                new OrderOperation(this.Db, (IGoodsOperation)new GoodsOperation(this.Db)).UpdateOrderGoodsId(this.id,
                    value.Id);
            }
        }

        public DateTime? Time
        {
            get
            {
                object obj = this.Db.QueryForFirstValue(
                    "SELECT order_time FROM  public.order                 WHERE order_id= :id",
                    new (string, object)[1]
                    {
                        ("id", (object)this.id)
                    });
                return obj == null ? new DateTime?() : new DateTime?((DateTime)obj);
            }
            set
            {
                if (!value.HasValue)
                    return;
                new OrderOperation(this.Db, (IGoodsOperation)new GoodsOperation(this.Db)).UpdateOrderTime(this.id,
                    value.Value);
            }
        }

        public bool IsValid() =>
            new OrderOperation(this.Db, (IGoodsOperation)new GoodsOperation(this.Db)).IsOrderIdValid(this.id);

        public string? Status
        {
            get => (string)this.Db.QueryForFirstValue(
                "SELECT order_status FROM  public.order                   WHERE order_id = :id",
                new (string, object)[1]
                {
                    ("id", (object)this.id)
                }) ?? "";
            set
            {
                switch (value)
                {
                    case "":
                        break;
                    case null:
                        break;
                    default:
                        new OrderOperation(this.Db, (IGoodsOperation)new GoodsOperation(this.Db)).UpdateOrderStatus(
                            this.id, value);
                        break;
                }
            }
        }
    }
}