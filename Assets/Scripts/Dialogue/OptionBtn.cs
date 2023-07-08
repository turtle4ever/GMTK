using System;
using TMPro;
using UnityEngine;

namespace Dialogue
{
    public class OptionBtn : MonoBehaviour
    {
        public Action<int> ChooseOption;
        public int OptionNumber;
        
        public void OnClick() {
            Debug.Log(OptionNumber);
            ChooseOption?.Invoke(OptionNumber);
        }

        public void ChangeContent(string content) {
            TMP_Text text = GetComponentInChildren<TMP_Text>();
            text.text = content;
        }
    }
}
