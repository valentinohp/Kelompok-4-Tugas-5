using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Paintastic.UI;
using Paintastic.Scene.Gameplay;

namespace Paintastic.Global.MatchHistory
{
    public class MatchHistory 
    {
        public int[] WinHistory = new int[4];
        public int[] PlayerXP = new int[4];
        public bool ConvertWinToXP = false;
    }

    public class MatchHistoryManager : MonoBehaviour
    {
        private string _saveFile;
        [SerializeField] private MatchHistoryUI _ui;

        public MatchHistory matchHistory = new MatchHistory();

        public static MatchHistoryManager instance;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
            
            _saveFile = Application.persistentDataPath + "/matchhistory.json";
            LoadMatchHistory();
            if (!matchHistory.ConvertWinToXP)
                ConvertWinToXP();
        }

        private void OnEnable()
        {
            Gameplay.OnGameOver += AddWin;
        }

        private void OnDisable()
        {
            Gameplay.OnGameOver -= AddWin;
        }

        private void LoadMatchHistory()
        {
            if(File.Exists(_saveFile) && _ui != null)
            {
                string fileContents = File.ReadAllText(_saveFile);
                matchHistory = JsonUtility.FromJson<MatchHistory>(fileContents);
                _ui.GetData(matchHistory.WinHistory);
            }
        }

        private void SaveMatchHistory()
        {
            string json = JsonUtility.ToJson(matchHistory);
            File.WriteAllText(_saveFile, json);
        }

        private void AddWin(int winner, Color color, int numberOfPlayer, Material winMat)
        {
            if (winner != -1)
            {
                matchHistory.WinHistory[winner]++;
                for (int i = 0; i < numberOfPlayer; i++)
                {
                    if (i == winner)
                    {
                        matchHistory.PlayerXP[i] += 100;
                    }
                    else
                    {
                        matchHistory.PlayerXP[i] += 50;
                    }
                }
                SaveMatchHistory();
            }
        }

        private void ConvertWinToXP()
        {
            for (int i = 0; i < matchHistory.PlayerXP.Length; i++)
            {
                matchHistory.PlayerXP[i] += matchHistory.WinHistory[i] * 100;
            }
            
            matchHistory.ConvertWinToXP = true;
            SaveMatchHistory();
        }
    }
}