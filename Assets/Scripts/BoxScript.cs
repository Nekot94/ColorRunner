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
        float randTime = Random.Range(2f,30f);
        StartCoroutine(TurnBlue (randTime));
    }

    private void ChangeToRed() {
        ChangeColor(colors[1]);
    }

    private void ChangeToBlue() {
        ChangeColor(colors[2]);
        StartCoroutine(GoBack(2f));
    }

    private void OnMouseDown() {
        if ((int)State != 0) {
            State--;
        }
        else {
            State++;
        }
    }

    private IEnumerator GoBack(float time) {
        yield return new WaitForSeconds(time);
        State--;
    }

    private IEnumerator TurnBlue(float time) {
        yield return new WaitForSeconds(time);
        State = BoxStates.blue;
    }


    // Update is called once per frame
    void Update () {
		
	}
}
