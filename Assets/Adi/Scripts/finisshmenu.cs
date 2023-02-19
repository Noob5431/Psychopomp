using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class finisshmenu : MonoBehaviour
{

    [SerializeField] Text thisTime;
    [SerializeField] Text bestTime;
    gamemanager manager;
    float currtime;
    float time;
    public GameObject finishUI;
    public GameObject timer;
    public bool LevelOver = false;
    Pausemenu pause;
    Pausemenu strt;
    public bool isFinished=false;

    private void Start()
    {
        manager = GameObject.Find("gameManager").GetComponent<gamemanager>();
        
    }
    void Update()
    {
        if (isFinished)
        {
            LevelOver = true;
            Object.Destroy(timer);
            finishUI.SetActive(true);
            currtime = gameObject.GetComponent<Timer>().currentTime;
            if (currtime<manager.highScore || manager.highScore ==-1)
            {
                manager.highScore = currtime;
            }
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            LevelOver = true;
            Object.Destroy(timer);
            finishUI.SetActive(true);
            currtime = gameObject.GetComponent<Timer>().currentTime;
            if (currtime < manager.highScore || manager.highScore == -1)
            {
                manager.highScore = currtime;
            }
        }
       
        thisTime.text = currtime.ToString("0.0");
        //gameObject.GetComponent<Timer>().currentTime.ToString("0.0");
        bestTime.text = manager.highScore.ToString("0.0");
    }
    public void rs()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        

    }
    public void Sl()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }



}
