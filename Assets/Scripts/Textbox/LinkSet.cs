using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LinkSet
{
    public Dialogue_Set linkedSet;
    public string option = "Option";
    public int points = 0;
    public FLAG flag = FLAG.None;

    public LinkSet() {
        option = "Option";
        linkedSet = null;
         int points = 0;
        FLAG flag = FLAG.None;

    }
    
}
