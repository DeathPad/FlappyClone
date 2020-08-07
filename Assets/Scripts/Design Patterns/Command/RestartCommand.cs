using ProgrammingBatch.FlappyBirdClone.Core;
using ProgrammingBatch.FlappyBirdClone.Logic;

namespace ProgrammingBatch.FlappyBirdClone
{
    public sealed class RestartCommand : ICommand
    {
        private GameStateHandler _gameStateHandler;

        public RestartCommand(GameStateHandler gameStateHandler)
        {
            _gameStateHandler = gameStateHandler;
        }

        public void Execute()
        {
            _gameStateHandler.StateChanged(Core.GameEnum.Play);
        }
    }
}