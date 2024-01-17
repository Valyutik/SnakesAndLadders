using System;
using UnityEngine;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Transitions
{
    public sealed class TransitionSettings : MonoBehaviour
    {
        [SerializeField] private TransitionData[] transitionData = Array.Empty<TransitionData>();
        
        public int GetTransitionResultCellId(int startCellId)
        {
            foreach (var t in transitionData)
            {
                var resultCellId = t.GetTransitionResultCellId(startCellId);
                if (resultCellId >= 0)
                {
                    return resultCellId;
                }
            }

            return -1;
        }
    }
}