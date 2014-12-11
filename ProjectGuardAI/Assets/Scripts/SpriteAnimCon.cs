using UnityEngine;
using System.Collections;

    [RequireComponent(typeof(Animator))]

public class SpriteAnimCon : MonoBehaviour 
{
    Animator anim;
    

	// Use this for initialization
	void Start () 
    {

        anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () 
    {

        anim.SetFloat("speed",  rigidbody2D.velocity.magnitude);

	}
}
