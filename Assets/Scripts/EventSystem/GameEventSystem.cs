using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleOfKingdoms.EventSystems
{
    public static class GameEventSystem
    {
        private static Dictionary<Type, List<IGameEventObserverBase>> m_subscribers = new Dictionary<Type, List<IGameEventObserverBase>>();

        public static void AddEventObserver<GameEvent>(IGameEventObserver<GameEvent> subscriber) where GameEvent : struct
        {
            if(m_subscribers.ContainsKey(typeof(GameEvent)))
                m_subscribers[typeof(GameEvent)].Add(subscriber);
            else
                m_subscribers.Add(typeof(GameEvent), new List<IGameEventObserverBase>() { subscriber });
        }

        public static void RemoveEventObserver<GameEvent>(IGameEventObserver<GameEvent> subscriber) where GameEvent : struct
        {
            m_subscribers[typeof(GameEvent)].Remove(subscriber);
        }

        public static void IssueGameEvent<GameEvent>(GameEvent gameEvent) where GameEvent : struct
        {
            var subscribers = m_subscribers[typeof(GameEvent)];
            foreach(var subscriber in subscribers)
            {
                ((IGameEventObserver<GameEvent>)subscriber).OnGameEvent(gameEvent);
            }
        }
    }
}

