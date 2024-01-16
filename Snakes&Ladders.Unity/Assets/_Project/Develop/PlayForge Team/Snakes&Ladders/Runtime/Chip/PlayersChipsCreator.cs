using UnityEngine;
using System;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Chip
{
    public sealed class PlayersChipsCreator : MonoBehaviour
    {
        [SerializeField] private Sprite[] playerChipSprites = Array.Empty<Sprite>();
        private PlayerChip[] _playersChips;
        private PlayerChip _playerChipPrefab;
        
        private void Start()
        {
            _playerChipPrefab = Resources.Load<PlayerChip>("Prefabs/Chips/Chip");
        }
        
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
            var newPlayerChip = Instantiate(_playerChipPrefab, tr.position, tr.rotation);
            newPlayerChip.SetSprite(sprite);
            return newPlayerChip;
        }
    }
}