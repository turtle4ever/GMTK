using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Block : MonoBehaviour
{
    public Action<(int, int)> ClickBlock;
    public Action<(int, int)> SetFlag;
    public bool IsMine = false;
    public bool IsFlag = false;

    private void OnMouseDown() {
        ClickBlock(((int)transform.position.x, (int)transform.position.y));
    }

    private void OnMouseOver() {
        if(Input.GetMouseButtonDown(1)){
            SetFlag(((int)transform.position.x, (int)transform.position.y));
        }
    }
}
