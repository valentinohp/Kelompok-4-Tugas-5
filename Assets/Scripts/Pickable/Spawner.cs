using System.Collections;
using System.Collections.Generic;
using Paintastic.Grid;
using Paintastic.Player;
using Paintastic.Utility;
using UnityEngine;

namespace Paintastic.Pickable
{
    public class Spawner : MonoBehaviour
    {
        private GridContainer _gridContainer;
        private PlayerControlScript _playerControlScript;
        [SerializeField] private GameObject _bombPrefab;
        [SerializeField] private GameObject _collectPointPrefab;
        private GameObject _bomb;
        private GameObject _collectPoint;
        [SerializeField] private Timer _timer;
        private List<GameObject> _items = new List<GameObject>();
        private ScoreManager _scoreManager;

        private void Start()
        {
            _timer.OnTimerEnd += SpawnItem;
            _gridContainer = GetComponent<GridContainer>();
            _playerControlScript = GetComponent<PlayerControlScript>();
            _scoreManager = GetComponent<ScoreManager>();
            _bomb = Instantiate(_bombPrefab);
            _collectPoint = Instantiate(_collectPointPrefab);
            _bomb.SetActive(false);
            _collectPoint.SetActive(false);
            _items.Add(_bomb);
            _items.Add(_collectPoint);
            _timer.StartTimer();
        }

        private void Update()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].activeInHierarchy)
                {
                    for (int j = 0; j < _playerControlScript.playersList.Count; j++)
                    {
                        if (_playerControlScript.playersList[j].transform.position == _items[i].transform.position)
                        {
                            DespawnItem(_items[i], j);
                            break;
                        }
                    }
                }
            }
        }

        private void SpawnItem()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                SpawnItem(i, _items[i]);
            }
        }

        private void SpawnItem(int index, GameObject item)
        {
            int rand = Random.Range(0, _gridContainer.Poles.Count);
            item.transform.position = _gridContainer.Poles[rand].transform.position;
            item.SetActive(true);
        }

        private void DespawnItem(GameObject item, int playerIndex)
        {
            CollectPoint(playerIndex, item);
            item.SetActive(false);
            _gridContainer.ClearTile((List<GameObject>)_gridContainer.GetType().GetField($"P{playerIndex + 1}Tile").GetValue(_gridContainer));
            
          
        }

        private void CollectPoint(int playerIndex, GameObject item)
        {
            if (item.tag == "collect")
            {
                _scoreManager.AddPoint(playerIndex);
            }
            
        }
    }
}
