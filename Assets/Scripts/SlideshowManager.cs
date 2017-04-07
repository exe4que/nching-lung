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

    public SlideSet set;
    private int index;
    private float clock;
    public bool isPlaying;
    private AudioSource player;

    void Awake() {
        player = this.GetComponent<AudioSource>();
    }

    void Start() {
        StopSlideshow();
    }

    public bool GetPlay() {
        return set.isPlayable;
    }

    public int GetIndex() {
        return this.index;
    }

    public Slide GetSlide(int _i) {
        return set.slides[_i];
    }

    public Slide GetCurrentSlide() {
        if (index < 0) {
            return null;
        }
        return set.slides[index];
    }

    public void ToogleSlideshow() {
        if (isPlaying) {
            StopSlideshow();
        } else {
            StartSlideshow();
        }
    }

    public void StartSlideshow() {
        isPlaying = true;
        index = 0;
        clock = 0f;
        LoadSlide(0);
    }

    public void StopSlideshow() {
        isPlaying = false;
        CanvasManager.Instance.SetHeader(-1,"");
        CanvasManager.Instance.SetShortInfo("");
        index = -1;
    }

    public void LoadSlide(int _index) {
        //Debug.Log("index="+index);
        if (index < 0 || index >= set.slides.Length) {
            StopSlideshow();

        } else {
            int number = set.slides[_index].showNumber ? _index + 1 : -1;
            CanvasManager.Instance.SetHeader(number,set.slides[_index].title);
            CanvasManager.Instance.SetShortInfo(set.slides[_index].info);
            HotspotsManager.Instance.DeactivateHotspots();
            HotspotsManager.Instance.ActivateHotspots(set.slides[_index].hotspots);
        }
        if (isPlaying) player.Play();
    }

    private void Next() {
        index++;
        clock = 0;
        LoadSlide(index);
    }
    public void PressNext() {
        Next();
        isPlaying = false;
    }
    private void Previous() {
        index--;
        clock = 0;
        LoadSlide(index);
    }
    public void PressPrevious() {
        Previous();
        isPlaying = false;
    }

    void Update() {
        if (isPlaying) {
            if (clock >= set.slides[index].duration) {
                Next();
            }
            clock += Time.deltaTime;
        }
    }

    public enum cameras { FRONT, BACK };
}
