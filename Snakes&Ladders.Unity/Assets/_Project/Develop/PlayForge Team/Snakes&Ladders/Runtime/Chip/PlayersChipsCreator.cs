using UnityEngine;
using System;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Chip
{
    public sealed class PlayersChipsCreator : MonoBehaviour
    {
        [SerializeField, Range(0,4)] private int playersCount = 2;
        [SerializeField] private Sprite[] playerChipSprites = Array.Empty<Sprite>();
        private PlayerChip _playerChipPrefab;
        
        private void Start()
        {
            _playerChipPrefab = Resources.Load<PlayerChip>("Prefabs/Chips/Chip");
            SpawnPlayersChips(playersCount);
        }

        private void SpawnPlayersChips(int count)
        {
            for (var i = 0; i < count; i++)
            {
                if (i >= playerChipSprites.Length)
                {
                    break;
                }

                SpawnPlayerChip(playerChipSprites[i]);
            }
        }
        
        private void SpawnPlayerChip(Sprite sprite)
        {
            if (!sprite)
            {
                return;
            }

            var currentTransform = transform;
            var newPlayerChip = Instantiate(_playerChipPrefab, currentTransform.position, currentTransform.rotation);

            newPlayerChip.SetSprite(sprite);
        }
    }
}