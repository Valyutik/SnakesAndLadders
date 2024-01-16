using UnityEngine;
using System;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Chip
{
    public sealed class PlayersChipsCreator : MonoBehaviour
    {
        [SerializeField] private Sprite[] playerChipSprites = Array.Empty<Sprite>();
        [SerializeField] private PlayerChip playerChipPrefab;
        private PlayerChip[] _playersChips;
        
        public PlayerChip[] SpawnPlayersChips(int count)
        {
            _playersChips = new PlayerChip[count];

            for (var i = 0; i < count; i++)
            {
                if (i >= playerChipSprites.Length)
                {
                    break;
                }
                _playersChips[i] = SpawnPlayerChip(playerChipSprites[i]);
            }
            return _playersChips;
        }

        private PlayerChip SpawnPlayerChip(Sprite sprite)
        {
            if (!sprite)
            {
                return null;
            }

            var tr = transform;
            var newPlayerChip = Instantiate(playerChipPrefab, tr.position, tr.rotation);
            newPlayerChip.SetSprite(sprite);
            return newPlayerChip;
        }
    }
}