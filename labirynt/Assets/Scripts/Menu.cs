using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void Graj()
    {
        SceneManager.LoadScene("Gra");
    }

    public void WyjdzZGry()
    {
        Application.Quit();
    }
}
