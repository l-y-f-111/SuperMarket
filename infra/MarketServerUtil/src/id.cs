namespace MarketServerUtil;

using static pilipala.util.id.palaflake;

public enum ActionType
{
    Cinema = 0,
    Goods = 1,
    Order = 2,
    Schedule = 3,
}

public class IdGenerator
{
    private readonly Generator _gen;

    public IdGenerator(ActionType type)
    {
        _gen = new Generator((byte)type, 2023);
    }

    public long Next() => _gen.Next();
}

/*How to use:
 
using MarketServerUtil;
var gen = new IdGenerator(ActionType.Schedule);
Console.WriteLine(gen.Next());
*/