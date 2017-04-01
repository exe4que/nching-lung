using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotspotsManager : MonoBehaviour {
    GameObject[] hotspots;

	void Start () {
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
            }
        }
    }

    public void ActivateHotspot(string _spot, float _scale) {
        for (int i = 0; i < hotspots.Length; i++) {
            if (hotspots[i].name.Equals(_spot)) {
                hotspots[i].SetActive(true);
                hotspots[i].SendMessage("SetScale",_scale);
            }
        }
    }
}
