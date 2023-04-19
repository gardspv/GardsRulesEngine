
namespace RuleEngineCalledV2;

public class Program
{
    public static void Main(string[] args)
    {
        var cat = new RuleEngine.RuleEngine.Cat("grey", 17.1, 11);
        var result = RuleEngine.CatRules.checkBusinessObject<RuleEngine.RuleEngine.Cat>(cat);
        Console.WriteLine(result);
    }
}