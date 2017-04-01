using UnityEngine;

public class CanvasManager : MonoBehaviour {
    #region SINGLETON PATTERN
    public static CanvasManager _instance;
    public static CanvasManager Instance {
        get {
            if (_instance == null) {
                _instance = GameObject.FindObjectOfType<CanvasManager>();

                if (_instance == null) {
                    GameObject container = new GameObject("UI_Canvas");
                    _instance = container.AddComponent<CanvasManager>();
                }
            }

            return _instance;
        }
    }
    #endregion

    GameObject onSceneControls,infoMenu;
    void Awake() {
        this.onSceneControls = this.transform.GetChild(0).gameObject;
        this.infoMenu = this.transform.GetChild(1).gameObject;
    }

    void Start() {
        this.infoMenu.SetActive(true);
        this.infoMenu.SendMessage("Initialize");
        this.infoMenu.SetActive(false);
    }
    
    public void ShowInfoMenu() {
        this.infoMenu.SetActive(true);
        this.onSceneControls.SetActive(false);
    }
    public void HideInfoMenu() {
        this.infoMenu.SetActive(false);
        this.onSceneControls.SetActive(true);
    }
    public void SetHeader(int _number,string _title) {
        this.onSceneControls.SendMessage("SetNumber",_number);
        this.onSceneControls.SendMessage("SetTitle",_title);
    }

    public void SetInfo(string _info) {
        this.infoMenu.SendMessage("SetInfo",_info);
    }

    public void SetShortInfo(string _info) {
        this.onSceneControls.SendMessage("SetInfo",_info);
    }

    public void InfoMenu_PressBackButton() {
        this.infoMenu.SendMessage("PressBack");
    }

}
