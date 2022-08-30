using Paintastic.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Grid
{
    public class GridContainer : MonoBehaviour
    {
        [SerializeField] public List<GameObject> Poles;

        [SerializeField] public List<GameObject> P1Tile;

        [SerializeField] public List<GameObject> P2Tile;

        [SerializeField] public List<GameObject> P3Tile;

        [SerializeField] public List<GameObject> P4Tile;

        [SerializeField] private GameObject _mainCamera;

        public void AddToList(GameObject pole, int size)
        {
            Poles.Add(pole);
            if (Poles.Count == (size * size))
            {
                PlayerSpawn spawnplayer = gameObject.GetComponent<PlayerSpawn>();
                spawnplayer.SpawnPlayer(Poles[0], Poles[0], size);

                SetCamPos(Poles[0], Poles[size - 1]);
            }
        }

        private void SetCamPos(GameObject A, GameObject B)
        {
            CameraManager cameramanager = _mainCamera.GetComponent<CameraManager>();
            cameramanager.SetGridCenter(A, B);
        }
    }
}

