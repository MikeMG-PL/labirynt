using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MenedzerGry : MonoBehaviour
{
    [HideInInspector()] public float czas = 0;
    public Znacznik znacznik;
    [HideInInspector()] public float znaczniki;
    public Text _czas;
    public Text _czasKoncowy;
    public Text _znaczniki;

    public bool czyZliczaCzas = true;

    private void Update()
    {
        if(czyZliczaCzas) czas += Time.deltaTime;
        else
        {
            System.TimeSpan t = System.TimeSpan.FromSeconds(czas);
            _czasKoncowy.text = "CZAS: " + string.Format("{0:00}:{1:00}:{2:00}", t.Minutes, t.Seconds, t.Milliseconds - (t.Milliseconds - (t.Milliseconds / 10)));
        }

        Wyswietlanie();

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    void Wyswietlanie()
    {
        znaczniki = znacznik.znaczniki;
        System.TimeSpan t = System.TimeSpan.FromSeconds(czas);
        _czas.text = "Czas: " + string.Format("{0:00}:{1:00}:{2:00}", t.Minutes, t.Seconds, t.Milliseconds - (t.Milliseconds - (t.Milliseconds/10)));
        _znaczniki.text = "Znaczniki: " + znaczniki;
    }
}
