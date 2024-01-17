using PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Animator;
using PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Transitions;
using UnityEngine;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Chip
{
    public sealed class PlayersChipsMover : MonoBehaviour
    {
        [SerializeField] private PlayersChipsAnimator playersChipsAnimator;
        [SerializeField] private GameField gameField;
        [SerializeField] private TransitionSettings transitionSettings;
        private PlayerChip[] _playersChips;
        private int[] _playersChipsCellsIds;
        
        public void StartGame(PlayerChip[] playersChips)
        {
            _playersChips = playersChips;
            _playersChipsCellsIds = new int[playersChips.Length];
            RefreshChipsPositions();
        }
        
        public void MoveChip(int playerId, int steps)
        {
            var startCellId = _playersChipsCellsIds[playerId];
            _playersChipsCellsIds[playerId] += steps;
            if (_playersChipsCellsIds[playerId] >= gameField.CellsCount)
            {
                _playersChipsCellsIds[playerId] = gameField.CellsCount - 1;
            }
            var lastCellId = _playersChipsCellsIds[playerId];
            TryApplyTransition(playerId);
            var afterTransitionCellId = _playersChipsCellsIds[playerId];
            var movementCells = GetMovementCells(startCellId, lastCellId, afterTransitionCellId);
            playersChipsAnimator.AnimateChipMovement (_playersChips[playerId], movementCells);
        }
        
        public bool CheckPlayerFinished(int playerId)
        {
            return _playersChipsCellsIds[playerId] >= gameField.CellsCount - 1;
        }
        
        private int[] GetMovementCells(int startCellId, int lastCellId, int afterTransitionCellId)
        {
            var cellsCount = lastCellId - startCellId + 1;
            var hasTransition = lastCellId != afterTransitionCellId;

            if (hasTransition)
            {
                cellsCount++;
            }

            var movementCells = new int[cellsCount];

            for (var i = 0; i < movementCells.Length; i++)
            {
                if (i == movementCells.Length - 1 && hasTransition)
                {
                    movementCells[i] = afterTransitionCellId;
                }
                else
                {
                    movementCells[i] = startCellId + i;
                }
            }
            return movementCells;
        }

        private void RefreshChipsPositions()
        {
            for (var i = 0; i < _playersChips.Length; i++)
            {
                RefreshChipPosition(i);
            }
        }
        
        private void TryApplyTransition(int playerId)
        {
            var resultCellId = transitionSettings.GetTransitionResultCellId(_playersChipsCellsIds[playerId]);

            if (resultCellId < 0)
            {
                return;
            }

            _playersChipsCellsIds[playerId] = resultCellId;
        }

        private void RefreshChipPosition(int playerId)
        {
            var chipPosition = gameField.GetCellPosition(_playersChipsCellsIds[playerId]);
            _playersChips[playerId].SetPosition(chipPosition);
        }
    }
}