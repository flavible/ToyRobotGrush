using Autofac;
using Autofac.Extensions.DependencyInjection;
using ToyRobot.Application.Services;
using ToyRobot.Console.DependencyInjection;
using ToyRobot.Domain;

var serviceProvider = AutofacModule.InitiateDependencyInjection();
var commandService = (ICommandService) serviceProvider.GetRequiredService(typeof(ICommandService));

var robot = new Robot();

Console.WriteLine("Welcome to Toy Robot, enter a command to continue");

while (true)
{
    var command = Console.ReadLine().Trim().Split(" ");
    commandService.CommandRobot(command, robot);
}
