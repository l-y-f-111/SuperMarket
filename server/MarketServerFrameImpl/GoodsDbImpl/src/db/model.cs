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
}