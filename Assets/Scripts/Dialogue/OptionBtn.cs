using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Dialogue
{
    public class OptionBtn : MonoBehaviour
    {
        [SerializeField] private int _optionNumber;
        public Action<int> OnOptionSelected;
        
        private TMP_Text _text;

        private void Awake()
        {
            _text = GetComponentInChildren<TMP_Text>();
        }

        public void OnClick() {
            OnOptionSelected?.Invoke(_optionNumber);
        }

        public void ChangeContent(string content) {
            _text.text = content;
        }
    }
}
