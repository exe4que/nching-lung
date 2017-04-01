using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SlideSet : MonoBehaviour {

    public string id;
    [TextArea(3,10)]
    public string description;
    public Slide[] slides;
    public bool isPlayable;
}
