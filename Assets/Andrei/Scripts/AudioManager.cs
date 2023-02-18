using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    AudioSource land,running;
    bool isGrounded = true, oldIsGrounded = true;

    private void Update()
    {
        oldIsGrounded = isGrounded;
        isGrounded = GetComponentInParent<Movement>().isGrounded;
        if(isGrounded && !oldIsGrounded)
        {
            land.Play();
        }
        if (GetComponentInParent<Movement>().isRunning)
        {
            running.Play();
        }
        //else running.Stop();
    }
}
