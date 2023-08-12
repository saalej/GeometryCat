using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    [SerializeField] public  Behaivour playerController;
    [SerializeField] public  Behaivour Player2Controller;
    [SerializeField] public  bool player1Active = true;

    // Update is called once per frame
    void Update()
    { 
        if(input.GetkeyDown(KeyCode.RightSift))
        {
            SwithcPlayer();
        }
    }

    public void SwithcPlayer()
    {
        if (player1Active)
        {
            playerController.enabled = false;
            Player2Controller.enabled = true;
            player1Active = false;
        }
        else
        {
            playerController.enabled = true;
            Player2Contr    oller.enabled = false;
            player1Active = true;
        }
    }
}
