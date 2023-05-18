namespace SuperMovie.Db.Goods.Model;

//resolver : ZTY
//asm file : GoodsDbImpl
//impl :: SuperMovie.Db.Goods.Model.GoodsModel
//impl proj struct :
//src/db/model.cs
public interface IGoodsModel
{
    public long Id { get; set; }
    public string Name { get; set; }
    public bool IsPreorder { get; set; }
    public List<string> Types { get; set; }
    public double Price { get; set; }
    public string CoverImg { get; set; }
    public string PreviewVideoUrl { get; set; }
}