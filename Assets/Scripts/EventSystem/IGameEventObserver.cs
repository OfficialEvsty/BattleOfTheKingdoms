namespace BattleOfKingdoms.EventSystems
{
    public interface IGameEventObserver<GameEvent> : IGameEventObserverBase where GameEvent : struct 
    {
        void OnGameEvent(GameEvent gameEvent);
    }
}