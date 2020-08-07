using UnityEngine;
using UnityEngine.EventSystems;

namespace ProgrammingBatch.FlappyBirdClone.Core
{
    public abstract class SceneController : MonoBehaviour
    {
        [SerializeField] private EventSystem eventSystem = default;

        /// <summary>
        /// Used to show player some visual before game processing<br></br>
        /// Ex. show loading screen.
        /// </summary>
        public virtual void Introduction() { }

        /// <summary>
        /// Initialize core modules, general features
        /// </summary>
        public abstract void InitializeCoreModules();
        /// <summary>
        /// Initialize game exclusive manager, controller or features
        /// </summary>
        public abstract void InitializeGameModules();

        /// <summary>
        /// Initialize all script that attached to gameobjects(component)
        /// </summary>
        public virtual void InitializeSceneComponents() { }
        
        /// <summary>
        /// allowed to do abstract proccess here
        /// </summary>
        public virtual void OnStartInitialized() { }
        
        /// <summary>
        /// Show disable visual effect in Introduction function or disable unused scripts
        /// </summary>
        public virtual void StartCompleted() { }


        private void Start()
        {
            eventSystem.enabled = false; //dont allow input while core not finished initializing

            InitializeCoreModules();
            InitializeGameModules();

            InitializeSceneComponents();
            OnStartInitialized();

            StartCompleted();

            eventSystem.enabled = true;
        }

        private void Update()
        {
        }
    }
}