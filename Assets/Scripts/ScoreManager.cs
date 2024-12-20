using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int score;
    public int highScore;
    public static ScoreManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: If you want the score manager to persist between scenes
        }
        else
        {
            Destroy(gameObject); // Ensure there's only one instance of ScoreManager
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void IncrementScore()
    {
        score += 1;
    }

    public void StartScore()
    {
        score = 0; // Reset the score to 0
        PlayerPrefs.SetInt("score", score);
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }

    public void StopScore()
    {
        CancelInvoke("IncrementScore");

        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highScore"))
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
