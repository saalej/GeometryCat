using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    [SerializeField] private Move playerController;
    [SerializeField] private Move player2Controller;
    [SerializeField] private Move player3Controller;

    private void Start()
    {
        playerController.enabled = true;
        player2Controller.enabled = false;
        player3Controller.enabled = false;
    }

    void Update()
    { 
        if(Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.C))
        {
            SwithcPlayer();
        }
    }

    public void SwithcPlayer()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerController.enabled = true;
            player2Controller.enabled = false;
            player3Controller.enabled = false;
        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            playerController.enabled = false;
            player2Controller.enabled = true;
            player3Controller.enabled = false;
        } else if (Input.GetKeyDown(KeyCode.C))
        {
            playerController.enabled = false;
            player2Controller.enabled = false;
            player3Controller.enabled = true;
        }
    }
}
