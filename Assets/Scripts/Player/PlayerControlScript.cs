using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Paintastic.Player
{
    public class PlayerControlScript : MonoBehaviour
    {
        public List<GameObject> playersList;
        public List<GameObject> PlayerTarget;

        public void AddPlayer(GameObject player)
        {
            playersList.Add(player);
        }

        public void AddPlayerTarget(GameObject target, int playerIndex)
        {
            PlayerTarget[playerIndex] =target;
        }
    }
}

