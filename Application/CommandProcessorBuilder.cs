using Application.Commands;

namespace Application
{
    public class CommandProcessorBuilder
    {
        private CommandProcessor _commandProcessor = new CommandProcessor();
        public CommandProcessor Build()
        {
            _commandProcessor.RegisterCommand(new HelpCommand(_commandProcessor.commands));
            return _commandProcessor;
        }

        public CommandProcessorBuilder RegisterCommand(ICommand command)
        {
            _commandProcessor.RegisterCommand(command);
            return this;
        }
    }
}
