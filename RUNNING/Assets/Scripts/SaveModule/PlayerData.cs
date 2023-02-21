using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public float distance;
    public float[] position;

    public PlayerData (Movement movement)
    {
        distance = movement.totalDistance; //save distance travelled

    }
}
