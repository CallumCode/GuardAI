using UnityEngine;
using System.Collections;

public class FogOfWar : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        player.renderer.material.SetVector("_Pos", transform.position);
	}
}
