using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI Instance;

    private Text scoreText;
    public int scoreNum = 0;

   /* public int Score
    {
        get => scoreNum;
        set { scoreNum = value; UpdateScoreText(scoreNum);Debug.Log("Score" +
            "Changed"); }
    }*/

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = transform.Find("ScoreText").GetComponent<Text>();
        scoreText.text = "0000";
    }

    public void UpdateScoreText()
    {
        scoreText.text = scoreNum.ToString("0000");
    }
}
