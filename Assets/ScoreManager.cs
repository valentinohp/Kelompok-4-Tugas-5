using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.Grid;

namespace Paintastic.Pickable
{
    public class ScoreManager : MonoBehaviour
    {
        [SerializeField]
        private List<int> playersScore;
        [SerializeField]
        private List<int> playerTilesCount;
        private GridContainer _gridContainer;

    // Start is called before the first frame update
    void Start()
        {

            _gridContainer = GetComponent<GridContainer>();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateTiles();
        }

        public void AddPoint(int playerIndex)
        {

            playersScore[playerIndex] += playerTilesCount[playerIndex];
        }
        private void UpdateTiles()
        {
            playerTilesCount[3] = _gridContainer.P4Tile.Count;
            playerTilesCount[2] = _gridContainer.P3Tile.Count;
            playerTilesCount[1] = _gridContainer.P2Tile.Count;
            playerTilesCount[0] = _gridContainer.P1Tile.Count;
        }
    }
}

