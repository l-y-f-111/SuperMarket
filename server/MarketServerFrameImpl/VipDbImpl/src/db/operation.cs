using DbMiddleware;
using SuperMarket.Db.Vip.Model;

namespace SuperMarket.Db.Vip.Operation
{
    public class VipOperation : IVipOperation
    {
        IDatabase Db;

        public VipOperation(IDatabase db)
        {
            this.Db = db;
        }

        public bool CreateVip(IVipModel model)
        {
            var sql = "INSERT INTO public.vip VALUES(:vip_level,:vip_discount,:vip_month_price)";
            var flag = Db.Query(sql, 1,
                new[]
                {
                    ("vip_level", (object)model.Level), ("vip_discount", (object)model.Discount),
                    ("vip_month_price", (object)model.MonthPrice)
                });
            if (flag == 1) return true;
            else return false;
        }

        public bool DeleteVip(long vipLevel)
        {
            var sql = "DELETE FROM public.vip where vip_level=:vipLevel";
            var flag = Db.Query(sql, 1, new[] { ("vipLevel", (object)vipLevel) });
            if (flag == 1) return true;
            else return false;
        }

        public IVipModel? GetVip(long vipLevel)
        {
            var sql = "SELECT * FROM public.vip WHERE vip_level=:viplevel";
            var result = Db.QueryForFirstRow(sql, new[] { ("viplevel", (object)vipLevel) });
            if (result == null)
                return null;
            else
            {
                var model = new VipModel(
                    (long)result["vip_level"],
                    (double)result["vip_discount"],
                    (double)result["vip_month_price"]
                );
                return model;
            }
        }

        public List<IVipModel> GetAllVip()
        {
            var sql = "SELECT * FROM public.vip";
            var result = Db.QueryForTable(sql, null);

            var ret = new List<IVipModel>();
            foreach (var row in result)
            {
                var model = new VipModel(
                    (long)row["vip_level"],
                    (double)row["vip_discount"],
                    (double)row["vip_month_price"]
                );
                ret.Add(model);
            }

            return ret;
        }

        public bool UpdateVipDiscount(long vipLevel, double newValue)
        {
            var sql = "UPDATE public.vip SET vip_discount=:newValue where vip_level=:vipLevel";
            var flag = Db.Query(sql, 1, new[] { ("newValue", (object)newValue), ("vipLevel", (object)vipLevel) });
            if (flag == 1) return true;
            else return false;
        }

        public bool UpdateVipMonthPrice(long vipLevel, double newValue)
        {
            var sql = "UPDATE public.vip SET vip_month_price=:newValue where vip_level=:vipLevel";
            var flag = Db.Query(sql, 1, new[] { ("newValue", (object)newValue), ("vipLevel", (object)vipLevel) });
            if (flag == 1) return true;
            else return false;
        }
    }
}