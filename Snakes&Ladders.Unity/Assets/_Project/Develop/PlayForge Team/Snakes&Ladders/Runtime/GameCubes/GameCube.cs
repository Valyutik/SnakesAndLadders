using UnityEngine;

namespace PlayForge_Team.SnakesAndLadders.Runtime.Runtime.GameCubes
{
    public sealed class GameCube : MonoBehaviour
    {
        [SerializeField] private Vector3[] cubeSidesEulers;
        
        public void ShowCube()
        {
            SetActiveCube(true);
        }

        public void HideCube()
        {
            SetActiveCube(false);
        }

        private void SetActiveCube(bool value)
        {
            gameObject.SetActive(value);
        }
        
        public int ThrowCube()
        {
            ShowCube();
            var randomCubeValue = Random.Range(0, cubeSidesEulers.Length);
            RotateCube(cubeSidesEulers[randomCubeValue]);
            return randomCubeValue + 1;
        }

        private void RotateCube(Vector3 cubeEuler)
        {
            transform.eulerAngles = cubeEuler;
        }
    }
}