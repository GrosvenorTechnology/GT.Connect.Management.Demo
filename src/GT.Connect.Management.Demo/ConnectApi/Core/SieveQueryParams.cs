
namespace GT.Connect.Management.Demo.ConnectApi.Core;

public class SieveQueryParams
{
    [AliasAs("page")]
    public int? Page { get; set; }

    [AliasAs("pagesize")]
    public int? PageSize { get; set; }

    [AliasAs("filters")]
    public string? FilterRendered => _filter?.ToString();

    private Filter? _filter;

    public SieveQueryParams()
    {

    }

    public SieveQueryParams(Filter filter)
    {
        _filter = filter;
    }

}


public record Filter(string Field, string Value, Operators Operator)
{
    public override string ToString()
    {
        return $"{Field}{RenderOperator(Operator)}{Value}";
    }

    private static string RenderOperator(Operators op) => op switch
    {
        Operators.Equals => "==",
        Operators.Notequals => "!=",
        Operators.Greaterthan => ">",
        Operators.Lessthan => "<",
        Operators.GreaterThanOorEqualTo => ">=",
        Operators.LessThanOrEqualTo => "<=",
        Operators.Contains => "@=",
        Operators.StartsWith => "_=",
        Operators.EndsWith => "_-=",
        Operators.DoesNotContains => "!@=",
        Operators.DoesNotStartsWith => "!_=",
        Operators.DoesNotEndsWith => "!_-=",
        Operators.CaseInsensitiveStringContains => "@=*",
        Operators.CaseInsensitiveStringStartsWith => "_=*",
        Operators.CaseInsensitiveStringEndsWith => "_-=*",
        Operators.CaseInsensitiveStringEquals => "==*",
        Operators.CaseInsensitiveStringNotEquals => "!=*",
        Operators.CaseInsensitiveStringDoesNotContains => "!@=*",
        Operators.CaseInsensitiveStringDoesNotStartsWith => "!_=*",
        _ => throw new NotImplementedException(),
    };
}
public enum Operators
{
    Equals,
    Notequals,
    Greaterthan,
    Lessthan,
    GreaterThanOorEqualTo,
    LessThanOrEqualTo,
    Contains,
    StartsWith,
    EndsWith,
    DoesNotContains,
    DoesNotStartsWith,
    DoesNotEndsWith,
    CaseInsensitiveStringContains,
    CaseInsensitiveStringStartsWith,
    CaseInsensitiveStringEndsWith,
    CaseInsensitiveStringEquals,
    CaseInsensitiveStringNotEquals,
    CaseInsensitiveStringDoesNotContains,
    CaseInsensitiveStringDoesNotStartsWith,
}
