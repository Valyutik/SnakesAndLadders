using UnityEngine;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Transitions
{
    public sealed class TransitionData : MonoBehaviour
    {
        [SerializeField] private int[] cellsStartIds;
        [SerializeField] private int[] cellsEndIds;
        
        public int GetTransitionResultCellId(int cellId)
        {
            for (var i = 0; i < cellsStartIds.Length; i++)
            {
                if (cellsStartIds[i] == cellId)
                {
                    return cellsEndIds[i];
                }
            }
            return -1;
        }
    }
}