using ProgrammingBatch.FlappyBirdClone.Core;
using ProgrammingBatch.FlappyBirdClone.Event;
namespace ProgrammingBatch.FlappyBirdClone.Logic
{
    public sealed class GameStateHandler 
    {
        public event GameEventHandler GameEvent;

        public GameStateHandler()
        {

        }

        public void StateChanged(GameEnum newEnum)
        {
            GameEvent(newEnum);
        }
    }
}