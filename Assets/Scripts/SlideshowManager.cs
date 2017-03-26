using UnityEngine;

public class SlideshowManager : MonoBehaviour {

    #region SINGLETON PATTERN
    public static SlideshowManager _instance;
    public static SlideshowManager Instance {
        get {
            if (_instance == null) {
                _instance = GameObject.FindObjectOfType<SlideshowManager>();

                if (_instance == null) {
                    GameObject container = new GameObject("Slideshow");
                    _instance = container.AddComponent<SlideshowManager>();
                }
            }

            return _instance;
        }
    }
    #endregion

    public Slide[] slides;
    private int index;
    private float clock;

    void Start() {
        StopSlideshow();
    }

    public int GetIndex() {
        return this.index;
    }

    public Slide GetSlide(int _i) {
        return slides[_i];
    }

    public Slide GetCurrentSlide() {
        if (index < 0) {
            return null;
        }
        return slides[index];
    }

    public void ToogleSlideshow() {
        if (index >= 0) {
            StopSlideshow();
        }else {
            StartSlideshow();
        }
    }

    public void StartSlideshow() {
        index = 0;
        clock = 0f;
    }

    public void StopSlideshow() {
        CanvasManager.Instance.SetHeader(-1,"");
        //CanvasManager.Instance.SetInfo("");
        index = -1;
    }

    void Update() {
        if (index < 0) return;
        if (clock >= slides[index].duration) {
            index++;
            if (index >= slides.Length) {
                StopSlideshow();
            }
            clock = 0;
            return;
        }
        if (clock == 0) {
            CanvasManager.Instance.SetHeader(slides[index].number,slides[index].title);
            //CanvasManager.Instance.SetInfo(slides[index].info);
        }
        clock += Time.deltaTime;
    }
}
