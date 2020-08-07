using ProgrammingBatch.FlappyBirdClone.Core;
using ProgrammingBatch.FlappyBirdClone.Logic;
using System.Collections;
using UnityEngine;

namespace ProgrammingBatch.FlappyBirdClone.Scene
{
    public sealed class FireButtonComponent : MonoBehaviour
    {
        [SerializeField] private GameObject firePrefab = default;
        [SerializeField] private GameObject birdGameObject = default;

        private GameStateHandler _gameStateHandler;
        private GameEnum _gameEnum;

        public void OnInitialize(GameStateHandler gameStateHandler)
        {
            _gameStateHandler = gameStateHandler;
            _gameStateHandler.GameEvent += GameStateChangedEvent;
        }

        public void OnClick()
        {
            if (_gameEnum != GameEnum.Play)
            {
                return;
            }

            Instantiate(firePrefab, birdGameObject.transform.position, Quaternion.identity);
        }

        private IEnumerator LerpPosition(Vector3 target)
        {
            float _time = 0;
            float _percentage;

            float _duration = 1f;

            Vector3 _currentPosition = transform.localPosition;
            float _initialY = transform.localPosition.y;

            while (_time < _duration)
            {
                _time += Time.deltaTime;
                if (_time >= _duration)
                {
                    _time = _duration;
                }

                _percentage = _time / _duration;

                _currentPosition.y = Mathf.Lerp(_initialY, target.y, _percentage);
                transform.localPosition = _currentPosition;

                yield return null;
            }
        }

        private void GameStateChangedEvent(GameEnum gameEnum)
        {
            _gameEnum = gameEnum;
            switch (_gameEnum)
            {
                case GameEnum.Idle:
                    break;

                case GameEnum.Play:
                    StartCoroutine(LerpPosition(new Vector3(0, -200, 0)));
                    break;

                case GameEnum.Dead:
                    StartCoroutine(LerpPosition(new Vector3(0, -800, 0)));
                    break;
            }
        }

        private void OnDestroy()
        {
            _gameStateHandler.GameEvent -= GameStateChangedEvent;
        }
    }
}