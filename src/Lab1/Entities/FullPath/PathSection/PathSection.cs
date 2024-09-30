using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environments;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.PathSections;

public class PathSection
{
    public PathSection(int length, Environment environment)
    {
        Length = length;
        Environment = environment;
    }

    public int Length { get; protected set; }
    public Environment Environment { get; protected set; }
}