using UnityEngine;
using UnityEngine.UI;

public class SceneControlsManager : MonoBehaviour {

    Button btnPlay, btnInfo;
    Text txtNumber, txtTitle, txtInfo;
    GameObject imgPlay, imgStop;
    void Awake() {
        this.btnPlay = transform.FindChild("btn_play").GetComponent<Button>();
        this.imgPlay = btnPlay.transform.GetChild(0).gameObject;
        this.imgStop = btnPlay.transform.GetChild(1).gameObject;
        this.btnInfo = transform.FindChild("btn_info").GetComponent<Button>();
        this.txtNumber = transform.FindChild("txt_number").GetComponent<Text>();
        this.txtTitle = transform.FindChild("txt_title").GetComponent<Text>();
        this.txtInfo = transform.FindChild("txt_info").GetComponent<Text>();
    }

    public void SetTitle(string _title) {
        this.txtTitle.text = _title;
    }

    public void SetNumber(int _number) {
        if (_number == -1) {
            this.txtNumber.text = "";
            return;
        }
        this.txtNumber.text = _number.ToString();
    }

    public void SetInfo(string _info) {
        bool trimmed = false;
        if (_info.Length>20) {
            _info = _info.Substring(0,20).Trim();
            trimmed = true;
        }
        this.txtInfo.text = _info + (trimmed ? "..." : "");
    }

    public void PressInfo() {
        CanvasManager.Instance.ShowInfoMenu();
    }

    public void PressPlay() {
        SlideshowManager.Instance.ToogleSlideshow();
        SetPlayImg();
    }

    public void PressNext() {
        SlideshowManager.Instance.PressNext();
        SetPlayImg();
    }

    public void PressPrevious() {
        SlideshowManager.Instance.PressPrevious();
        SetPlayImg();
    }

    private void SetPlayImg() {
        imgPlay.SetActive(!SlideshowManager.Instance.isPlaying);
        imgStop.SetActive(SlideshowManager.Instance.isPlaying);
    }
}
