using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finisshmenu : MonoBehaviour
{
    [SerializeField] Text thisTime;
    [SerializeField] Text bestTime;
   void Update()
    {
        thisTime.text = "23";
        //gameObject.GetComponent<Timer>().currentTime.ToString("0.0");
        bestTime.text = "21";
    }
   


}
