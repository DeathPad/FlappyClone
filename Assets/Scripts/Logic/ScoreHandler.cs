using ProgrammingBatch.FlappyBirdClone.Core;
using ProgrammingBatch.FlappyBirdClone.Event;

namespace ProgrammingBatch.FlappyBirdClone.Logic
{
    public sealed class ScoreHandler : IHandler
    {
        public event OnEventHandler HandleEvent;

        private GameStateHandler _gameStateHandler;
        private GameEnum _gameEnum;

        private int _scoreAmount = 0;
        //private int _bestScore = 0;

        public ScoreHandler(GameStateHandler gameStateHandler)
        {
            _gameStateHandler = gameStateHandler;

            _gameStateHandler.GameEvent += GameStateChangedEvent;
        }

        public void TriggerEvent(object data = null)
        {
            _scoreAmount += 1;
            HandleEvent(_scoreAmount);
        }

        private void GameStateChangedEvent(GameEnum newEnum)
        {
            _gameEnum = newEnum;

            _scoreAmount = 0;
            if (_gameEnum == GameEnum.Play)
            {
                return;
            }
        }

        ~ScoreHandler()
        {
            _gameStateHandler.GameEvent -= GameStateChangedEvent;
        }
    }
}