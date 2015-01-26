using UnityEngine;
using System.Collections;

public class PlayerSprite : SpriteBase 
{
    public float maxDrag = 0.01f;
    public float minDrag = 0.01f;
    public float maxVelmag = 10;
	// Use this for initialization
	void Start ()
    {
        Init();
	}

    public override void Init()
    {
        base.Init();
    }

	// Update is called once per frame
	void Update ()
    {
        UpdateCanvasLocation();


	}
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {


        Vector3 velDir = rigidbody2D.velocity.normalized;
        float t = Vector3.Dot(velDir, transform.up);
        t = Mathf.Abs(t);
        t = 1 - t;
        float maxDrag = 5;
        float drag = Mathf.Lerp(minDrag, maxDrag, t);
        rigidbody2D.drag = drag;

        if (Input.GetKey(KeyCode.W))
        {
            t = rigidbody2D.velocity.magnitude / maxVelmag;
            t = Mathf.Clamp01(t);
            float actualForce = Mathf.Lerp(force, 0, t);
            transform.rigidbody2D.AddForce(transform.up * actualForce);
        }

        if (Input.GetKey(KeyCode.S))
        {
            // 
            t = rigidbody2D.velocity.magnitude / maxVelmag;
            t = Mathf.Clamp01(t);
            float actualForce = Mathf.Lerp(force, 0, t);
            transform.rigidbody2D.AddForce(-transform.up * actualForce);
        }



        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(transform.forward, rotateSpeed , Space.Self);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-transform.forward, rotateSpeed , Space.Self);
        }

    }


    void OnDrawGizmos()
    {
        Vector3 velDir = rigidbody2D.velocity.normalized;

        Gizmos.DrawLine(transform.position, transform.position + velDir*100);

        Gizmos.color = Color.red;

        Gizmos.DrawLine(transform.position, transform.position + transform.up*100);
    
    }
}


