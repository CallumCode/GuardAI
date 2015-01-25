using UnityEngine;
using System.Collections;

public class GuardSprite : SpriteBase
{

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
}
