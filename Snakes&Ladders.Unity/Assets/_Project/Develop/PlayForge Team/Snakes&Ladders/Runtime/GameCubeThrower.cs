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
            _cubeValue = gameCubePoint.ThrowCube();
            cubeThrowAnimator.PlayAnimation();
        }
        
        public void ContinueAfterCubeAnimation()
        {
            gameStateChanger.DoPlayerTurn(_cubeValue);
        }

        private void Start()
        {
            CreateGameCube();
        }

        private void CreateGameCube()
        {
            gameCubePoint.HideCube();
        }
    }
}