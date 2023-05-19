// Decompiled with JetBrains decompiler
// Type: SuperMarket.Container.Order.Provider.OrderProvider
// Assembly: OrderContainerImpl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6892D3A6-3714-4FB0-9364-31019630CFFE
// Assembly location: /home/thaumy/data/dev/repo/SuperMarketSDK/_build/OrderContainerImpl.dll

using DbMiddleware;
using SuperMarket.Container.Goods.Entity;
using SuperMarket.Container.Goods.Provider;
using SuperMarket.Container.Order.Entity;
using SuperMarket.Container.User.Entity;
using SuperMarket.Container.User.Provider;
using SuperMarket.Db.Goods.Operation;
using SuperMarket.Db.Order.Model;
using SuperMarket.Db.Order.Operation;
using MarketServerUtil;
using System;
using System.Collections.Generic;


#nullable enable
namespace SuperMarket.Container.Order.Provider
{
    public class OrderProvider : IOrderProvider
    {
        public IDatabase Db;
        public Func<IUserProvider> userProviderF;
        public IGoodsProvider goodsProvider;
        public IdGenerator Gen;
        public IGoodsOperation goodsOperation;

        public OrderProvider(
            Func<IUserProvider> userProviderF,
            IGoodsProvider goodsProvider,
            IGoodsOperation goodsOperation,
            IdGenerator gen,
            IDatabase db)
        {
            this.userProviderF = userProviderF;
            this.goodsProvider = goodsProvider;
            this.goodsOperation = goodsOperation;
            this.Gen = gen;
            this.Db = db;
        }

        public IOrderEntity? CreateOrder(
            IUserEntity user,
            double payAmount,
            IGoodsEntity goods
        )
        {
            long id = this.Gen.Next();
            OrderEntity orderEntity = new OrderEntity(id, payAmount, DateTime.Now, this.userProviderF,
                this.goodsProvider, this.Db);
            return this.Db.Query(
                "INSERT INTO public.order (order_id,order_user_id,order_pay_amount,order_goods_id,order_time,order_status)  VALUES  (:order_id,:order_user_id,:order_pay_amount,:order_goods_id,:order_time,:order_status)",
                1, new (string, object)[6]
                {
                    ("order_id", (object)id),
                    ("order_user_id", (object)user.Id),
                    ("order_pay_amount", (object)payAmount),
                    ("order_goods_id", (object)goods.Id),
                    ("order_time", (object)DateTime.Now),
                    ("order_status", (object)"created")
                }) == 1
                ? (IOrderEntity)orderEntity
                : (IOrderEntity)null;
        }

        public IOrderEntity? GetOrder(long id)
        {
            Dictionary<string, object> dictionary = this.Db.QueryForFirstRow(
                "SELECT * FROM public.order WHERE order_id = :id", new (string, object)[1]
                {
                    (nameof(id), (object)id)
                });
            return dictionary == null
                ? (IOrderEntity)null
                : (IOrderEntity)new OrderEntity((long)dictionary["order_id"], (double)dictionary["order_pay_amount"],
                    (DateTime)dictionary["order_time"], this.userProviderF,
                    this.goodsProvider, this.Db);
        }

        public List<IOrderEntity> GetAllOrder()
        {
            List<IOrderModel> allOrder1 = new OrderOperation(this.Db, this.goodsOperation).GetAllOrder();
            List<IOrderEntity> allOrder2 = new List<IOrderEntity>();
            if (allOrder1.Count == 0)
                return allOrder2;
            foreach (IOrderModel orderModel in allOrder1)
            {
                OrderEntity orderEntity = new OrderEntity(orderModel.Id, orderModel.PayAmount,
                    orderModel.Time, this.userProviderF, this.goodsProvider,
                    this.Db);
                allOrder2.Add((IOrderEntity)orderEntity);
            }

            return allOrder2;
        }

        public List<IOrderEntity> FilterOrderByGoods(IGoodsEntity goods)
        {
            List<IOrderEntity> orderEntityList = new List<IOrderEntity>();
            List<IOrderModel> orderModelList =
                new OrderOperation(this.Db, this.goodsOperation).FilterOrderByGoodsId(goods.Id);
            if (orderModelList == null)
                return orderEntityList;
            foreach (IOrderModel orderModel in orderModelList)
            {
                OrderEntity orderEntity = new OrderEntity(orderModel.Id, orderModel.PayAmount,
                    orderModel.Time, this.userProviderF, this.goodsProvider, this.Db);
                orderEntityList.Add((IOrderEntity)orderEntity);
            }

            return orderEntityList;
        }

        public List<IOrderEntity> FilterOrderByGoodsTypes(List<string> goodsTypes)
        {
            List<IOrderEntity> orderEntityList = new List<IOrderEntity>();
            List<IOrderModel> orderModelList =
                new OrderOperation(this.Db, this.goodsOperation).FilterOrderByGoodsTypes(goodsTypes);
            if (orderModelList.Count == 0)
                return orderEntityList;
            foreach (IOrderModel orderModel in orderModelList)
            {
                OrderEntity orderEntity = new OrderEntity(orderModel.Id, orderModel.PayAmount,
                    orderModel.Time, this.userProviderF, this.goodsProvider, this.Db);
                orderEntityList.Add((IOrderEntity)orderEntity);
            }

            return orderEntityList;
        }
    }
}