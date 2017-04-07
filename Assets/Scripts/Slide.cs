using UnityEngine;

[System.Serializable]
public class Slide {
    public bool showNumber=true;
    public float duration;
    public string title;
    [TextArea(7,10)]
    public string info;
    public string[] hotspots;
    public SlideshowManager.cameras camera = SlideshowManager.cameras.FRONT;
}
