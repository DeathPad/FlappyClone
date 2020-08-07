using ProgrammingBatch.FlappyBirdClone.Core;
using ProgrammingBatch.FlappyBirdClone.Logic;
using UnityEngine;

namespace ProgrammingBatch.FlappyBirdClone.Scene
{
    public sealed class IntroUIComponent : MonoBehaviour
    {
        private GameStateHandler _gameStateHandler;

        public void OnInitialized(GameStateHandler gameStateHandler)
        {
            _gameStateHandler = gameStateHandler;
            _gameStateHandler.GameEvent += GameStateChangedEvent;
        }

        private void GameStateChangedEvent(GameEnum gameEnum)
        {
            if(gameEnum == GameEnum.Play)
            {
                Destroy(gameObject);
            }
        }

        private void OnDestroy()
        {
            _gameStateHandler.GameEvent -= GameStateChangedEvent;
        }
    }
}