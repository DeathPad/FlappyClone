using UnityEngine;

namespace ProgrammingBatch.FlappyBirdClone
{
    public sealed class PipeComponent : MonoBehaviour
    {
        [Tooltip("Top Side of the Pipe ")] [SerializeField] private Transform topPipe = default;
        [Tooltip("Bottom Side of the Pipe ")] [SerializeField] private Transform bottomPipe = default;

        [Tooltip("Gap size between top and bottom")] [SerializeField] private float gapSize = 0.8f;

        [Tooltip("Randomize noise")] [SerializeField] private float randomizeNoise = 0.2f;

        private void Start()
        {
            float _newGap = UnityEngine.Random.Range(gapSize - randomizeNoise, gapSize + randomizeNoise);

            topPipe.transform.position += Vector3.up * (_newGap / 2);
            bottomPipe.transform.position += Vector3.down * (_newGap / 2);
        }
    }
}