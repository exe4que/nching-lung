using UnityEngine;
using UnityEngine.UI;

public class SceneControlsManager : MonoBehaviour {

    Button btnPlay, btnInfo;
    Text txtNumber, txtTitle;
    void Awake() {
        this.btnPlay = transform.FindChild("btn_play").GetComponent<Button>();
        this.btnInfo = transform.FindChild("btn_info").GetComponent<Button>();
        this.txtNumber = transform.FindChild("txt_number").GetComponent<Text>();
        this.txtTitle = transform.FindChild("txt_title").GetComponent<Text>();
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

    public void PressInfo() {
        CanvasManager.Instance.ShowInfoMenu();
    }

    public void PressPlay() {
        SlideshowManager.Instance.ToogleSlideshow();
    }
}
