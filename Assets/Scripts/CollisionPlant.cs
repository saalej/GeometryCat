using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlant : MonoBehaviour
{
    [SerializeField] GameObject _newObject; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _newObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}


