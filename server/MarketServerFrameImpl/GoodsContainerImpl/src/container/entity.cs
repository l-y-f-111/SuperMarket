using SuperMarket.Db.Goods.Model;
using SuperMarket.Db.Goods.Operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbMiddleware;

namespace SuperMarket.Container.Goods.Entity
{
    public class GoodsEntity : IGoodsEntity
    {
        private long _id;
        IDatabase Db;

        internal GoodsEntity(long id, IDatabase db)
        {
            _id = id;
            Db = db;
        }


        /// <summary>
        /// 释放实体
        /// </summary>
        /// <returns></returns>
        public bool Drop()
        {
            GoodsOperation op = new GoodsOperation(Db);
            bool judgement = op.DeleteGoods(Id);
            if (judgement)
            {
                return true;
            }
            else return false;
        }

        /// <summary>
        /// 实体是否合法
        /// </summary>
        /// <returns></returns>
        public bool IsValid()
        {
            IGoodsOperation op = new GoodsOperation(Db);
            IGoodsModel? result = op.GetGoods(Id);
            if (result != null) return true;
            else return false;
        }

        public long Id
        {
            get { return _id; }
        }

        public string? Name
        {
            get
            {
                IGoodsOperation op = new GoodsOperation(Db);
                IGoodsModel? result1 = op.GetGoods(Id);
                if (result1 != null)
                {
                    string? reuslt = result1.Name;

                    if (reuslt != null) return reuslt;
                    else return null;
                }
                else return null;
            }
            set
            {
                if (value != null)
                {
                    IGoodsOperation op = new GoodsOperation(Db);
                    op.UpdateGoodsName(Id, value);
                }

                return;
            }
        }

        public bool IsReady
        {
            get
            {
                IGoodsOperation op = new GoodsOperation(Db);
                IGoodsModel? result1 = op.GetGoods(Id);
                if (result1 != null)
                {
                    bool reuslt = result1.IsReady;
                    return (bool)reuslt;
                }

                return false;
            }
            set
            {
                IGoodsOperation op = new GoodsOperation(Db);
                op.UpdateGoodsIsReady(Id, value);
            }
        }

        public List<string> Types
        {
            get
            {
                IGoodsOperation op = new GoodsOperation(Db);
                IGoodsModel? result1 = op.GetGoods(Id);
                if (result1 != null)
                {
                    List<string> reuslt = result1.Types;
                    if (reuslt.Count != 0) return reuslt;
                    else return new List<string>();
                }
                else return new List<string>();
            }
        }

        public bool AddType(string name)
        {
            IGoodsOperation op1 = new GoodsOperation(Db);
            IGoodsModel? result1 = op1.GetGoods(Id);
            if (result1 != null)
            {
                List<string> list;
                list = result1.Types;
                list.Add(name);
                IGoodsOperation op = new GoodsOperation(Db);
                bool judgement = op.UpdateGoodsTypes(Id, list);
                if (judgement) return true;
                else return false;
            }
            else return false;
        }

        public bool RemoveType(string name)
        {
            IGoodsOperation op1 = new GoodsOperation(Db);
            IGoodsModel? result1 = op1.GetGoods(Id);
            if (result1 != null)
            {
                List<string> list = result1.Types;
                list.Remove(name);
                IGoodsOperation op = new GoodsOperation(Db);
                bool judgement1 = op.UpdateGoodsTypes(Id, list);
                if (judgement1) return true;
                else return false;
            }
            else return false;
        }

        public bool ClearType()
        {
            IGoodsOperation op1 = new GoodsOperation(Db);
            IGoodsModel? result1 = op1.GetGoods(Id);
            if (result1 != null)
            {
                IGoodsOperation op = new GoodsOperation(Db);
                List<string> newValue = new List<string>();
                bool judgement = op.UpdateGoodsTypes(Id, newValue);
                if (judgement) return true;
                else return false;
            }
            else return false;
        }

        public double Price
        {
            get
            {
                IGoodsOperation op = new GoodsOperation(Db);
                IGoodsModel? result1 = op.GetGoods(Id);
                if (result1 != null)
                {
                    double reuslt = result1.Price;
                    if (reuslt >= 0)
                    {
                        return (double)reuslt;
                    }

                    return -1;
                }
                else return -1;
            }
            set
            {
                if (value >= 0)
                {
                    IGoodsOperation op = new GoodsOperation(Db);
                    op.UpdateGoodsPrice(Id, value);
                }

                return;
            }
        }

        public string CoverImg
        {
            get
            {
                IGoodsOperation op = new GoodsOperation(Db);
                IGoodsModel? result1 = op.GetGoods(Id);
                if (result1 != null)
                {
                    string? reuslt = result1.CoverImg;
                    if (reuslt != null) return reuslt;
                    else return "";
                }
                else return "";
            }
            set
            {
                if (value != null)
                {
                    IGoodsOperation op = new GoodsOperation(Db);
                    op.UpdateGoodsCoverImg(Id, value);
                }

                return;
            }
        }

        public string PreviewVideoUrl
        {
            get
            {
                IGoodsOperation op = new GoodsOperation(Db);
                IGoodsModel? result1 = op.GetGoods(Id);
                if (result1 != null)
                {
                    string? reuslt = result1.PreviewVideoUrl;
                    if (reuslt != null) return reuslt;
                    else return "";
                }
                else return "";
            }
            set
            {
                if (value != null)
                {
                    IGoodsOperation op = new GoodsOperation(Db);
                    op.UpdateGoodsPreviewVideoUrl(Id, value);
                }

                return;
            }
        }
        
        public long Stock
        {
            get
            {
                IGoodsOperation op = new GoodsOperation(Db);
                IGoodsModel? result1 = op.GetGoods(Id);
                if (result1 != null)
                {
                    long reuslt = result1.Stock;
                    if (reuslt != null) return reuslt;
                    else return 0;
                }
                else return 0;
            }
            set
            {
                if (value != null)
                {
                    IGoodsOperation op = new GoodsOperation(Db);
                    op.UpdateGoodsStock(Id, value);
                }

                return;
            }
        }
    }
}