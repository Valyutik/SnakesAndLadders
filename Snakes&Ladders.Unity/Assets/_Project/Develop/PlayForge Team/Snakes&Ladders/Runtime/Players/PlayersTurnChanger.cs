using PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Chip;
using UnityEngine;
using TMPro;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Players
{
    public sealed class PlayersTurnChanger : MonoBehaviour
    {
        [SerializeField] private TMP_Text playerText;
        private PlayerChip[] _playersChips;
        private int _currentPlayerId;
        
        public void StartGame(PlayerChip[] playersChips)
        {
            _playersChips = playersChips;
            _currentPlayerId = -1;
            MovePlayerTurn();
        }

        public int GetCurrentPlayerId()
        {
            return _currentPlayerId;
        }

        public void MovePlayerTurn()
        {
            _currentPlayerId++;
            if(_currentPlayerId >= _playersChips.Length)
            {
                _currentPlayerId = 0;
            }
            SetPlayerText(_currentPlayerId);
        }

        private void SetPlayerText(int playerId)
        {
            playerText.text = $"Игрок {playerId + 1}";
        }
    }
}