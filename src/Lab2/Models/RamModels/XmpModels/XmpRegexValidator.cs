using System.Text.RegularExpressions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class XmpRegexValidator : IXmpValidator
{
    private static readonly Regex XmpRegex = new(@"[1-9][1-9]-[1-9][1-9]-[1-9][1-9]-[1-9][1-9]", RegexOptions.Compiled);

    public bool IsXmpValid(string xmpName)
    {
        return XmpRegex.IsMatch(xmpName);
    }
}