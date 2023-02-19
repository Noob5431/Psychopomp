using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    [SerializeField]
    finisshmenu finishScript;

    private void OnTriggerEnter(Collider other)
    {
        finishScript.isFinished = true;
    }
}
