using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DialogueSO : ScriptableObject
{
    public string Content;
    public List<string> Options;
    public List<DialogueSO>Next;
}
