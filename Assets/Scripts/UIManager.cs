using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject ZigZagPanel;
    public GameObject GameOverPanel;
    public GameObject tapText;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore1;
    public TextMeshProUGUI highScore2;
    public static UIManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highScore1.text = "High Score : "  + PlayerPrefs.GetInt(" highScore");
    }

    public void GameStart()
    {
        tapText.SetActive(false);

        ZigZagPanel.SetActive(false);

        GameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        score.text = "Score\n" + PlayerPrefs.GetInt("score").ToString();
        highScore2.text = "Best Score\n" + PlayerPrefs.GetInt("highScore").ToString();

        GameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
