using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.Grid;

namespace Paintastic.Pickable
{
    public class ScoreManager : MonoBehaviour
    {
        public List<int> playersScore;
     
        private GridContainer _gridContainer;

    // Start is called before the first frame update
    void Start()
        {
            CreateScoreIndex();
            _gridContainer = GetComponent<GridContainer>();
        }

        // Update is called once per frame
        void Update()
        {
           
        }

        public void AddPoint(int playerIndex)
        {
            switch (playerIndex)
            {
                case 3:
                    playersScore[playerIndex] += _gridContainer.P4Tile.Count;
                    break;
                case 2:
                    playersScore[playerIndex] += _gridContainer.P3Tile.Count;
                    break;
                case 1:
                    playersScore[playerIndex] += _gridContainer.P2Tile.Count;
                    break;
                case 0:
                    playersScore[playerIndex] += _gridContainer.P1Tile.Count;
                    break;
                default:
                    Debug.Log("wrong player index");
                    break;

            }
        }

        private void CreateScoreIndex()
        {
            for(int i = 0; i < 4; i++)
            {
                playersScore.Add(0);
            }
        }
    }
}

