using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuinicial : MonoBehaviour
{
    public void jugar()
    {
        SceneManager.LoadScene("Game");
    }

    public void salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}
