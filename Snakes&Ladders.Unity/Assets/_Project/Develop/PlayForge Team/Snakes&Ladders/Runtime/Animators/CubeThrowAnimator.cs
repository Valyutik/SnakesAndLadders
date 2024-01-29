using UnityEngine;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Animators
{
    public sealed class CubeThrowAnimator : MonoBehaviour
    {
        [SerializeField] private Animation cubeAnimation;
        [SerializeField] private GameCubeThrower gameCubeThrower;

        public void PlayAnimation()
        {
            cubeAnimation.Play();
        }

        public void OnAnimationEnd()
        {
            cubeAnimation.Stop();
            gameCubeThrower.ContinueAfterCubeAnimation();
        }
    }
}