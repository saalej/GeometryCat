using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Motion : MonoBehaviour
{
    bool canJump = false;
    public float speed = 1000.0f;
    public float height = 100f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left")) 
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed * Time.deltaTime, 0f));
        }
        if (Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * Time.deltaTime, 0f));
        }

        if (Input.GetKeyDown("up") && canJump)
        {
            canJump = false;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, height));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == ("ground"))
        {
            canJump = true;
        }
    }
}
