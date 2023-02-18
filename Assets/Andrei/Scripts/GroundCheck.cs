using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ground"))
            GetComponentInParent<Movement>().isGrounded = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ground"))
            GetComponentInParent<Movement>().isGrounded = false;
    }
}
