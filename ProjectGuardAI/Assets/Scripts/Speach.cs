using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Speach : MonoBehaviour
{
    public Text textMain;
    public Text textShadow;

	// Use this for initialization
	void Start ()
    {
        if (textMain == null || textShadow == null)
        {
            Debug.Log("tex null");
            Debug.Break();
        }


 	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void SetText(string text  )
    {
        textMain.text = text;
        textShadow.text = text;

        StartCoroutine("Fade");
    }


    IEnumerator Fade()
    {

        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            SetAplha(f);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void SetAplha(float f)
    {
        Color c = textMain.color;
        c.a = f;
        textMain.color = c;

        c = textShadow.color;
        c.a = f;
        textShadow.color = c;
    }
}
