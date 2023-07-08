using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
public class OptionBtn : MonoBehaviour
{
    public Action<int> ChooseOption;
    public int OptionNumber;
    public void OnClick(){
        ChooseOption(OptionNumber);
    }

    public void ChangeContent(string NewContent){
        TMP_Text text = GetComponentInChildren<TMP_Text>();
        text.text = NewContent;
    }
}
