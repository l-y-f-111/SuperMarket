namespace SuperMarket.Container.Goods.Entity;

//resolver : ZTY
//asm file : GoodsContainerImpl
//impl :: SuperMarket.Container.Goods.Entity.GoodsEntity
//impl proj struct :
//src/container/entity.cs
public interface IGoodsEntity
{
    /// <summary>
    /// 释放实体
    /// </summary>
    /// <returns></returns>
    public bool Drop();

    /// <summary>
    /// 实体是否合法
    /// </summary>
    /// <returns></returns>
    public bool IsValid();

    public long Id { get; }

    public string? Name { get; set; }
    public bool IsReady { get; set; }

    public List<string> Types { get; }
    public bool AddType(string name);
    public bool RemoveType(string name);
    public bool ClearType();

    public double Price { get; set; }

    public string? CoverImg { get; set; }
    public string? PreviewVideoUrl { get; set; }
    public long Stock { get; set; }
}