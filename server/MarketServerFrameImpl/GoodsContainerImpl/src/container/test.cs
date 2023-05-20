using DbMiddleware;
using DbMiddlewarePostgresImpl;
using NUnit.Framework;
using SuperMarket.Container.Goods.Entity;
using SuperMarket.Container.Goods.Provider;
using MarketServerUtil;

namespace test
{
    internal class test
    {
        IDatabase db = new PostgresDatabase("postgres", "123456", "localhost", 5432, "super_movie");

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_CreateGoods()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("1", true, 0.1);
            Assert.IsNotNull(result1);
        }

        [Test]
        public void Test_GetGoods()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("1", true, 0.1);
            Assert.IsNotNull(result1);
            IGoodsEntity result2 = op.GetGoods(result1.Id);
            Assert.IsNotNull(result2);
            Assert.AreEqual(result1.Id, result2.Id);
        }

        [Test]
        public void Test_GetAllGoods()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("1", true, 0.1);
            IGoodsEntity result2 = op.CreateGoods("2", true, 0.4);
            result1.AddType("1");
            result1.AddType("2");
            result2.AddType("3");
            result2.AddType("4");
            List<string> list1 = new List<string>();
            list1.Add("1");
            list1.Add("2");
            Assert.AreEqual(list1, result1.Types);
        }

        [Test]
        public void Test_FilterGoodsByIsReady()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("1", false, 0.1);
            var result3 = op.FilterGoodsByIsReady(false);
            var judge = false;
            foreach (IGoodsEntity result in result3)
            {
                if (result1.Id == result.Id)
                {
                    judge = true;
                }
            }

            Assert.True(judge);
        }

        [Test]
        public void Test_AddType()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity? result1 = op.CreateGoods("1", false, 0.1);
            if (result1 != null)
            {
                IGoodsEntity op1 = new GoodsEntity(result1.Id, db);
                op1.AddType("123");
                List<string> list = new List<string>();
                list.Add("123");
                op1.AddType("456");
                list.Add("456");
                IGoodsEntity result = op.GetGoods(result1.Id);
                Assert.AreEqual(list, result.Types);
            }
        }

        [Test]
        public void Test_RemoveType()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("1", false, 0.1);
            IGoodsEntity op1 = new GoodsEntity(result1.Id, db);
            op1.AddType("123");
            op1.AddType("456");
            List<string> list = new List<string>();
            list.Add("456");
            op1.RemoveType("123");
            IGoodsEntity result2 = op.GetGoods(result1.Id);
            Assert.AreEqual(list, result2.Types);
        }

        [Test]
        public void Test_ClearType()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("1", false, 0.1);
            IGoodsEntity op1 = new GoodsEntity(result1.Id, db);
            op1.AddType("123");
            op1.AddType("456");
            op1.ClearType();
            IGoodsEntity result2 = op.GetGoods(result1.Id);
        }

        [Test]
        public void Test_FilterGoodsByTypes()
        {
            db.Query("DELETE FROM public.goods", -1, null);
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("1", false, 0.1);
            result1.AddType("1234");
            result1.AddType("567");
            List<string> list = new List<string>();
            list.Add("1234");
            var result3 = op.FilterGoodsByTypes(list);
            Assert.AreEqual(1, result3.Count);
        }

        [Test]
        public void Test_FilterGoodsByName()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            DateTime time;
            IGoodsEntity result1 = op.CreateGoods("123", false, 0.1);
            result1.AddType("1234");
            List<string> list = new List<string>();
            list.Add("1234");
            var result3 = op.FilterGoodsByName("123");
            var judge = false;
            foreach (IGoodsEntity result in result3)
            {
                if (result1.Id == result.Id)
                {
                    judge = true;
                }
            }

            Assert.True(judge);
        }

        [Test]
        public void Test_MatchGoodsByName()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            DateTime time;
            IGoodsEntity result1 = op.CreateGoods("1234", false, 0.1);
            result1.AddType("1234");
            List<string> list = new List<string>();
            list.Add("1234");
            var result3 = op.MatchGoodsByName("234");
            var judge = false;
            foreach (IGoodsEntity result in result3)
            {
                if (result1.Id == result.Id)
                {
                    judge = true;
                }
            }

            Assert.True(judge);
        }

        [Test]
        public void Test_Drop()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("1", false, 0.1);
            result1.AddType("1234");
            List<string> list = new List<string>();
            list.Add("11112");
            result1.Drop();
            var result3 = op.GetAllGoods();
            var judge = false;
            foreach (IGoodsEntity result in result3)
            {
                if (result1.Id != result.Id)
                {
                    judge = true;
                }
            }

            Assert.True(judge);
        }

        [Test]
        public void Test_IsValid()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("1", false, 0.1);
            result1.AddType("1234");
            List<string> list = new List<string>();
            list.Add("11112");
            bool judge = result1.IsValid();
            Assert.True(judge);
        }

        [Test]
        public void Test_Name()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("1", false, 0.1);
            Assert.AreEqual(result1.Name, "1");
        }

        [Test]
        public void Test_IsReady()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("456", false, 0.1);
            var result = op.GetGoods(result1.Id);
            Assert.AreEqual(result.IsReady, result1.IsReady);
        }

        [Test]
        public void Test_Types()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("456", false, 0.1);
            result1.AddType("123");
            result1.AddType("456");
            var result = op.GetGoods(result1.Id);
            Assert.AreEqual(result.Types, result1.Types);
        }

        [Test]
        public void Test_Price()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("456", false, 0.1);
            var result = op.GetGoods(result1.Id);
            Assert.AreEqual(result.Price, result1.Price);
        }

        [Test]
        public void Test_CoverImg()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("456", false, 0.1);
            result1.CoverImg = ("123");
            var result = op.GetGoods(result1.Id);
            Assert.AreEqual(result.CoverImg, result1.CoverImg);
        }

        [Test]
        public void Test_PreviewVideoUrl()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("456", false, 0.1);
            result1.PreviewVideoUrl = ("123");
            var result = op.GetGoods(result1.Id);
            Assert.AreEqual(result.PreviewVideoUrl, result1.PreviewVideoUrl);
        }

        [Test]
        public void Test_GetAllGoodsType()
        {
            var gen = new IdGenerator(ActionType.Goods);
            IGoodsProvider op = new GoodsProvider(gen, db);
            IGoodsEntity result1 = op.CreateGoods("1", false, 0.1);
            //result1.AddType("");
            /*result1.AddType("123");
            result1.AddType("456");*/
            //IGoodsEntity result2 = op.CreateGoods("2", time, false, 0.1);
            /*result2.AddType("123");
            result2.AddType("1");*/
            //result2.AddType("");
            /*List<string> list = new List<string>();
            list.Add("123");
            list.Add("456");
            list.Add("1");
            Assert.AreEqual(list, result3);*/
            Assert.AreEqual(0, result1.Types.Count);
        }
    }
}