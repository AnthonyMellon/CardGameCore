using CardGameCore.bases;
using GrandArchive.Phases;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Zenject;

namespace CardGameCore
{
    public abstract class Turn
    {
        public Action OnTurnStart;
        public Action OnTurnEnd;

        public Dictionary<GAConstants.TurnPhase, TurnPhase> phases;        

        protected void SetupTurn()
        {
            CreatePhases();
        }
        
        protected abstract void CreatePhases();        

        public void StartTurn()
        {
            OnTurnStart?.Invoke();
            RunTurn();
        }

        public virtual void RunTurn()
        {
            
        }

        public void EndTurn()
        {
            OnTurnEnd?.Invoke();
        }
    }
}
