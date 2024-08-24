namespace Codebase.Infrastructure.States
{
    public interface IPayLoadedState : IExitableState
    {
        void Enter();
    }

    public interface IPayLoadedState<TPayLoad> : IExitableState
    {
        void Enter(TPayLoad payLoad);
    }

    public interface IExitableState
    {
        void Exit();
    }
}