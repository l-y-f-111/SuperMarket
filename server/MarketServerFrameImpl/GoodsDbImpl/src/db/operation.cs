using DbMiddleware;
using DbMiddlewarePostgresImpl;
using SuperMarket.Db.Goods.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Db.Goods.Operation
{
    public class GoodsModel : IGoodsModel
    {
        public GoodsModel
        (
            long id,
            string name,
            bool isPreorder,
            List<string> types,
            double price,
            string coverimg,
            string previewvideourl
        )
        {
            Id = id;
            Name = name;
            IsPreorder = isPreorder;
            Types = types;
            Price = price;
            CoverImg = coverimg;
            PreviewVideoUrl = previewvideourl;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsPreorder { get; set; }
        public List<string> Types { get; set; }
        public double Price { get; set; }
        public string CoverImg { get; set; }
        public string PreviewVideoUrl { get; set; }
    }

    public class GoodsOperation : IGoodsOperation
    {
        public IDatabase Db;

        public GoodsOperation(IDatabase db)
        {
            Db = db;
        }

        public bool CreateGoods(IGoodsModel model)
        {
            string str1 = "";
            if (model.Types.Count != 0)
            {
                foreach (string str in model.Types)
                {
                    if (str != "") str1 += ("$" + str);
                }

                if (str1 != "") str1 = str1.Substring(1);
            }
            else
                str1 = "";

            int judgement = Db.Query(
                @"INSERT INTO public.goods 
                ( goods_id, goods_name, goods_is_preorder, goods_types, goods_price, goods_cover_img, goods_preview_video_url) 
                VAlUES 
                (:goods_id,:goods_name,:goods_is_preorder,:goods_types,:goods_price,:goods_cover_img,:goods_preview_video_url)",
                1,
                new[]
                {
                    ("goods_id", model.Id),
                    ("goods_name", model.Name),
                    ("goods_is_preorder", model.IsPreorder),
                    ("goods_types", str1),
                    ("goods_price", model.Price),
                    ("goods_cover_img", model.CoverImg),
                    ("goods_preview_video_url", (object)model.PreviewVideoUrl)
                });
            if (judgement == 1) return true;
            else return false;
        }

        public bool DeleteGoods(long goodsId)
        {
            int judgement = Db.Query("DELETE FROM public.goods WHERE goods_id=:goods_id;", -1,
                new[] { ("goods_id", (object)goodsId) });
            if (judgement > 0) return true;
            else return false;
        }

        public List<IGoodsModel> GetAllGoods()
        {
            List<Dictionary<string, object>> result = Db.QueryForTable("SElECT * FROM public.goods", null);
            if (result != null)
            {
                List<IGoodsModel> list = new List<IGoodsModel>();
                foreach (Dictionary<string, object> row in result)
                {
                    List<string> list1;
                    row.TryGetValue("goods_types", out object? num1);
                    row.TryGetValue("goods_types", out object? num2);
                    if (num1.ToString() == "")
                    {
                        list1 = new List<string>();
                    }
                    else
                        list1 = new List<string>(row["goods_types"].ToString().Split('$'));

                    var model = new GoodsModel(
                        (long)row["goods_id"],
                        (string)row["goods_name"],
                        (bool)row["goods_is_preorder"],
                        list1,
                        (double)row["goods_price"],
                        (string)row["goods_cover_img"],
                        (string)row["goods_preview_video_url"]
                    );
                    list.Add(model);
                }

                return list;
            }
            else return new List<IGoodsModel>();
        }

        public List<IGoodsModel> FilterGoodsByIsPreorder(bool isPreorder)
        {
            List<Dictionary<string, object>> result = Db.QueryForTable(
                "SElECT * FROM public.goods WHERE goods_is_preorder=:goods_is_preorder ",
                new[] { ("goods_is_preorder", (object)isPreorder) });
            List<IGoodsModel> list = new List<IGoodsModel>();
            foreach (Dictionary<string, object> row in result)
            {
                List<string> list1 = new List<string>(row["goods_types"].ToString().Split('$'));
                var model = new GoodsModel(
                    (long)row["goods_id"],
                    (string)row["goods_name"],
                    (bool)row["goods_is_preorder"],
                    list1,
                    (double)row["goods_price"],
                    (string)row["goods_cover_img"],
                    (string)row["goods_preview_video_url"]
                );
                list.Add(model);
            }

            return list;
        }

        public List<IGoodsModel> FilterGoodsByTypes(List<string> types)
        {
            string types_str1 = "";
            foreach (var it1 in types)
            {
                types_str1 += ("$" + it1);
            }

            types_str1 = types_str1.Substring(1);
            List<Dictionary<string, object>> result = Db.QueryForTable(
                "SElECT * FROM public.goods WHERE goods_types LIKE :goods_types ",
                new[] { ("goods_types", (object)('%' + types_str1 + '%')) });
            List<IGoodsModel> list = new List<IGoodsModel>();
            foreach (Dictionary<string, object> row in result)
            {
                List<string> list1 = new List<string>(row["goods_types"].ToString().Split('$'));
                var model = new GoodsModel(
                    (long)row["goods_id"],
                    (string)row["goods_name"],
                    (bool)row["goods_is_preorder"],
                    list1,
                    (double)row["goods_price"],
                    (string)row["goods_cover_img"],
                    (string)row["goods_preview_video_url"]
                );
                list.Add(model);
            }

            return list;
        }

        public List<IGoodsModel> FilterGoodsByName(string name)
        {
            List<Dictionary<string, object>> result = Db.QueryForTable(
                "SElECT * FROM public.goods WHERE goods_name=:goods_name ",
                new[] { ("goods_name", (object)name) });
            List<IGoodsModel> list = new List<IGoodsModel>();
            foreach (Dictionary<string, object> row in result)
            {
                List<string> list1 = new List<string>(row["goods_types"].ToString().Split('$'));
                var model = new GoodsModel(
                    (long)row["goods_id"],
                    (string)row["goods_name"],
                    (bool)row["goods_is_preorder"],
                    list1,
                    (double)row["goods_price"],
                    "",
                    ""
                );
                list.Add(model);
            }

            return list;
        }

        public bool UpdateGoodsName(long goodsId, string newValue)
        {
            int judgement = Db.Query(
                "UPDATE super_movie.public.goods SET goods_name=:goods_name WHERE goods_id=:goods_id", 1,
                new[]
                {
                    ("goods_id", (object)goodsId),
                    ("goods_name", (object)newValue)
                });
            if (judgement == 1) return true;
            else return false;
        }

        public bool UpdateGoodsIsPreorder(long goodsId, bool newValue)
        {
            int judgement = Db.Query(
                "UPDATE super_movie.public.goods SET goods_is_preorder=:goods_is_preorder WHERE goods_id=:goods_id", 1,
                new[]
                {
                    ("goods_id", goodsId),
                    ("goods_is_preorder", (object)newValue)
                });
            if (judgement == 1) return true;
            else return false;
        }

        public bool UpdateGoodsTypes(long goodsId, List<string> newValue)
        {
            //string str1 = string.Join("$", newValue);
            string str1 = "";
            foreach (string str in newValue)
            {
                if (str != "") str1 += ("$" + str);
            }

            if (str1 != "") str1 = str1.Substring(1);
            int judgement = Db.Query("UPDATE public.goods SET goods_types=:goods_types WHERE goods_id=:goods_id", 1,
                new[]
                {
                    ("goods_types", (object)str1),
                    ("goods_id", (object)goodsId)
                });
            if (judgement == 1) return true;
            else return false;
        }

        public bool UpdateGoodsPrice(long goodsId, double newValue)
        {
            int judgement = Db.Query("UPDATE public.goods SET goods_price=:goods_price WHERE goods_id=:goods_id", 1,
                new[]
                {
                    ("goods_id", (object)goodsId),
                    ("goods_price", (object)newValue)
                });
            if (judgement == 1) return true;
            else return false;
        }

        public IGoodsModel? GetGoods(long goodsId)
        {
            var result = Db.QueryForFirstRow("SELECT * FROM public.goods WHERE goods_id=:goods_id ",
                new[] { ("goods_id", (object)goodsId) });
            List<string> list1;
            result.TryGetValue("goods_types", out object? num1);
            if (num1.ToString() == "")
            {
                list1 = new List<string>();
            }
            else
                list1 = new List<string>(result["goods_types"].ToString().Split('$'));

            IGoodsModel goodsModel = new GoodsModel(
                (long)result["goods_id"],
                (string)result["goods_name"],
                (bool)result["goods_is_preorder"],
                list1,
                (double)result["goods_price"],
                (string)result["goods_cover_img"],
                (string)result["goods_preview_video_url"]
            );
            if (goodsModel != null) return goodsModel;
            else return null;
        }

        public List<IGoodsModel> MatchGoodsByName(string name)
        {
            List<Dictionary<string, object>> result = Db.QueryForTable(
                "SElECT * FROM public.goods WHERE goods_name LIKE :goods_name",
                new[] { ("goods_name", (object)('%' + name + '%')) });
            List<IGoodsModel> list = new List<IGoodsModel>();
            foreach (Dictionary<string, object> item in result)
            {
                List<string> list1 = new List<string>(item["goods_types"].ToString().Split('$'));
                IGoodsModel goodsModel = new GoodsModel
                (
                    (long)item["goods_id"],
                    (string)item["goods_name"],
                    (bool)item["goods_is_preorder"],
                    list1,
                    (double)item["goods_price"],
                    (string)item["goods_cover_img"],
                    (string)item["goods_preview_video_url"]
                );
                list.Add(goodsModel);
            }

            return list;
        }

        public bool UpdateGoodsCoverImg(long goodsId, string newValue)
        {
            int judgement = Db.Query(
                "UPDATE public.goods SET goods_cover_img=:goods_cover_img WHERE goods_id=:goods_id", 1,
                new[]
                {
                    ("goods_id", (object)goodsId),
                    ("goods_cover_img", (object)newValue)
                });
            if (judgement == 1) return true;
            else return false;
        }

        public bool UpdateGoodsPreviewVideoUrl(long goodsId, string newValue)
        {
            int judgement = Db.Query(
                "UPDATE public.goods SET goods_preview_video_url=:goods_preview_video_url WHERE goods_id=:goods_id", 1,
                new[]
                {
                    ("goods_id", (object)goodsId),
                    ("goods_preview_video_url", (object)newValue)
                });
            if (judgement == 1) return true;
            else return false;
        }
    }
}