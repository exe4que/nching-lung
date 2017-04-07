using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotspotsManager : MonoBehaviour {

    #region SINGLETON PATTERN
    public static HotspotsManager _instance;
    public static HotspotsManager Instance {
        get {
            if (_instance == null) {
                _instance = GameObject.FindObjectOfType<HotspotsManager>();

                if (_instance == null) {
                    GameObject container = new GameObject("Hotspots");
                    _instance = container.AddComponent<HotspotsManager>();
                }
            }

            return _instance;
        }
    }
    #endregion

    GameObject[] hotspots;

    void Start() {
        hotspots = new GameObject[this.transform.childCount];
        int i = 0;
        //Saving references
        foreach (Transform child in this.transform) {
            hotspots[i] = child.gameObject;
            i++;
        }
        //Changing parent
        for (int j = 0; j < hotspots.Length; j++) {
            hotspots[j].SendMessage("Init");
        }
    }

    public void ActivateHotspot(string _spot) {
        for (int i = 0; i < hotspots.Length; i++) {
            if (hotspots[i].name.Equals(_spot)) {
                hotspots[i].SetActive(true);
                return;
            }
        }
        Debug.Log("Hotspot '" + _spot + "' does not exist.");
    }

    public void ActivateHotspot(string _spot,float _scale) {
        for (int i = 0; i < hotspots.Length; i++) {
            if (hotspots[i].name.Equals(_spot)) {
                hotspots[i].SetActive(true);
                hotspots[i].SendMessage("SetScale",_scale);
                return;
            }
        }
        Debug.Log("Hotspot '" + _spot + "' does not exist.");
    }

    public void ActivateHotspots(string[] _spots) {
        for (int i = 0; i < _spots.Length; i++) {
            ActivateHotspot(_spots[i]);
        }
    }

    public void ActivateHotspots(string[] _spots, int _scale) {
        for (int i = 0; i < _spots.Length; i++) {
            ActivateHotspot(_spots[i], _scale);
        }
    }

    public void DeactivateHotspots() {
        for (int i = 0; i < hotspots.Length; i++) {
            hotspots[i].SetActive(false);
        }
    }
}
