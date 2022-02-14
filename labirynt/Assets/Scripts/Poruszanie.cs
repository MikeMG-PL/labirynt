using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Poruszanie : MonoBehaviour
{
    public float predkoscChodu = 4f;
    public float predkoscBiegu = 8f;
    public float silaSkoku = 6f;
    public float grawitacja = 15f;
    public Camera kameraGracza;
    public float czuloscMyszy = 2.0f;
    public float zakresWidoku = 45.0f;
    public bool czyBiegnie;

    CharacterController characterController;
    public Vector3 kierunekRuchu = Vector3.zero;
    float rotacjaX = 0;
    float rotacjaY = 0;

    Transform transformKamery;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        transformKamery = kameraGracza.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rotacjaX += kameraGracza.transform.localEulerAngles.x;
        rotacjaY += kameraGracza.transform.localEulerAngles.y;
    }

    void Update()
    {
        Vector3 przod = transformKamery.TransformDirection(Vector3.forward);
        Vector3 prawo = transformKamery.TransformDirection(Vector3.right);

        czyBiegnie = Input.GetKey(KeyCode.LeftShift);
        float predkoscX = (czyBiegnie ? predkoscBiegu : predkoscChodu) * Input.GetAxis("Vertical");
        float predkoscY = (czyBiegnie ? predkoscBiegu : predkoscChodu) * Input.GetAxis("Horizontal");
        float kierunekRuchuY = kierunekRuchu.y;
        if (characterController.isGrounded) kierunekRuchu = (przod * predkoscX) + (prawo * predkoscY);

        if (Input.GetKeyDown(KeyCode.Space) && characterController.isGrounded)
            kierunekRuchu.y = silaSkoku;
        else
            kierunekRuchu.y = kierunekRuchuY;

        if (!characterController.isGrounded) kierunekRuchu.y -= grawitacja * Time.deltaTime;

        characterController.Move(kierunekRuchu * Time.deltaTime);

        rotacjaX += -Input.GetAxis("Mouse Y") * czuloscMyszy;
        rotacjaX = Mathf.Clamp(rotacjaX, -zakresWidoku, zakresWidoku);
        rotacjaY += Input.GetAxis("Mouse X") * czuloscMyszy;
        transformKamery.localRotation = Quaternion.Euler(rotacjaX, rotacjaY, 0);
    }
}