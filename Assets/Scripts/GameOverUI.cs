using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI Instance;

    public Button restartBtn;
    public Button quitBtn;
    public Text textGameOver;
   

    private void Awake()
    {
        if (Instance != null) Destroy(gameObject);
        Instance = this;
    }

    private void Start()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quited");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        this.GetComponent<Canvas>().gameObject.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        textGameOver.text = "你的得分是：" + score.ToString("000");
    }

    /*public void ActivateGameOver()
    {
       
        textGameOver.text =  UI.Instance.scoreNum.ToString("000");
        this.GetComponent<Canvas>().gameObject.SetActive(true);
    }*/
}
