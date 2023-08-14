using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuinicial : MonoBehaviour
{
    public void jugar()
    {
        SceneManager.LoadScene("Level1");
    }

    public void salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
