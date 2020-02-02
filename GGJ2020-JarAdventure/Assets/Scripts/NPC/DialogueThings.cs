using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class DialogueThings
{
    [TextArea(1, 3)]
    public string[] sentences;
    public Sprite img;
    public AudioClip voice;

}