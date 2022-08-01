using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
   

    public GameObject[] fruits;
    public Transform readyPos;
    public GameObject readyFruit;

    public GameObject gameOverCanvas;

    private int index;
    
    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
         CreateFruits();
        //GameObject gameObject = CreateFruits
       
    }

    // Update is called once per frame
    void Update()
    {
        if (readyFruit == null) return;//返回，后面的不执行


        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//屏幕坐标转换成世界坐标
            Vector3 newPos = new Vector3(mousePos.x, readyFruit.transform.position.y, 0);
            //readyFruit.transform.position = newPos;

            float minX = -3.38f + readyFruit.GetComponent<CircleCollider2D>().radius;
            float maxX = 3.38f - readyFruit.GetComponent<CircleCollider2D>().radius;




            if (mousePos.x < minX)
            {
                newPos.x = minX;
            }
            else if (mousePos.x > maxX)
            {
                newPos.x = maxX;
            }
            


            readyFruit.transform.position = newPos;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            readyFruit.GetComponent<Rigidbody2D>().gravityScale = 1;
            Invoke("CreateFruits", 0.8f);//延时调用
            readyFruit = null;
        }
    }

    public void CreateFruits()
    {
        
        

        int index = Random.Range(0, 5);
        GameObject fruitToNew = fruits[index];
        readyFruit = Instantiate(fruitToNew);
        readyFruit.transform.position = readyPos.position;
        readyFruit.GetComponent<Rigidbody2D>().gravityScale = 0;
        
    }

    public void ActivateGameOverCanvas()
    {
        gameOverCanvas.SetActive(true);
        GameOverUI.Instance.UpdateScore(UI.Instance.scoreNum);
    }

    
     
}
