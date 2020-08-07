using ProgrammingBatch.FlappyBirdClone.Core;
using ProgrammingBatch.FlappyBirdClone.Event;

namespace ProgrammingBatch.FlappyBirdClone.Logic
{
    /// <summary>
    /// Class that handle tap flapping event
    /// </summary>
    public sealed class TapFlapHandler : IHandler
    {
        public event OnEventHandler HandleEvent;

        private GameStateHandler _gameStateHandler;
        private GameEnum _gameEnum;

        public TapFlapHandler(GameStateHandler gameStateHandler)
        {
            _gameStateHandler = gameStateHandler;
            _gameStateHandler.GameEvent += GameStateChangedEvent;
        }

        public void TriggerEvent(object data = null)
        {
            if(_gameEnum == GameEnum.Dead)
            {
                return;
            }

            HandleEvent();
        }

        private void GameStateChangedEvent(GameEnum gameEnum)
        {
            _gameEnum = gameEnum;
        }

        private void OnDestroy()
        {
            _gameStateHandler.GameEvent -= GameStateChangedEvent;
        }
    }
}