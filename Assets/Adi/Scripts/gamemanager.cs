using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public float highScore;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }



}
