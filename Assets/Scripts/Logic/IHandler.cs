using ProgrammingBatch.FlappyBirdClone.Event;

namespace ProgrammingBatch.FlappyBirdClone
{
    public interface IHandler
    {
        event OnEventHandler HandleEvent;
        void TriggerEvent(object value = null);
    }
}