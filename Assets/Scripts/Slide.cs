using UnityEngine;

[System.Serializable]
public class Slide {
    public int number;
    public float duration;
    public string title;
    [TextArea(7,10)]
    public string info;
    public GameObject[] hotspots;
}
