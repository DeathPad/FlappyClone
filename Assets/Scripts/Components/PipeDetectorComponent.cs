using UnityEngine;

namespace ProgrammingBatch.FlappyBirdClone.Scene
{
    public sealed class PipeDetectorComponent : MonoBehaviour
    {
        private IHandler _scoreHandler;

        public void OnInitialized(IHandler scoreHandler)
        {
            _scoreHandler = scoreHandler;
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (col.tag != "Pipe")
            {
                return;
            }
            _scoreHandler.TriggerEvent();
        }
    }
}