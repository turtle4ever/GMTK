using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    //idfk serb im sorry basically i tried to find out whatcha meant
    //i got to this in the end
    //it sucks
    public float position;
    public float position_current;
    private void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            if ( position <= position_current)
            { 
                transform.position += new Vector3(-position, 0f , 0f);
                position_current = position_current - position;
            }   
            else
            {
                position_current = position * 3;
                transform.position = new Vector3(3*position, 0f, -10f);
            }
           
        }
        if (Input.GetKeyDown("r"))
        {
            if (position * 3 > position_current)
            {
                transform.position += new Vector3(position, 0f, 0f);
                position_current = position_current + position;
            }
            else
            {
                transform.position = new Vector3(0f, 0f, -10f);
                position_current = 0f;
            }
        }
    }
}
