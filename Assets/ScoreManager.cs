using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.Grid;
using Paintastic.Pickable;

namespace Paintastic.Score
{
    public class ScoreManager : MonoBehaviour
    {
        public List<int> playersScore;
     
        private GridContainer _gridContainer;

        public List<bool> _isDoubleScore;


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
            int multiplier = 1;
            if(_isDoubleScore[playerIndex] == true)
            {
                multiplier = 2;
            }
            switch (playerIndex)
            {
                case 3:
                    playersScore[playerIndex] += _gridContainer.P4Tile.Count * multiplier;
                    break;
                case 2:
                    playersScore[playerIndex] += _gridContainer.P3Tile.Count * multiplier;
                    break;
                case 1:
                    playersScore[playerIndex] += _gridContainer.P2Tile.Count * multiplier;
                    break;
                case 0:
                    playersScore[playerIndex] += _gridContainer.P1Tile.Count * multiplier;
                    break;
                default:
                    Debug.Log("wrong player index");
                    break;

            }
        }

        public void ActivateDoubleScore(int playerIndex)
        {
            Debug.Log("bisaa");
            _isDoubleScore[playerIndex] = true;
        }

        public void DeactiveDoubleScore(int playerIndex)
        {
            Debug.Log("deactive" + playerIndex);
            _isDoubleScore[playerIndex] = false;
        }

        private void CreateScoreIndex()
        {
            for(int i = 0; i < 4; i++)
            {
                _isDoubleScore.Add(false);
                playersScore.Add(0);
            }
        }
    }
}

