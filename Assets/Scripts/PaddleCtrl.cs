using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleCtrl : MonoBehaviour
{
    public float speed;
    public float direction;
    public float adjustSpeed;

    public Transform rightLimit;
    public Transform leftLimit;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            direction = 1;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            direction = -1;
        }
        else
        {
            direction = 0;
        }

        if(transform.position.x > rightLimit.position.x)
        {
            transform.position = new Vector3(rightLimit.position.x, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < leftLimit.position.x)
        {
            transform.position = new Vector3(leftLimit.position.x, transform.position.y, transform.position.z);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x + (direction * adjustSpeed), other.rigidbody.velocity.y);
        Debug.Log(other.rigidbody.velocity);
    }
}