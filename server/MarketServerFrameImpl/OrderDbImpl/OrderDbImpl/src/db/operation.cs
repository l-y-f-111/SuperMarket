using DbMiddleware;
using DbMiddlewarePostgresImpl;
using SuperMarket.Db.Order.Model;
using SuperMarket.Db.Goods.Operation;

namespace SuperMarket.Db.Order.Operation
{
    public class OrderOperation : IOrderOperation
    {
        IDatabase Db;
        private IGoodsOperation _goodsOp;

        public OrderOperation(IDatabase db, IGoodsOperation goodsOp)
        {
            Db = db;
            _goodsOp = goodsOp;
        }

        public bool AddOrder(IOrderModel model)
        {
            var flag = Db.Query(@$"INSERT INTO public.order
             (order_id,order_user_id,order_pay_amount,order_goods_id,order_time,
             order_status)
             VALUES
             (:order_id,:order_user_id,:order_pay_amount,:order_goods_id,:order_time,
             :order_status)", 1,
                new[]
                {
                    ("order_id", (object)model.Id),
                    ("order_user_id", (object)model.UserId),
                    ("order_pay_amount", (object)model.PayAmount),
                    ("order_goods_id", (object)model.GoodsId),
                    ("order_time", (object)model.Time),
                    ("order_status", (object)model.Status)
                });
            if (flag == 1)
                return true;
            else return false;
        }

        public bool DeleteOrder(long orderId)
        {
            var flag = Db.Query(@$"DELETE FROM public.order WHERE order_id = :orderId", 1,
                new[]
                {
                    ("orderId", (object)orderId)
                }
            );
            if (flag == 1)
                return true;
            else return false;
        }

        public IOrderModel? GetOrder(long orderId)
        {
            var result = Db.QueryForFirstRow($@"SELECT *FROM public.order WHERE order_id = :orderId",
                new[]
                {
                    ("orderId", (object)orderId)
                });
            if (result == null)
                return null;
            else
            {
                var model = new OrderModel(
                    (long)result["order_id"],
                    (long)result["order_user_id"],
                    (double)result["order_pay_amount"],
                    (DateTime)result["order_time"],
                    (long)result["order_goods_id"],
                    (string)result["order_status"]
                );
                return model;
            }
        }

        public List<IOrderModel> GetAllOrder()
        {
            List<IOrderModel> List = new List<IOrderModel>();
            var result = Db.QueryForTable("SELECT * FROM public.order", null);
            foreach (var item in result)
            {
                var model = new OrderModel(
                    (long)item["order_id"],
                    (long)item["order_user_id"],
                    (double)item["order_pay_amount"],
                    (DateTime)item["order_time"],
                    (long)item["order_goods_id"],
                    (string)item["order_status"]
                );
                List.Add(model);
            }

            return List;
        }

        public List<IOrderModel> FilterOrderByUserId(long userId)
        {
            List<IOrderModel> List = new List<IOrderModel>();
            var result = Db.QueryForTable($@"SELECT * FROM public.order WHERE order_user_id = :userId",
                new[]
                {
                    ("userId", (object)userId)
                });
            foreach (var item in result)
            {
                var model = new OrderModel(
                    (long)item["order_id"],
                    (long)item["order_user_id"],
                    (double)item["order_pay_amount"],
                    (DateTime)item["order_time"],
                    (long)item["order_goods_id"],
                    (string)item["order_status"]
                );
                List.Add(model);
            }

            return List;
        }

        public List<IOrderModel> FilterOrderByGoodsId(long goodsId)
        {
            List<IOrderModel> List = new List<IOrderModel>();
            var result = Db.QueryForTable($@"SELECT * FROM public.order WHERE order_goods_id = :goodsId",
                new[]
                {
                    ("goodsId", (object)goodsId)
                });
            foreach (var item in result)
            {
                var model = new OrderModel(
                    (long)item["order_id"],
                    (long)item["order_user_id"],
                    (double)item["order_pay_amount"],
                    (DateTime)item["order_time"],
                    (long)item["order_goods_id"],
                    (string)item["order_status"]
                );
                List.Add(model);
            }

            return List;
        }

        public List<IOrderModel> FilterOrderByGoodsTypes(List<string> goodsTypes)
        {
            List<IOrderModel> List = new List<IOrderModel>();
            var goodsmodel = _goodsOp.FilterGoodsByTypes(goodsTypes);
            if (goodsmodel.Count == 0)
                return List;
            else
            {
                foreach (var item in goodsmodel)
                {
                    var goodsId = item.Id;

                    var orders = Db.QueryForTable(
                        $@"SELECT * FROM public.order WHERE order_goods_id = :goodsId",
                        new[]
                        {
                            ("goodsId", (object)goodsId)
                        });
                    foreach (var order in orders)
                    {
                        var model = new OrderModel(
                            (long)order["order_id"],
                            (long)order["order_user_id"],
                            (double)order["order_pay_amount"],
                            (DateTime)order["order_time"],
                            (long)order["order_goods_id"],
                            (string)order["order_status"]
                        );
                        List.Add(model);
                    }
                }

                return List;
            }
        }

        public bool IsOrderIdValid(long orderId)
        {
            var result = Db.QueryForFirstValue($@"SELECT * FROM public.order WHERE order_id = :orderId",
                new[]
                {
                    ("orderId", (object)orderId)
                });

            if (result == null)
                return false;
            else return true;
        }

        public bool UpdateOrderUserId(long orderId, long newValue)
        {
            var flag = Db.Query(@$"UPDATE public.order SET order_user_id = :newValue
                               WHERE order_id = :orderId", 1,
                new[]
                {
                    ("newValue", (object)newValue),
                    ("OrderId", (object)orderId)
                });
            if (flag == 1)
                return true;
            else return false;
        }

        public bool UpdateOrderPayAmount(long orderId, double newValue)
        {
            var flag = Db.Query(@$"UPDATE public.order SET order_pay_amount = :newValue
                               WHERE order_id = :orderId", 1,
                new[]
                {
                    ("newValue", (object)newValue),
                    ("orderId", (object)orderId)
                });
            if (flag == 1)
                return true;
            else return false;
        }

        public bool UpdateOrderTime(long orderId, DateTime newValue)
        {
            var flag = Db.Query(@$"UPDATE public.order SET order_time = :newValue
                               WHERE order_id = :orderId", 1,
                new[]
                {
                    ("newValue", (object)newValue),
                    ("OrderId", (object)orderId)
                });
            if (flag == 1)
                return true;
            else return false;
        }

        public bool UpdateOrderGoodsId(long orderId, long newValue)
        {
            var flag = Db.Query(@$"UPDATE public.order SET order_goods_id = :newValue
                               WHERE order_id = :orderId", 1,
                new[]
                {
                    ("newValue", (object)newValue),
                    ("OrderId", (object)orderId)
                });
            if (flag == 1)
                return true;
            else return false;
        }

        public bool UpdateOrderStatus(long orderId, string newValue)
        {
            var flag = Db.Query(@$"UPDATE public.order SET order_status = :newValue
                               WHERE order_id = :orderId", 1,
                new[]
                {
                    ("newValue", (object)newValue),
                    ("orderId", (object)orderId)
                });
            if (flag == 1)
                return true;
            else
                return false;
        }
    }
}