using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField]
    public float gravity;

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity -= new Vector3(0, gravity * Time.fixedDeltaTime, 0);
    }
}
