namespace ProgrammingBatch.FlappyBirdClone
{
    public sealed class FlapCommand : ICommand
    {
        private IHandler _tapHandler;

        public FlapCommand(IHandler tapHandler)
        {
            _tapHandler = tapHandler;
        }

        public void Execute()
        {
            _tapHandler.TriggerEvent();
        }
    }
}