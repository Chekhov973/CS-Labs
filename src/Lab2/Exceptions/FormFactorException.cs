using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class FormFactorException : Exception
{
    private FormFactorException(string message)
        : base(message)
    {
    }

    private FormFactorException()
    {
    }

    private FormFactorException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public static FormatException InvalidFormFactorNameException()
    {
        throw new FormatException($"Form factor name is invalid");
    }
}