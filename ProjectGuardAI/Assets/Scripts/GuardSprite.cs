using UnityEngine;
using System.Collections;

public class GuardSprite : SpriteBase
{
    enum memoryAlertStateType { ok, odd, alarmingOdd, seen, looking };
    enum currentAlertStateType { ok, odd, alarmingOdd, inSight, combat };

    currentAlertStateType currentAlertState = currentAlertStateType.ok;


    public GameObject speachPrefab;
    GameObject speachObject;
    Speach speachScript;
     
    public Vector3 speachOffset;


    public GameObject sightObject;
    // Use this for initialization
    void Start()
    {
        Init();
    }

    public override void Init()
    {
        base.Init();
        speachObject = Instantiate(speachPrefab, canvasObject.transform.position + speachOffset, speachPrefab.transform.rotation) as GameObject;
        speachObject.transform.SetParent(canvasObject.transform);   
        speachScript = speachObject.GetComponent<Speach>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCanvasLocation();
     }

    protected override void DoCollision(Collision2D coll)
    {
        if (speachScript)
        {
            speachScript.SetText("Ouch");
        }
    }


    public void EnemySighted()
    {
        speachScript.SetText("Player Sighted");
    }

    /*
    void UpdateSates()
    {
        switch (currentAlertState)
        {
            case currentAlertStateType.ok:
                {

                }
                break;
            case currentAlertStateType.odd:
                {

                }
                break;

            case currentAlertStateType.alarmingOdd:
                {

                }
                break;
            case currentAlertStateType.inSight:
                {

                }
                break;
            case currentAlertStateType.combat:
                {

                }
                break;

        }
    }*/

}
