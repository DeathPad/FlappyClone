using ProgrammingBatch.FlappyBirdClone.Logic;
using ProgrammingBatch.FlappyBirdClone.Scene;
using UnityEngine;

namespace ProgrammingBatch.FlappyBirdClone.Core
{
    public sealed class FlappyBirdSceneController : SceneController
    {
        [SerializeField] private TapComponent tapComponent = default;
        [SerializeField] private BirdComponent birdComponent = default;
        [SerializeField] private PipeSpawnerComponent pipeSpawnerComponent = default;
        [SerializeField] private ScoreComponent scoreComponent = default;
        [SerializeField] private PipeDetectorComponent pipeDetectorComponent = default;
        [SerializeField] private IntroUIComponent introUIComponent = default;
        [SerializeField] private RestartButtonComponent restartButtonComponent = default;
        [SerializeField] private FireButtonComponent fireButtonComponent = default;

        public override void InitializeCoreModules()
        {

        }

        public override void InitializeGameModules()
        {

        }

        public override void InitializeSceneComponents()
        {
            GameStateHandler _gameStateHandler = new GameStateHandler();

            IHandler _tapHandler = new TapFlapHandler(_gameStateHandler);
            IHandler _pipeSpawnerHandler = new PipeSpawnerHandler(_gameStateHandler);
            IHandler _scoreHandler = new ScoreHandler(_gameStateHandler);

            tapComponent.OnInitialize(_tapHandler, _gameStateHandler);
            birdComponent.OnInitialized(_tapHandler, _gameStateHandler);
            pipeSpawnerComponent.OnInitialize(_gameStateHandler, _pipeSpawnerHandler);
            scoreComponent.OnInitialize(_scoreHandler, _gameStateHandler);
            pipeDetectorComponent.OnInitialized(_scoreHandler);
            introUIComponent.OnInitialized(_gameStateHandler);
            restartButtonComponent.OnInitialize(_gameStateHandler);
            fireButtonComponent.OnInitialize(_gameStateHandler);

            _gameStateHandler.StateChanged(GameEnum.Idle);
        }
    }
}