using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    [SerializeField] private DialogueSO DialogueTreeRoot;
    [SerializeField] private DialogueDisplay UI;

    //TODO: move this into their correct scripts

    void Start(){
        Display();
        OptionBtn[] btn = FindObjectsOfType<OptionBtn>();
        for(int i=0; i<btn.Length; i++){
            btn[i].ChooseOption +=Select;
        }
    }
    //
    public void Display(){
        UI.ShowDialogueLine(DialogueTreeRoot);
        UI.ShowDialogueOptions(DialogueTreeRoot);
    }

    public string GetContent(){
        return DialogueTreeRoot.Content;
    }
    public List<string> GetOptions(){
        return DialogueTreeRoot.Options;
    }

    public void Select(int option){
        DialogueSO child = GetChild(DialogueTreeRoot, option);
        DialogueTreeRoot = child;

        Display();
    }

    DialogueSO GetChild(DialogueSO Parent, int option){
        Debug.Log(Parent.Next.Count);
        Debug.Log(option);
        if(Parent == null){
            Debug.Log("Parent is null! (This should`t happen!)");
        }
        DialogueSO Child = Parent.Next[option];
        return Child;
    }
}
