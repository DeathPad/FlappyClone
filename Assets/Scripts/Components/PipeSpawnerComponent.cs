using ProgrammingBatch.FlappyBirdClone.Core;
using ProgrammingBatch.FlappyBirdClone.Logic;
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

namespace ProgrammingBatch.FlappyBirdClone.Scene
{
    public sealed class PipeSpawnerComponent : MonoBehaviour
    {
        [Tooltip("Prefab of pipe, that will be spawned to the scene")] [SerializeField] private GameObject pipePrefab = default;
        [Space]
        [Tooltip("Right side of the screen, where the pipes will start spawning")] [SerializeField] private Vector3 defaultSpawnPoint = default;
        [Tooltip("Left side, location to despawn pipes")] [SerializeField] private Vector3 defaultEndPoint = default;
        [Space]
        [Tooltip("Duration from right to left")] [SerializeField] private float pipeLerpDuration = 1f;
        [Tooltip("Randomize clamp height")] [SerializeField] private float randomClampHeight = 0.3f;

        [Tooltip("Parent of all spawned pipes")] [SerializeField] private GameObject pipeParent = default;

        private GameStateHandler _gameStateHandler;
        private IHandler _pipeSpawnerHandler;

        private GameEnum _gameEnum;

        public void OnInitialize(GameStateHandler gameStateHandler, IHandler pipeSpawnerHandler)
        {
            _gameStateHandler = gameStateHandler;
            _pipeSpawnerHandler = pipeSpawnerHandler;

            _gameStateHandler.GameEvent += OnGameStateChanged;
            _pipeSpawnerHandler.HandleEvent += OnPipeSpawnEvent;
        }

        private void OnGameStateChanged(GameEnum gameEnum)
        {
            _gameEnum = gameEnum;

            if(_gameEnum != GameEnum.Play)
            {
                StopAllCoroutines();
            } else
            {
                foreach(Transform _pipe in pipeParent.transform)
                {
                    Destroy(_pipe.gameObject);
                }
            }
        }

        private void OnPipeSpawnEvent(object value = null)
        {
            GameObject _pipe = Instantiate(pipePrefab, defaultSpawnPoint, Quaternion.identity);
            _pipe.transform.parent = pipeParent.transform;

            _pipe.transform.position += Vector3.up * Mathf.Sin(Time.time) * UnityEngine.Random.Range(1 - randomClampHeight, 1 + randomClampHeight) * 0.5f;
            StartCoroutine(PipeCycle(_pipe));
        }

        private IEnumerator PipeCycle(GameObject objectToLerp)
        {
            float _time = 0;
            float _percentage;

            Vector3 _objectCurrentPosition = objectToLerp.transform.position;

            while (_time < pipeLerpDuration)
            {
                _time += Time.deltaTime;
                if (_time >= pipeLerpDuration)
                {
                    _time = pipeLerpDuration;
                }

                _percentage = _time / pipeLerpDuration;

                _objectCurrentPosition.x = Mathf.Lerp(defaultSpawnPoint.x, defaultEndPoint.x, _percentage);
                try { objectToLerp.transform.position = _objectCurrentPosition; }
                catch (Exception e) { break; }

                yield return null; //next frame
            }

            try { Destroy(objectToLerp); }
            catch(Exception) { }
        }

        private void OnDestroy()
        {
            _gameStateHandler.GameEvent -= OnGameStateChanged;
            _pipeSpawnerHandler.HandleEvent -= OnPipeSpawnEvent;
        }
    }
}

//object pooling? DoTween?