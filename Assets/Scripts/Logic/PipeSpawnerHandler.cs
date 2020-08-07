using System.Threading.Tasks;
using ProgrammingBatch.FlappyBirdClone.Core;
using ProgrammingBatch.FlappyBirdClone.Event;
namespace ProgrammingBatch.FlappyBirdClone.Logic
{
    public sealed class PipeSpawnerHandler : IHandler
    {
        public event OnEventHandler HandleEvent;

        //in ms
        private const int GAME_CALM_DURATION = 3000; //duration before pipe start spawning
        private const int PIPE_SPAWN_INTERVAL = 1000;

#pragma warning disable IDE0052 // Remove unread private members
        private Task _spawnTask;
#pragma warning restore IDE0052 // Remove unread private members

        private GameEnum _gameEnum;

        private GameStateHandler _gameStateHandler;

        public PipeSpawnerHandler(GameStateHandler gameStateHandler)
        {
            _gameStateHandler = gameStateHandler;
            _gameStateHandler.GameEvent += GameStateChangedEvent;
        }

        //Trigger event that spawning pipes
        public void TriggerEvent(object data = null)
        {
            HandleEvent();
        }

        private void GameStateChangedEvent(GameEnum newEnum)
        {
            _gameEnum = newEnum;

            if (_gameEnum == GameEnum.Play)
            {
                _spawnTask = SpawnPipe();
            }
        }

        private async Task SpawnPipe()
        {
            await Task.Delay((int)GAME_CALM_DURATION);

            while (_gameEnum == GameEnum.Play)
            {
                TriggerEvent();
                await Task.Delay((int)PIPE_SPAWN_INTERVAL);
            }
        }

        ~PipeSpawnerHandler()
        {
            _gameStateHandler.GameEvent -= GameStateChangedEvent;
        }
    }
}