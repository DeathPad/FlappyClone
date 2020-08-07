using ProgrammingBatch.FlappyBirdClone.Core;
using ProgrammingBatch.FlappyBirdClone.Logic;
using UnityEngine;

namespace ProgrammingBatch.FlappyBirdClone.Scene
{
    public sealed class BirdComponent : MonoBehaviour
    {
        [Tooltip("Body-Physic of the bird")] [SerializeField] private Rigidbody2D rigidbody2d = default;
        [Tooltip("Jump force that keep bird away from ground")] [SerializeField] private float jumpForce = 90;
        
        private IHandler _inputHandler;

        private GameStateHandler _gameStateHandler;
        private GameEnum _gameEnum;

        public void OnInitialized(IHandler inputHandler, GameStateHandler gameStateHandler)
        {
            _inputHandler = inputHandler;
            _gameStateHandler = gameStateHandler;

            _inputHandler.HandleEvent += Flapping;
            _gameStateHandler.GameEvent += GameStateChangedEvent;
        }

        private void Flapping(object value = null)
        {
            rigidbody2d.AddForce(new Vector2(0, jumpForce));
        }

        private void OnDestroy()
        {
            _inputHandler.HandleEvent -= Flapping;
            _gameStateHandler.GameEvent -= GameStateChangedEvent;
        }

        private void GameStateChangedEvent(GameEnum gameEnum)
        {
            _gameEnum = gameEnum;

            switch(_gameEnum)
            {
                case GameEnum.Idle:
                    rigidbody2d.constraints = RigidbodyConstraints2D.FreezePositionY;
                    break;

                case GameEnum.Play:
                    transform.position = Vector3.zero;
                    rigidbody2d.angularVelocity = 0;
                    transform.rotation = Quaternion.identity;
                    rigidbody2d.constraints = RigidbodyConstraints2D.None;
                    break;

                case GameEnum.Dead:
                    rigidbody2d.velocity = Vector2.zero;
                    rigidbody2d.constraints = RigidbodyConstraints2D.FreezePositionX;
                    break;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(_gameEnum != GameEnum.Play)
            {
                return;
            }

            if(collision.collider.tag == "Obstacle")
            {
                _gameStateHandler.StateChanged(Core.GameEnum.Dead);
            }
        }
    }
}