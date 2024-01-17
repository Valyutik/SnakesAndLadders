using PlayForge_Team.SnakesAndLadders.Runtime.Runtime.GameCubes;
using UnityEngine;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime
{
    public sealed class GameCubeThrower : MonoBehaviour
    {
        [SerializeField] private GameStateChanger gameStateChanger;
        [SerializeField] private Transform gameCubePoint;
        private GameCube _gameCubePrefab;
        private GameCube _gameCube;
        
        public void ThrowCube()
        {
            var cubeValue = _gameCube.ThrowCube();
            gameStateChanger.DoPlayerTurn(cubeValue);
        }

        private void Start()
        {
            _gameCubePrefab = Resources.Load<GameCube>("Prefabs/GameCube");
            CreateGameCube();
        }

        private void CreateGameCube()
        {
            _gameCube = Instantiate(_gameCubePrefab, gameCubePoint.position, gameCubePoint.rotation);
            _gameCube.HideCube();
        }
    }
}