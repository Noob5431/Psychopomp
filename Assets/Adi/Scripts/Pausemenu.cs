using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausemenu : MonoBehaviour
{
    public GameObject startText;

    [SerializeField] public  bool GameIsPaused = false;
    [SerializeField] public  bool GameHasStarted = false;
    public GameObject pauseMenuUI;

   
    void Update()
    {
        if(GameHasStarted == false)
        {
        Time.timeScale =0f;
        if (Input.GetKeyDown(KeyCode.Space))
        {
                startText.SetActive(false) ;
            Time.timeScale =1f;
            GameHasStarted = true;
        }
        }



        if (GameHasStarted == true && gameObject.GetComponent<finisshmenu>().LevelOver == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();

                }
                else
                {
                    Pause();
                }
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale =1f;
        GameIsPaused =false; 
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale =0f;
        GameIsPaused =true; 
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
        GameIsPaused =false; 
        GameHasStarted = false;
        Time.timeScale =1f;
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameIsPaused =false; 
        GameHasStarted = false;
        Time.timeScale =1f;
    }
}
