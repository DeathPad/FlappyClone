using ProgrammingBatch.FlappyBirdClone.Core;
using ProgrammingBatch.FlappyBirdClone.Logic;
using UnityEngine;

namespace ProgrammingBatch.FlappyBirdClone.Scene
{
    public sealed class SoundComponent : MonoBehaviour
    {
        [SerializeField] private AudioClip tapSound = default;
        [SerializeField] private AudioClip deadSound = default;
        [SerializeField] private AudioClip fallSound = default;
        [SerializeField] private AudioClip scoreSound = default;

        [SerializeField] private AudioSource audioSource = default;

        private IHandler _tapHandler;
        private IHandler _scoreHandler;
        private GameStateHandler _gameStateHandler;

        public void SetTapSound(IHandler tapHandler)
        {
            _tapHandler = tapHandler;
            _tapHandler.HandleEvent += OnTapEvent;
        }
        public void SetScoreSound(IHandler scoreHandler)
        {
            _scoreHandler = scoreHandler;
            _scoreHandler.HandleEvent += OnScoreEvent;
        }

        public void SetDeadSound(GameStateHandler gameStateHandler)
        {
            _gameStateHandler = gameStateHandler;
            _gameStateHandler.GameEvent += GameStateChangedEvent;
        }

        private void OnTapEvent(object data = null)
        {
            audioSource.PlayOneShot(tapSound);
        }
        private void OnScoreEvent(object data = null)
        {
            audioSource.PlayOneShot(scoreSound);
        }
        private void GameStateChangedEvent(GameEnum gameEnum)
        {
            if (gameEnum == GameEnum.Dead)
            {
                audioSource.PlayOneShot(deadSound);
                audioSource.PlayOneShot(fallSound);
            }
        }
        private void OnDestroy()
        {
            _tapHandler.HandleEvent -= OnTapEvent;
            _scoreHandler.HandleEvent -= OnScoreEvent;
            _gameStateHandler.GameEvent -= GameStateChangedEvent;
        }
    }
}