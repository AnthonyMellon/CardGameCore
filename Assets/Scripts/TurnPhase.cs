using CardGameCore.Controllers;
using ModestTree;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace CardGameCore.bases
{
    public abstract class TurnPhase
    {
        public Action OnPhaseStart;
        public Action OnPhaseEnd;        
        public string PhaseName;

        private List<Action> _startTriggers;
        private List<Action> _endTriggers;

        [Inject]
        private void Initialise(List<Action> startTriggers, List<Action> endTriggers)
        {
            _startTriggers = startTriggers;
            _endTriggers = endTriggers;

            for(int i = 0; i < _startTriggers.Count; i++)
            {
                _startTriggers[i] += StartPhase;
            }

            for (int i = 0; i < _endTriggers.Count; i++)
            {
                _endTriggers[i] += EndPhase;
            }
        }

        public void StartPhase()
        {
            ClearStartTriggers();
            OnPhaseStart?.Invoke();

            RunPhase();
        }

        protected virtual void RunPhase()
        {
            Debug.Log($"Running Phase {PhaseName}");
        }

        public void EndPhase()
        {
            ClearEndTriggers();
            OnPhaseEnd?.Invoke();
        }

        private void ClearStartTriggers()
        {
            for(int i = 0; i < _startTriggers.Count; i++)
            {
                _startTriggers[i] -= StartPhase;
            }
            _startTriggers = null;
        }

        private void ClearEndTriggers()
        {
            for (int i = 0; i < _endTriggers.Count; i++)
            {
                _endTriggers[i] -= EndPhase;
            }
            _endTriggers = null;
        }
        
        public class TurnPhaseFactory<T> : PlaceholderFactory<List<Action>, List<Action>, T> { };
    }
}
