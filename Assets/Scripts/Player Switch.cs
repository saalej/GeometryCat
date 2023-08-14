using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
    [Header("Player Controllers")]
    [SerializeField] private Move playerController;
    [SerializeField] private Move player2Controller;
    [SerializeField] private Move player3Controller;

    [Header("Worlds")]
    [SerializeField] private GameObject _pinkWorld;
    [SerializeField] private GameObject _yellowWorld;
    [SerializeField] private GameObject _blueWorld;

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

            _pinkWorld.SetActive(false);
            _yellowWorld.SetActive(true);
            _blueWorld.SetActive(false);

        }
        else if(Input.GetKeyDown(KeyCode.X))
        {
            playerController.enabled = false;
            player2Controller.enabled = true;
            player3Controller.enabled = false;

            _pinkWorld.SetActive(true);
            _yellowWorld.SetActive(false);
            _blueWorld.SetActive(false);
        } else if (Input.GetKeyDown(KeyCode.C))
        {
            playerController.enabled = false;
            player2Controller.enabled = false;
            player3Controller.enabled = true;

            _pinkWorld.SetActive(false);
            _yellowWorld.SetActive(false);
            _blueWorld.SetActive(true);
        }
    }
}
