using UnityEngine;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Animators
{
    public sealed class CubeThrowAnimator : MonoBehaviour
    {
        private static readonly int Throw = Animator.StringToHash("Throw");
        
        [SerializeField] private Animator cubeAnimation;
        [SerializeField] private GameCubeThrower gameCubeThrower;

        public void PlayAnimation()
        {
            cubeAnimation.SetTrigger(Throw);
        }

        public void OnAnimationEnd()
        {
            gameCubeThrower.ContinueAfterCubeAnimation();
        }
    }
}