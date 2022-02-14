using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Znacznik : MonoBehaviour
{
    public GameObject znacznik;
    public Camera kamera;
    public int znaczniki = 100;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && znaczniki > 0)
        {
            Instantiate(znacznik, transform.position + kamera.transform.forward + kamera.transform.up, Quaternion.identity);
            znaczniki--;
        }

    }
}
