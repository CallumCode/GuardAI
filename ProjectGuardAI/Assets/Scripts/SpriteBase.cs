using UnityEngine;
using System.Collections;

public class SpriteBase : MonoBehaviour 
{
	const float maxHealth = 100;
	float health = maxHealth;

    float force = 15;
    float rotateSpeed = 20;

    float minDrag = 0.75f;
    float maxDrag = 10.0f;
 	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	        // test code

        if(Input.GetKey(KeyCode.W))
        {

            transform.rigidbody2D.AddForce(transform.up * Time.deltaTime * force);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(transform.forward, rotateSpeed * Time.deltaTime, Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-transform.forward, rotateSpeed * Time.deltaTime, Space.Self);
        }
	}

  
}
