
namespace Application
{
    public interface ICommand
    {
        string Description { get; }
        string CommandName { get; }
        string Execute(string[] commandArguments);
    }
}
