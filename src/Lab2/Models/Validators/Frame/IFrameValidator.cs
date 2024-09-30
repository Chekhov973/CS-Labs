using Itmo.ObjectOrientedProgramming.Lab2.Entities.Frames;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IFrameValidator
{
    public void CheckImportValid(Frame frame);
}