using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Paintastic.Grid;
using TMPro;

namespace Paintastic.Score
{
    public class ScoreManager : MonoBehaviour
    {
        public List<int> playersScore;
        public List<bool> _isDoubleScore;
        private GridContainer _gridContainer;

        private void Start()
        {
            CreateScoreIndex();
            _gridContainer = GetComponent<GridContainer>();
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
            _isDoubleScore[playerIndex] = true;
        }

        public void DeactiveDoubleScore(int playerIndex)
        {
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

