using UnityEngine;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime
{
    public sealed class GameField : MonoBehaviour
    {
        [SerializeField] private Transform firstCellPoint;
        [SerializeField] private Vector2 cellSize;
        [SerializeField] private int cellsCount = 100;
        [SerializeField] private int cellsInRow = 10;
        private Vector2[] _cellsPositions;
        
        public void FillCellsPositions()
        {
            _cellsPositions = new Vector2[cellsCount];
            var right = true;
            _cellsPositions[0] = firstCellPoint.position;

            for (var i = 1; i < _cellsPositions.Length; i++)
            {
                var needUp = i % cellsInRow == 0;
                if (needUp)
                {
                    right = !right;
                    _cellsPositions[i] = _cellsPositions[i - 1] + Vector2.up * cellSize.y;
                }
                else
                {
                    var xSign = right ? 1f : -1f;
                    var deltaX = xSign * cellSize.x;
                    _cellsPositions[i] = _cellsPositions[i - 1] + Vector2.right * deltaX;
                }
            }
        }
        
        public Vector2 GetCellPosition(int id)
        {
            if (id < 0 || id >= _cellsPositions.Length)
            {
                return Vector2.zero;
            }
            return _cellsPositions[id];
        }
    }
}