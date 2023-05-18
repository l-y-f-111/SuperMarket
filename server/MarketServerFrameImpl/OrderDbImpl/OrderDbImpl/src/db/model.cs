using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Db.Order.Model
{
    public class OrderModel : IOrderModel
    {
        public OrderModel(long id, long userId, double payAmount, DateTime time,
            long goodsId, string status)
        {
            Id = id;
            UserId = userId;
            PayAmount = payAmount;
            Time = time;
            GoodsId = goodsId;
            Status = status;
        }

        public long Id { get; set; }
        public long UserId { get; set; }
        public double PayAmount { get; set; }
        public DateTime Time { get; set; }
        public long GoodsId { get; set; }
        public string Status { get; set; }
    }
}