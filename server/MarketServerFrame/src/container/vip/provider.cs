namespace SuperMarket.Container.Vip.Provider;

using Entity;

//resolver : HZC
//asm file : VipContainerImpl
//impl :: SuperMarket.Container.Vip.Provider.VipProvider
//impl proj struct :
//src/container/provider.cs
public interface IVipProvider
{
    public IVipEntity? CreateVip
    (
        long level,
        double discount,
        double monthPrice
    );

    public IVipEntity? GetVip(long level);
    public List<IVipEntity> GetAllVip();
}