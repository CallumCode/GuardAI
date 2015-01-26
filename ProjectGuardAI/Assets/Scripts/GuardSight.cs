using UnityEngine;
using System.Collections;

public class GuardSight : MonoBehaviour {


    GuardSprite GuardSpriteScript;

	// Use this for initialization
	void Start ()
    {
        GuardSpriteScript = GetComponentInParent<GuardSprite>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.collider2D)
        {
            Debug.Log(other.collider2D.tag);

            if (other.collider2D.CompareTag("Player"))
            {
                GuardSpriteScript.EnemySighted();
            }

        }
    }
}
