using ProgrammingBatch.FlappyBirdClone.Core;
using ProgrammingBatch.FlappyBirdClone.Logic;
using TMPro;
using UnityEngine;

namespace ProgrammingBatch.FlappyBirdClone.Scene
{
    public sealed class ScoreComponent : MonoBehaviour
    {
        [Tooltip("Text renderer for showing player current score")] [SerializeField] private TextMeshProUGUI textMeshPro = default;

        private IHandler _scoreHandler;
        private GameStateHandler _gameStateHandler;
        public void OnInitialize(IHandler scoreHandler, GameStateHandler gameStateHandler)
        {
            _scoreHandler = scoreHandler;
            _gameStateHandler = gameStateHandler;

            _scoreHandler.HandleEvent += OnScoreEvent;
            _gameStateHandler.GameEvent += GameStateChangedEvent;
        }

        private void GameStateChangedEvent(GameEnum gameEnum)
        {
            if (gameEnum == GameEnum.Play)
                textMeshPro.text = "0";
        }

        private void OnScoreEvent(object value = null)
        {
            textMeshPro.text = $"{(int)value}";
        }

        private void OnDestroy()
        {
            _scoreHandler.HandleEvent -= OnScoreEvent;
        }
    }
}