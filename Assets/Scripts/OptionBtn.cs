using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class OptionBtn : MonoBehaviour
{
    public Action<int> ChooseOption;
    public int OptionNumber;
    public void OnClick(){
        ChooseOption(OptionNumber);
    }
}
