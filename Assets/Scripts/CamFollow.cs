using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    public static float offsetX;
    [SerializeField]
    private GameObject player;

	// Use this for initialization
	void Start () {
        offsetX = player.transform.localScale.x * 8;
	}
	
	// Update is called once per frame
	void Update () {
        MoveCamera();
	}
    private void MoveCamera() {
        Vector3 temp = transform.position;
        temp.x = player.transform.position.x + offsetX;
        transform.position = temp;
    }
}
