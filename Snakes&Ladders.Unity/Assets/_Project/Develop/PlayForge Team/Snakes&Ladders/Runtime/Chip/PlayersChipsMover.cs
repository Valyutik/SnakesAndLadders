using PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Transitions;
using UnityEngine;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Chip
{
    public sealed class PlayersChipsMover : MonoBehaviour
    {
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
            _playersChipsCellsIds[playerId] += steps;

            if (_playersChipsCellsIds[playerId] >= gameField.CellsCount)
            {
                _playersChipsCellsIds[playerId] = gameField.CellsCount - 1;
            }

            TryApplyTransition(playerId);

            RefreshChipPosition(playerId);
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