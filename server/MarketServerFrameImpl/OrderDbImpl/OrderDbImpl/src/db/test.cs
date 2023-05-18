using NUnit.Framework;
using SuperMarket.Db.Order.Operation;
using SuperMarket.Db.Order.Model;
using DbMiddleware;
using DbMiddlewarePostgresImpl;
using SuperMarket.Db.Goods.Operation;

namespace SuperMarket.Db.Order
{
    public class QueryForFirstColumn
    {
        IDatabase db = new PostgresDatabase("postgres", "123456", "localhost", 5432, "super_market");

        [SetUp]

            /*       [Test]
             public void Test_CreateOrder()
                    {
                        OrderOperation b = new OrderOperation(db,null);
                        OrderModel model = new OrderModel(123456789, 156666, 34, DateTime.Now, 111, 222, 333, "第五排第三列","ok");
                        var result = b.CreateOrder(model);
                        Assert.IsTrue(result);
                    }*/
           
        /*     [Test]
             public void Test_DeleteOrder()
             {
                 OrderOperation b = new OrderOperation(db,null);
                 var result = b.DeleteOrder(111);
                 Assert.IsTrue(result);
             }*/

        [Test]
        public void Test_GetOrder()
        {
            OrderOperation b = new OrderOperation(db, null);
            var c = b.GetOrder(222);
            Assert.IsNotNull(c);
        }

        [Test]
        public void Test_GetAllOrder()
        {
            OrderOperation b = new OrderOperation(db, null);
            var result = b.GetAllOrder();
            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
            }
        }

        [Test]
        public void Test_FilterOrderByUserId()
        {
            IGoodsOperation goodsOperation = new GoodsOperation(db);
            OrderOperation b = new OrderOperation(db, goodsOperation);
            var result = b.FilterOrderByUserId(111);
            foreach (var item in result)
            {
                Console.WriteLine(item.Id);
            }
        }

        [Test]//测试不存在时
        public void Test_FilterOrderByUserId2()
        {
            OrderOperation b = new OrderOperation(db, null);
            var result = b.FilterOrderByUserId(1111);
            var count = result.Count;
            Console.WriteLine(count);
            Assert.AreEqual(0, count);
        }

        [Test]
        public void Test_FilterOrderByGoodsTypes()
        {
            List<string> types = new List<string>();
            types.Add("jhjk1");
            types.Add("wer");
            IGoodsOperation goodsOperation = new GoodsOperation(db);
            OrderOperation op = new OrderOperation(db, goodsOperation);

            var result = op.FilterOrderByGoodsTypes(types);
            foreach(var item in result)
            {
                Console.WriteLine(item.Id);
            }
      
        }

        [Test]
        public void Test_IsOrderIdValid()
        {
            OrderOperation b = new OrderOperation(db, null);
            var result = b.IsOrderIdValid(333);
            Assert.IsTrue(result);
        }
        /*
                [Test]
                public void Test_UpdateOrderUserId()
                {
                    OrderOperation b = new OrderOperation(db, null);
                    var result = b.UpdateOrderUserId(444, 188);
                    Assert.IsTrue(result);
                }

                [Test]
                public void Test_UpdateOrderPayAmount()
                {
                    OrderOperation b = new OrderOperation(db, null);
                    var result = b.UpdateOrderPayAmount(555, 88);
                    Assert.IsTrue(result);
                }

                [Test]
                public void Test_UpdateOrderTime()
                {
                    OrderOperation b = new OrderOperation(db, null);
                    var result = b.UpdateOrderTime(666, DateTime.Now);
                    Assert.IsTrue(result);
                }

                [Test]
                public void Test_UpdateOrderGoodsId()
                {
                    OrderOperation b = new OrderOperation(db, null);
                    var result = b.UpdateOrderGoodsId(777, 333333);
                    Assert.IsTrue(result);
                }

                [Test]
                public void Test_UpdateOrderCinemaId()
                {
                    OrderOperation b = new OrderOperation(db, null);
                    var result = b.UpdateOrderCinemaId(888, 6666);
                    Assert.IsTrue(result);
                }

                [Test]
                public void Test_UpdateOrderScheduleId()
                {
                    OrderOperation b = new OrderOperation(db, null);
                    var result = b.UpdateOrderScheduleId(999, 777777);
                    Assert.IsTrue(result);
                }

                [Test]
                public void Test_UpdateOrderCinemaSeat()
                {
                    OrderOperation b = new OrderOperation(db, null);
                    var c = b.UpdateOrderCinemaSeat(123, "第一排第2列");
                    Assert.True(c);
                }
                [Test]
                public void Test_UpdateOrderStatus()
                {
                    OrderOperation b = new OrderOperation(db, null);
                    var result = b.UpdateOrderStatus(111, "No");
                    Assert.IsTrue(result);
                }*/

    }
}
