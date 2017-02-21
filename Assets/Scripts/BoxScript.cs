using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour {
    public Color[] colors;

    private Material boxMaterial;

    private BoxStates state;

    public BoxStates State {
        get {
            return state;
        }
        set {
            state = value;
            CheckState();
        }
    }
	// Use this for initialization
	void Start () {
        boxMaterial = GetComponent<Renderer>().material;
        RandomState();
	}

    public void RandomState() {
        int boxStatesCount = System.Enum.GetNames(typeof(BoxStates)).Length;
        State = (BoxStates)Random.Range(0, boxStatesCount);
    }

    public void CheckState() {
        if (State == BoxStates.green) {
            ChangeToGreen();
        }
        if (State == BoxStates.red) {
            ChangeToRed();
        }
        if (State == BoxStates.blue) {
            ChangeToBlue();
        }
    }

    private void ChangeColor (Color color) {
        boxMaterial.SetColor("_EmissionColor", color);
    }

    private void ChangeToGreen() {
        ChangeColor(colors[0]);
    }

    private void ChangeToRed() {
        ChangeColor(colors[1]);
    }

    private void ChangeToBlue() {
        ChangeColor(colors[2]);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
