using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPhaseOrder", menuName = "Card Game Base/Phases/Phase Order")]
public class PhaseOrder : ScriptableObject
{
    public List<GAConstants.TurnPhase> order = new List<GAConstants.TurnPhase>()
    {

    };
}
