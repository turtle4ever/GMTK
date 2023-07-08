using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private GameObject North_tilemap, West_tilemap, South_tilemap, East_tilemap;
    private int position ;
    public void Toggleposition(Directions direction)
    {
        North_tilemap.SetActive(false);
        West_tilemap.SetActive(false);
        South_tilemap.SetActive(false);
        East_tilemap.SetActive(false);
        if (direction == Directions.North)
            North_tilemap.SetActive(true);
        else
            if (direction == Directions.South)
                South_tilemap.SetActive(true);
            else
                if (direction == Directions.East)
                    East_tilemap.SetActive(true);
                else
                    if (direction == Directions.West)
                        West_tilemap.SetActive(true);

    }
}
