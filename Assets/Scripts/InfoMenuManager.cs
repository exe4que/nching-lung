using UnityEngine;
using UnityEngine.UI;

public class InfoMenuManager : MonoBehaviour {

    Text txtContent;
    Button btnBack;

    public void Initialize() {
        this.txtContent = transform.FindChild("scrollrectpanel").FindChild("txt_content").GetComponent<Text>();
        this.btnBack = transform.FindChild("btn_back").GetComponent<Button>();
        SetInfo("");
    }

    void OnEnable() {
        if (SlideshowManager.Instance.GetIndex() >= 0) {
            Slide currentSlide = SlideshowManager.Instance.GetCurrentSlide();
            if (currentSlide != null) {
                SetInfo(SlideshowManager.Instance.GetCurrentSlide().info);
            }
        }
    }

    public void SetInfo(string _info) {
        this.txtContent.text = _info;
    }

    public void PressBack() {
        CanvasManager.Instance.HideInfoMenu();
    }
}
