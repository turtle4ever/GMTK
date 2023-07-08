using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Directions direction;
    public Room currentroom;
    void Update()
    {
        if ( Input.GetKeyDown (KeyCode.RightArrow))
        {
            direction = (Directions)(((int)direction + 1) % 4 );
            currentroom.Toggleposition(direction);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            direction = (Directions)((3 + (int)direction) % 4);
            currentroom.Toggleposition(direction);
        }
        
    }
}
