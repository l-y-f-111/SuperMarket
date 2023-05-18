using DbMiddleware;
using DbMiddlewarePostgresImpl;
using NUnit.Framework;
using SuperMarket.Db.Goods.Model;
using SuperMarket.Db.Goods.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goods1
{
    public class test
    {
        IDatabase db = new PostgresDatabase("postgres", "123456", "localhost", 5432, "super_market");

        [SetUp]
        public void Setup()
        {
            db.Query("DELETE FROM public.goods", -1, null);
            IGoodsOperation op = new GoodsOperation(db);
            var types1 = new List<string>();
            types1.Add("1");
            types1.Add("2");
            var model1 =
                new SuperMarket.Db.Goods.Model.GoodsModel(1, "zty", false, types1, 0.114514, "",
                    "");
            op.CreateGoods(model1);
        }

        [Test]
        public void Test_CreateGoods()
        {
            IGoodsOperation op = new GoodsOperation(db);
            var types = new List<string>();
            types.Add("aa");
            types.Add("bb");
            var model = new SuperMarket.Db.Goods.Model.GoodsModel(123, "zty", false, types, 0.114514,
                "", "");
            var ok = op.CreateGoods(model);
            Assert.True(ok);
            var isContain = false;
            var result = op.GetAllGoods();
            foreach (var goods in result)
                if (goods.Id == model.Id)
                    isContain = true;

            Assert.True(isContain);
        }

        [Test]
        public void Test_GetAllGoods()
        {
            IGoodsOperation op = new GoodsOperation(db);
            var result = op.GetAllGoods();
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void Test_FilterGoodsByIsPreorder()
        {
            IDatabase db = new PostgresDatabase("postgres", "123456", "localhost", 5432, "super_market");
            IGoodsOperation op = new GoodsOperation(db);

            List<IGoodsModel> list = op.FilterGoodsByIsPreorder(true);
            foreach (var item in list)
            {
                Assert.AreEqual(1, item.Id);
            }
        }

        [Test]
        public void Test_FilterGoodsByTypesr()
        {
            IGoodsOperation op = new GoodsOperation(db);
            var types = new List<string>();
            types.Add("2");
            List<IGoodsModel> list = op.FilterGoodsByTypes(types);
            Assert.AreEqual(1, list.Count);
        }

        [Test]
        public void Test_FilterGoodsByName()
        {
            IDatabase db = new PostgresDatabase("postgres", "123456", "localhost", 5432, "super_market");
            IGoodsOperation op = new GoodsOperation(db);
            List<IGoodsModel> list = op.FilterGoodsByName("zty");
            foreach (var item in list)
            {
                Assert.AreEqual(1, item.Id);
            }
        }

        [Test]
        public void Test_UpdateGoodsName()
        {
            IDatabase db = new PostgresDatabase("postgres", "123456", "localhost", 5432, "super_market");
            IGoodsOperation op = new GoodsOperation(db);
            op.UpdateGoodsName(1, "1");
            var list = op.GetAllGoods();
            foreach (var item in list)
            {
                Assert.AreEqual("1", item.Name);
            }
        }

        [Test]
        public void Test_UpdateGoodsIsPreorder()
        {
            IDatabase db = new PostgresDatabase("postgres", "123456", "localhost", 5432, "super_market");
            IGoodsOperation op = new GoodsOperation(db);
            op.UpdateGoodsIsPreorder(1, true);
            var list = op.GetAllGoods();
            foreach (var item in list)
            {
                Assert.AreEqual(true, item.IsPreorder);
            }
        }

        [Test]
        public void Test_UpdateGoodsTypes()
        {
            var types = new List<string>();
            types.Add("xx");
            types.Add("yy");
            IGoodsOperation op = new GoodsOperation(db);
            op.UpdateGoodsTypes(1, types);
            var list = op.GetAllGoods();
            foreach (var item in list)
            {
                Assert.AreEqual(types, item.Types);
            }
        }

        [Test]
        public void Test_UpdateGoodsPrice()
        {
            IGoodsOperation op = new GoodsOperation(db);
            op.UpdateGoodsPrice(1, 123);
            var list = op.GetAllGoods();
            foreach (var item in list)
            {
                Assert.AreEqual(123, item.Price);
            }
        }

        [Test]
        public void Test_MatchGoodsByName()
        {
            var model1 =
                new SuperMarket.Db.Goods.Model.GoodsModel(1, "abc", false, new List<string>(), 0.114514, "", "");
            IGoodsOperation op = new GoodsOperation(db);
            op.CreateGoods(model1);
            List<IGoodsModel> result = op.MatchGoodsByName("c");
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
        }

        [Test]
        public void Test_UpdateGoodsCoverImg()
        {
            IGoodsOperation op = new GoodsOperation(db);
            op.UpdateGoodsCoverImg(1, "lyf");
            var result = op.GetGoods(1);
            if (result != null) Assert.AreEqual("lyf", result.CoverImg);
        }

        [Test]
        public void Test_UpdateGoodsPreviewVideoUrl()
        {
            IGoodsOperation op = new GoodsOperation(db);
            op.UpdateGoodsPreviewVideoUrl(1, "lyf");
            var result = op.GetGoods(1);
            if (result != null) Assert.AreEqual("lyf", result.PreviewVideoUrl);
        }
    }
}