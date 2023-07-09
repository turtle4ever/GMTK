using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject GameStatus;
    [SerializeField] private GameObject UI;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape))
            ToggleUI();
    }

    public void ToggleUI(){
        UI.SetActive(!UI.activeSelf);
    }

    public void ToggleUIOn(){
        UI.SetActive(true);
    }

    public void DisplayFlagsLeft(int flags){
        GameStatus.GetComponentInChildren<TMP_Text>().text = "Flags:"+flags.ToString();
    }

}
