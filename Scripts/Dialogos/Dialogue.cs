using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialogue
{    
    public string name;

    [TextArea(1, 10)]
    public string[] sentencesList;

    public void SetSentenceList(string[] sentece)
    {
        sentencesList = sentece;
    }
}
