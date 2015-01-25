using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteAnimCon))]
[RequireComponent(typeof(AudioSource))]

public class SpriteBase : MonoBehaviour
{
    public GameObject canvasPrefab;
    public GameObject hpSliderPrefab;

    GameObject canvasObject;
    GameObject hpSliderObject;

    public Vector3 canvasOffset = new Vector3(0, 1, 0);
    protected Slider healthSlider;

    const float maxHealth = 100;
    protected float health = maxHealth;

    public  float force = 100;
    float rotateSpeed = 20;

    SpriteAnimCon spriteAnimCon;

    protected AudioSource deathSound;




    // Use this for initialization
    void Start()
    {
        Init();
    }

    void GetSounds()
    {
        AudioSource[] AudioSources = GetComponents<AudioSource>();

        deathSound = AudioSources[0];

    }

    public virtual void Init()
    {

        spriteAnimCon = GetComponent<SpriteAnimCon>();

        canvasObject = Instantiate(canvasPrefab, transform.position, transform.rotation) as GameObject;
        hpSliderObject = Instantiate(hpSliderPrefab, canvasObject.transform.position + canvasOffset, canvasObject.transform.rotation) as GameObject;
        hpSliderObject.transform.SetParent(canvasObject.transform);

        healthSlider = hpSliderObject.GetComponent<Slider>();
     }

    protected void UpdateCanvasLocation()
    {
        canvasObject.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        TestControls();
        UpdateCanvasLocation();
    }

    void TestControls()
    {

        if (Input.GetKey(KeyCode.W))
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

        if (Input.GetKey(KeyCode.Alpha1))
        {
            StartDeath();
        }

    }


    protected void StartDeath()
    {
        float length = spriteAnimCon.CallDeathAnimation();
        Invoke("EndDeath", length);
    }

    void EndDeath()
    {
        Destroy(gameObject);
    }


    public void TakeDamage(float amount)
    {
        health -= amount;
        health = Mathf.Clamp(health, 0, maxHealth);

        healthSlider.value = health;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        DoCollision(coll);
    }

    protected virtual void DoCollision(Collision2D coll)
    {

    }


}
