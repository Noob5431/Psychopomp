using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenu : MonoBehaviour
{
    gamemanager manager;
    [SerializeField] Text lv1;
    private void Start()
    {
        manager = GameObject.Find("gameManager").GetComponent<gamemanager>();
    }
    public void Playgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void Quitgame()
    {
        Application.Quit();
    }
    private void Update()
    {
        if(manager.highScore ==-1)
        {
            lv1.text = "None";
        }else
        lv1.text = manager.highScore.ToString("0.0");
    }
}
