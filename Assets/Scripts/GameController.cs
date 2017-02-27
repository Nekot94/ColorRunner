using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
    public static GameController instance;

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text bestScoreText;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject loseText;
    void Awake() {
        if (instance == null) {
            instance = this;
        }
        GetBestScore();
        loseText.SetActive(false);
    }

    public void EndGame() {
        loseText.SetActive(true);
        StartCoroutine(RestartLevel(2f));
    }
    private IEnumerator RestartLevel(float time) {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("Main");
    }
    public void ChangeScore(int score) {
        SetBestScore(score);
        scoreText.text = "Очки:" + score.ToString();
    }

    private void SetBestScore(int score) {
        if (!PlayerPrefs.HasKey("Score") || PlayerPrefs.GetInt("Score") < score) {
            PlayerPrefs.SetInt("Score", score);
            bestScoreText.text = "HighScore:" + score.ToString();
        }
    }
    private void GetBestScore() {
        if (PlayerPrefs.HasKey("Score")) {
            int score = PlayerPrefs.GetInt("Score");
            bestScoreText.text = "HighScore:" + score.ToString();
        }
    }
}