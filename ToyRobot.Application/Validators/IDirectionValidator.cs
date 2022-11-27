namespace ToyRobot.Application.Validators;

public interface IDirectionValidator
{
    /// <summary>
    /// Validate direction input to enum.
    /// </summary>
    /// <param name="input">string to validate</param>
    /// <returns>bool representing if input is valid direction</returns>
    bool IsValid(string input);
}