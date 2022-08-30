using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Paintastic.Player
{
    public class PlayerControlScript : MonoBehaviour
    {

        public List<GameObject> playersList;
        public List<GameObject> PlayerTarget;

        // Start is called before the first frame update

        public void AddPlayer(GameObject player)
        {
            playersList.Add(player);
        }

        public void AddPlayerTarget(GameObject target)
        {
            PlayerTarget.Add(target);
        }

    }
}

