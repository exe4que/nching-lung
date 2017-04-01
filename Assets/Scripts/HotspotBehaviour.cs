using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotspotBehaviour : MonoBehaviour {
    public Transform relativeTo;

    public void Init() {
        if (relativeTo == null) {
            Debug.LogError("'relativeTo' object is null.");
            return;
        }
        this.transform.SetParent(relativeTo);
        this.gameObject.SetActive(false);
    }

    public void Init(float _scale) {
        if (relativeTo == null) {
            Debug.LogError("'relativeTo' object is null.");
            return;
        }
        this.transform.SetParent(relativeTo);
        this.transform.localScale = Vector3.one * _scale;
        this.gameObject.SetActive(false);
    }

    public void SetScale(float _scale) {
        this.transform.localScale = Vector3.one * _scale;
    }
}
