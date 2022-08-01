using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fruit : MonoBehaviour
{
    public int level;
  
    private bool isFirstFloor = true;

    private bool isFirstTrigger = true;//第一次触发


    private void Start()
    {
        Debug.Log(gameObject.GetInstanceID());
    }

    private void Update()
    {
        
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        //判断不是待命水果，且标签为fruit
        if (collision.gameObject.CompareTag("Fruit") == true )
        {
           
            if (this.level == collision.gameObject.GetComponent<Fruit>().level)
                {
                    if (this.gameObject.GetInstanceID() > collision.gameObject.GetInstanceID())
                    {
                        GameObject newFruit = Instantiate(Player.instance.fruits[this.level]);
                        newFruit.transform.position = this.gameObject.transform.position;//到我自己的位置
                                                                                         //更新分数
                        Debug.Log("合成一次");
                        UI.Instance.scoreNum += this.level * 2;
                        UI.Instance.UpdateScoreText();

                        AudioManager.Instance.PlayAudio(AudioManager.Instance.audioClips[0]);

                       
                        Destroy(collision.gameObject);
                        Destroy(this.gameObject);
                    }
                }
               
            
        }
        else if (collision.gameObject.tag == "Floor" && isFirstFloor ==true)
        {
           
            AudioManager.Instance.PlayAudio(AudioManager.Instance.audioClips[1]);
            isFirstFloor = false;
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Deadline")
        {
            if (isFirstTrigger == true)
            {
                isFirstTrigger = false;
                Debug.Log("碰到deadline啦");
            }
            else if (isFirstTrigger == false)
            {
               // GameOverUI.Instance.UpdateGameOver();
                Debug.Log("GameOver");
                //SceneManager.LoadSceneAsync("MainMenu");
                Player.instance.ActivateGameOverCanvas();

                Player.instance.readyFruit.transform.position = Player.instance.readyPos.position;

            }

        }


        /*if (isFirstTrigger == false  && collision.gameObject.tag == "Dealine")
        {
           
            
        }else if(isFirstTrigger == true && collision.gameObject.tag == "Deadline")
        {
           
        }*/
    }

}


