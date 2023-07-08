using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Dialogue
{
    public class DialogueDisplay : MonoBehaviour
    {
        [Header("Dialogue Box References")]
        [SerializeField] private GameObject Box;
        [SerializeField] private GameObject Options;
        
        [SerializeField] private TMP_Text Content;
        
        [SerializeField] private RawImage SpeakerImage;
        [SerializeField] private TMP_Text SpeakerName;
        
        private readonly List<OptionBtn> _buttons = new();

        private void Awake()
        {
            for (int i = 0; i < Options.transform.childCount; i++)
                _buttons.Add(Options.transform.GetChild(i).GetComponent<OptionBtn>());

            Debug.Log(_buttons.Count);
        }

        public void StartDisplay(DialogueSO dialogue)
        {
            Box.SetActive(true);
            Options.SetActive(true);
            
            foreach (var button in _buttons) {
                button.OnOptionSelected += option =>
                {
                    OnOptionSelected(ref dialogue, option);
                };
            }
            
            UpdateDisplay(dialogue);
        }
        
        public void StopDisplay()
        {
            Box.SetActive(false);
            Options.SetActive(false);
            
            foreach (var button in _buttons)
                button.OnOptionSelected = null;
        }
        
        private void OnOptionSelected(ref DialogueSO root, int option)
        {
            if (option >= root.Next.Count)
            {
                Debug.LogWarning("Stopped dialogue display as option was out of range. MAY BE INTENTIONAL.");
                StopDisplay();
                return;
            }
            
            DialogueSO child = root.Next[option];
            child.Callback.Invoke();
            
            // if (root.Next.Count > 0)
            // else
            //     StopDisplay();
            
            root = child;
            UpdateDisplay(root);
        }

        private void UpdateDisplay(DialogueSO dialogue){
            Content.text = dialogue.Content;

            SpeakerImage.texture = dialogue.Speaker.Profile;
            SpeakerName.text = dialogue.Speaker.Name;
            
            for(int i = 0; i < _buttons.Count; i++) {
                if (dialogue.Options.Count <= i) {
                    _buttons[i].gameObject.SetActive(false);
                }
                else {
                    _buttons[i].gameObject.SetActive(true);
                    _buttons[i].ChangeContent(dialogue.Options[i]);
                }
            }
        }
    }
}