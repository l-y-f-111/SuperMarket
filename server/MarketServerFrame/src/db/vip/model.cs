namespace SuperMarket.Db.Vip.Model;

//resolver : HZC
//asm file : VipDbImpl
//impl :: SuperMarket.Db.Vip.Model.VipModel
//impl proj struct :
//src/db/model.cs
public interface IVipModel
{
    public long Level { get; set; }
    public double Discount { get; set; }
    public double MonthPrice { get; set; }
}