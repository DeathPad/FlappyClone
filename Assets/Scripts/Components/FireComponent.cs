using System.Collections;
using UnityEngine;

namespace ProgrammingBatch.FlappyBirdClone
{
    public sealed class FireComponent : MonoBehaviour
    {
        private void Start()
        {
            StartCoroutine("LerpFoward");

        }

        private IEnumerator LerpFoward()
        {
            float _time = 0;
            float _percentage;
            float _duration = 1f;

            Vector3 _currentPosition = transform.position, initialPosition = transform.position, _endPosition = new Vector3(4, 0, 0);
            while(_time < _duration)
            {
                _time += Time.deltaTime;
                if(_time >= _duration)
                {
                    _time = _duration;
                }

                _percentage = _time / _duration;
                _currentPosition.x = Mathf.Lerp(initialPosition.x, _endPosition.x, _percentage);
                transform.position = _currentPosition;

                yield return null;
            }

            Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.name.Contains("Renderer"))
            {
                Destroy(other.transform.parent.gameObject);
                Destroy(gameObject);
            }
        }
    }
}