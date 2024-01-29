using UnityEngine;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime.GameCubes
{
    public sealed class GameCube : MonoBehaviour
    {
        [SerializeField] private Vector3[] cubeSidesEuler;
        
        public int ThrowCube()
        {
            var randomCubeValue = Random.Range(0, cubeSidesEuler.Length);
            RotateCube(cubeSidesEuler[randomCubeValue]);
            return randomCubeValue + 1;
        }

        private void RotateCube(Vector3 cubeEuler)
        {
            transform.eulerAngles = cubeEuler;
        }
    }
}