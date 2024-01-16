using UnityEngine;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Chip
{
    [RequireComponent(typeof(SpriteRenderer))]
    public sealed class PlayerChip : MonoBehaviour
    {
        public void SetSprite(Sprite sprite)
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = sprite;
        }
        
        public void SetPosition(Vector2 position)
        {
            transform.position = position;
        }
    }
}