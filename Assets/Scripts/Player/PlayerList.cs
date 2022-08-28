using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementKey
{
    public List<KeyCode> UpLeftDownRight;
}

[System.Serializable]
public class PlayerList
{
    public List<MovementKey> players;
}
