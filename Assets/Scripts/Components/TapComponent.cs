using ProgrammingBatch.FlappyBirdClone.Core;
using ProgrammingBatch.FlappyBirdClone.Logic;
using UnityEngine;

namespace ProgrammingBatch.FlappyBirdClone.Scene
{
    /// <summary>
    /// A component that invoke TapFlipCommand when clicked.
    /// </summary>
    public sealed class TapComponent : MonoBehaviour
    {
        private IHandler _tapHandler;

        private GameStateHandler _gameStateHandler;
        private GameEnum _gameEnum;

        private ICommand _tapFlapCommand;

        public void OnInitialize(IHandler tapFlapHandler, GameStateHandler gameStateHandler)
        {
            _tapHandler = tapFlapHandler;

            _gameStateHandler = gameStateHandler;
            _gameStateHandler.GameEvent += GameStateChangedEvent;

            _tapFlapCommand = new FlapCommand(_tapHandler);
        }

        private void GameStateChangedEvent(GameEnum gameEnum)
        {
            _gameEnum = gameEnum;
        }

        public void OnClick()
        {
            switch (_gameEnum)
            {
                case GameEnum.Idle:
                    _gameStateHandler.StateChanged(GameEnum.Play);
                    _tapFlapCommand.Execute();
                    break;

                case GameEnum.Play: 
                    _tapFlapCommand.Execute();
                    break;

                case GameEnum.Dead:
                    break;
            }
        }
    }
}