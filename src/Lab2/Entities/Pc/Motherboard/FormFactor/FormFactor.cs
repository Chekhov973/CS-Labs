using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Pc.Motherboard;

public class FormFactor
{
    public FormFactor(string formFactor)
    {
        if (string.IsNullOrEmpty(formFactor))
            throw FormFactorException.InvalidFormFactorNameException();

        Name = formFactor;
    }

    public FormFactor()
    {
        Name = string.Empty;
    }

    public string Name { get; }
}