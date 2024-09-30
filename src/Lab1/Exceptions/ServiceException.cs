using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.PathSections;

namespace Itmo.ObjectOrientedProgramming.Lab1.Exceptions;

public class ServiceException : Exception
{
    private ServiceException()
    {
    }

    private ServiceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    private ServiceException(string message)
             : base(message)
    {
    }

    public static ServiceException ShipIsAlreadyInList(Ship ship)
    {
        throw new ServiceException($"Ship {ship} is already added to list");
    }

    public static ServiceException FullPathIsAlreadyInList(PathSection pathSection)
    {
        throw new ServiceException($"Full path {pathSection} is already added to list");
    }

    public static ServiceException InvalidEnvironmentException()
    {
        throw new ServiceException($"Invalid environment and engine combination");
    }
}