using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.PathSections;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class FullPath
{
    private List<PathSection> _pathSections = new();

    public IReadOnlyCollection<PathSection> PathSections => _pathSections;

    public void AddPathSection(PathSection pathSection)
    {
        ArgumentNullException.ThrowIfNull(pathSection);

        _pathSections.Add(pathSection);
    }
}