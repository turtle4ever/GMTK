using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Restart : MonoBehaviour, IPointerUpHandler
{

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    { 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Restarted Scene");
    }
}
