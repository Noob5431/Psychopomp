using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    public float[] highScore = { -1, -1, -1 };
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }



}
