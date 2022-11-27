namespace ToyRobot.Application.Validators;

public interface IPlacementValidator
{
    bool IsValidPlace(int x, int y);
    bool IsValidOnAxis(int pos);
}