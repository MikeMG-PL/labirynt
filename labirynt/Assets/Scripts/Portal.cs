using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject gracz;
    public GameObject panel1;
    public GameObject panel2;
    MenedzerGry menedzerGry;

    private void OnTriggerEnter(Collider other)
    {
        menedzerGry = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenedzerGry>();
        menedzerGry.czyZliczaCzas = false;
        gracz.GetComponent<Poruszanie>().enabled = false;
        gracz.GetComponent<Latarka>().enabled = false;
        gracz.GetComponent<Znacznik>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        panel1.SetActive(true);
        panel2.SetActive(false);
    }
}
