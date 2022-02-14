using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Latarka : MonoBehaviour
{
    public Transform transformLatarki;
    public float katOpuszczenia = 70f;
    Vector3 dol;

    void Start()
    {
        dol = new Vector3(katOpuszczenia, 0, 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
            transformLatarki.localEulerAngles = dol;

        if (Input.GetKeyUp(KeyCode.LeftShift))
            transformLatarki.localEulerAngles = Vector3.zero;
    }
}
