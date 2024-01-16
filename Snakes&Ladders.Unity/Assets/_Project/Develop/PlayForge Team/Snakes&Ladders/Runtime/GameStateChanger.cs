using PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Chip;
using PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Players;
using UnityEngine;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime
{
    public sealed class GameStateChanger : MonoBehaviour
    {
        [SerializeField] private int playersCount = 2;
        [SerializeField] private PlayersChipsCreator playersChipsCreator;
        [SerializeField] private PlayersTurnChanger playersTurnChanger;
        [SerializeField] private PlayersChipsMover playersChipsMover;
        [SerializeField] private GameField gameField;
        
        public void DoPlayerTurn(int steps)
        {
            var currentPlayerId = playersTurnChanger.GetCurrentPlayerId();
            playersChipsMover.MoveChip(currentPlayerId, steps);
            playersTurnChanger.MovePlayerTurn();
        }

        private void Start()
        {
            StartGame();
        }

        private void StartGame()
        {
            gameField.FillCellsPositions();
            var playersChips = playersChipsCreator.SpawnPlayersChips(playersCount);
            playersTurnChanger.StartGame(playersChips);
            playersChipsMover.StartGame(playersChips);
        }
    }
}