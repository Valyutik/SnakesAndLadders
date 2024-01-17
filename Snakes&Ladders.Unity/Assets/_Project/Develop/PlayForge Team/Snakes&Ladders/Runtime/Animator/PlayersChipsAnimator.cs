using PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Chip;
using UnityEngine;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Animator
{
    public sealed class PlayersChipsAnimator : MonoBehaviour
    {
        [SerializeField] private GameStateChanger GameStateChanger;
        [SerializeField] private GameField GameField;
        [SerializeField] private float CellMoveDuration = 0.3f;
        private PlayerChip _playerChip;
        private bool isAnimateNow;
        private int[] _movementCells;
        private int _currentCellId;
        private float _cellMoveTimer;
        private Vector2 _startPosition;
        private Vector2 _endPosition;
        
        private void Update()
        {
            Animate();
        }
        
        public void AnimateChipMovement(PlayerChip playerChip, int[] movementCells)
        {
            _playerChip = playerChip;
            _movementCells = movementCells;
            isAnimateNow = true;
            _currentCellId = -1;
            ToNextCell();
        }
        
        private void Animate()
        {
            if (!isAnimateNow)
            {
                return;
            }
            if(_cellMoveTimer >= 1)
            {
                ToNextCell();
            }
            _playerChip.SetPosition(Vector2.Lerp(_startPosition, _endPosition, _cellMoveTimer));
            _cellMoveTimer += Time.deltaTime / CellMoveDuration;
        }
        
        private void ToNextCell()
        {
            _currentCellId++;
            if(_currentCellId >= _movementCells.Length - 1)
            {
                EndAnimation();
                return;
            }
            _startPosition = GameField.GetCellPosition(_movementCells[_currentCellId]);
            _endPosition = GameField.GetCellPosition(_movementCells[_currentCellId + 1]);
            _cellMoveTimer = 0;
        }
        
        private void EndAnimation()
        {
            isAnimateNow = false;
            GameStateChanger.ContinueGameAfterChipAnimation();
        }
    }
}