using SuperMarket.Container.Goods.Entity;
using SuperMarket.Db.Goods.Model;
using SuperMarket.Db.Goods.Operation;
using MarketServerUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMiddleware;

namespace SuperMarket.Container.Goods.Provider
{
    public class GoodsProvider : IGoodsProvider
    {
        public IDatabase Db;
        public IdGenerator gen;

        public GoodsProvider(IdGenerator gen, IDatabase db)
        {
            this.gen = gen;
            Db = db;
        }

        public IGoodsEntity? CreateGoods
        (string name,
            bool isPreorder,
            double price)
        {
            var model = new Db.Goods.Model.GoodsModel(gen.Next(), name, isPreorder, new List<string>(), price, "", "");
            IGoodsOperation op = new GoodsOperation(Db);
            bool judgement = op.CreateGoods(model);
            if (judgement)
            {
                IGoodsEntity? goods = GetGoods(model.Id);
                return goods;
            }
            else return null;
        }

        public IGoodsEntity? GetGoods(long id)
        {
            GoodsOperation op = new GoodsOperation(Db);
            var result0 = op.GetGoods(id);
            if (result0 != null)
            {
                GoodsEntity result1 = new GoodsEntity(result0.Id, Db);

                return result1;
            }
            else return null;
        }

        public List<IGoodsEntity> GetAllGoods()
        {
            GoodsOperation op = new GoodsOperation(Db);
            List<IGoodsModel> goodsModels = op.GetAllGoods();
            if (goodsModels != null)
            {
                List<IGoodsEntity> result = new List<IGoodsEntity>();
                foreach (IGoodsModel goodsModel in goodsModels)
                {
                    GoodsEntity result1 = new GoodsEntity(goodsModel.Id, Db);
                    result.Add(result1);
                }

                return result;
            }
            else return new List<IGoodsEntity>();
        }

        public List<IGoodsEntity> FilterGoodsByIsPreorder(bool isPreorder)
        {
            GoodsOperation op = new GoodsOperation(Db);
            List<IGoodsModel> goodsModels = op.FilterGoodsByIsPreorder(isPreorder);
            if (goodsModels != null)
            {
                List<IGoodsEntity> result = new List<IGoodsEntity>();
                foreach (IGoodsModel goodsModel in goodsModels)
                {
                    GoodsEntity result1 = new GoodsEntity(goodsModel.Id, Db);
                    result.Add(result1);
                }

                return result;
            }
            else return new List<IGoodsEntity>();
        }

        public List<IGoodsEntity> FilterGoodsByTypes(List<string> types)
        {
            GoodsOperation op = new GoodsOperation(Db);
            List<IGoodsModel> goodsModels = op.FilterGoodsByTypes(types);
            if (goodsModels != null)
            {
                List<IGoodsEntity> result = new List<IGoodsEntity>();
                foreach (IGoodsModel goodsModel in goodsModels)
                {
                    GoodsEntity result1 = new GoodsEntity(goodsModel.Id, Db);
                    result.Add(result1);
                }

                return result;
            }
            else return new List<IGoodsEntity>();
        }

        public List<IGoodsEntity> FilterGoodsByName(string name)
        {
            GoodsOperation op = new GoodsOperation(Db);
            List<IGoodsModel> goodsModels = op.FilterGoodsByName(name);
            if (goodsModels != null)
            {
                List<IGoodsEntity> result = new List<IGoodsEntity>();
                foreach (IGoodsModel goodsModel in goodsModels)
                {
                    GoodsEntity result1 = new GoodsEntity(goodsModel.Id, Db);
                    result.Add(result1);
                }

                return result;
            }
            else return new List<IGoodsEntity>();
        }

        public List<IGoodsEntity> MatchGoodsByName(string name)
        {
            GoodsOperation op = new GoodsOperation(Db);
            List<IGoodsModel> goodsModels = op.MatchGoodsByName(name);
            if (goodsModels != null)
            {
                List<IGoodsEntity> result = new List<IGoodsEntity>();
                foreach (IGoodsModel goodsModel in goodsModels)
                {
                    GoodsEntity result1 = new GoodsEntity(goodsModel.Id, Db);
                    result.Add(result1);
                }

                return result;
            }
            else return new List<IGoodsEntity>();
        }

        public List<string> GetAllGoodsType()
        {
            GoodsOperation op = new GoodsOperation(Db);
            List<IGoodsModel> goodsModels = op.GetAllGoods();
            var result1 = new List<string>();
            if (goodsModels != null)
            {
                string s = "1";
                List<string> result = new List<string>();
                foreach (var item in goodsModels)
                {
                    foreach (var item1 in item.Types)
                    {
                        result.Add(item1);
                        s = item1;
                    }
                }

                if (s != "")
                {
                    foreach (string item in result)
                    {
                        if (!result1.Contains(item))
                        {
                            result1.Add(item);
                        }
                    }

                    return result1;
                }
                else return result1;
            }
            else return result1;
        }
    }
}