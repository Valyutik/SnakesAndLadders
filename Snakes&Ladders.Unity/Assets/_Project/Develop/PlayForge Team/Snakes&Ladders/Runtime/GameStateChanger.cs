using PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Players;
using PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Chip;
using UnityEngine;
using TMPro;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime
{
    public sealed class GameStateChanger : MonoBehaviour
    {
        [SerializeField] private int playersCount = 2;
        [SerializeField] private PlayersChipsCreator playersChipsCreator;
        [SerializeField] private PlayersTurnChanger playersTurnChanger;
        [SerializeField] private PlayersChipsMover playersChipsMover;
        [SerializeField] private GameField gameField;
        [SerializeField] private GameObject gameScreenGo;
        [SerializeField] private GameObject gameEndScreenGo;
        [SerializeField] private TMP_Text winText;
        
        private void Start()
        {
            FirstStartGame();
        }
        
        public void DoPlayerTurn(int steps)
        {
            var currentPlayerId = playersTurnChanger.GetCurrentPlayerId();
            playersChipsMover.MoveChip(currentPlayerId, steps);
            var isPlayerFinished = playersChipsMover.CheckPlayerFinished(currentPlayerId);

            if (isPlayerFinished)
            {
                SetWinText(currentPlayerId);
                EndGame();
            }
            else
            {
                playersTurnChanger.MovePlayerTurn();
            }
        }
        
        public void RestartGame()
        {
            playersChipsCreator.Clear();
            StartGame();
        }
        
        private void FirstStartGame()
        {
            gameField.FillCellsPositions();
            StartGame();
        }

        private void StartGame()
        {
            var playersChips = playersChipsCreator.SpawnPlayersChips(playersCount);
            playersTurnChanger.StartGame(playersChips);
            playersChipsMover.StartGame(playersChips);
            SetScreens(true);
        }
        
        private void EndGame()
        {
            SetScreens(false);
        }
        
        private void SetScreens(bool inGame)
        {
            gameScreenGo.SetActive(inGame);
            gameEndScreenGo.SetActive(!inGame);
        }

        private void SetWinText(int playerId)
        {
            winText.text = $"Игрок {playerId + 1} победил!";
        }
    }
}