using PlayForge_Team.SnakesAndLadders.Runtime.Runtime.Animators;
using PlayForge_Team.SnakesAndLadders.Runtime.Runtime.GameCubes;
using UnityEngine;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime
{
    public sealed class GameCubeThrower : MonoBehaviour
    {
        [SerializeField] private GameStateChanger gameStateChanger;
        [SerializeField] private GameCube gameCubePoint;
        [SerializeField] private CubeThrowAnimator cubeThrowAnimator;
        private int _cubeValue;
        private GameCube _gameCubePrefab;
        
        public void ThrowCube()
        {
            cubeThrowAnimator.PlayAnimation();
        }
        
        public void ContinueAfterCubeAnimation()
        {
            gameStateChanger.DoPlayerTurn(gameCubePoint.ThrowCube());
        }
    }
}