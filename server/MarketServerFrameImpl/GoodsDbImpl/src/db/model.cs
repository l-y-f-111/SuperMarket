using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Db.Goods.Model
{
    public class GoodsModel : IGoodsModel
    {
        public GoodsModel
        (
            long id,
            string name,
            bool isReady,
            List<string> types,
            double price,
            string coverimg,
            string previewvideourl,
            long stock
        )
        {
            Id = id;
            Name = name;
            IsReady = isReady;
            Types = types;
            Price = price;
            CoverImg = coverimg;
            PreviewVideoUrl = previewvideourl;
            Stock = stock;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsReady { get; set; }
        public List<string> Types { get; set; }
        public double Price { get; set; }
        public string CoverImg { get; set; }
        public string PreviewVideoUrl { get; set; }
        public long Stock { get; set; }
    }
}