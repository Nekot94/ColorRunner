using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 15f;

    private int score;

    private Rigidbody rb;
    [SerializeField]
    private AudioSource playerTalk;
    [SerializeField]
    private AudioSource playerCollect;
    [SerializeField]
    private AudioClip collectSound;
    [SerializeField]
    private AudioClip deadSound;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = new Vector3 (speed * Time.deltaTime, 0, 0);
        rb.AddForce(movement);
	}

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Box") {
            score++;
            speed += 10f;
            GameController.instance.ChangeScore(score);
            Die (collision);
        }
    }   

    void OnCollisionStay(Collision collision) {
        if (collision.gameObject.tag == "Box") {
            Die(collision);
        }
    }
    private void Die(Collision collision) {
        BoxStates colState = collision.gameObject.GetComponent<BoxScript> ().State;
        if(colState == BoxStates.red) {
            collision.gameObject.SetActive(false);
            GameController.instance.EndGame();
            if(playerTalk != null && deadSound != null) {
                playerCollect.clip = deadSound;
                playerCollect.Play();
            }
        }
            

    }
}
