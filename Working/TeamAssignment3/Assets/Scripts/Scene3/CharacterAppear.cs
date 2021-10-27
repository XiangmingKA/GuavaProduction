using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAppear : MonoBehaviour
{
    [Range(.0f, 10f)]
    public float fadeInTime = 2f;
    GameObject textObj;
    public GameObject[] rejectMarkObjs;

    void Start()
    {
        textObj = transform.Find("text").gameObject;
        GetComponent<SpriteRenderer>().enabled = false;
        textObj.GetComponent<SpriteRenderer>().enabled = false;

        foreach(var i in rejectMarkObjs)
        {
            i.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CharacterFadeIn()
    {
        StartCoroutine(Appear(.0f, gameObject)); 
    }

    public void TextFadeIn()
    {
        StartCoroutine(Appear(1.0f, textObj));
    }

    public void MarkFadeIn()
    {
        foreach (var i in rejectMarkObjs)
        {
            StartCoroutine(Appear(1.5f, i));
        }
    }

    IEnumerator Appear(float waitTime, GameObject obj)
    {
        yield return new WaitForSeconds(waitTime);

        SpriteRenderer renderer = obj.GetComponent<SpriteRenderer>();
        float timer = .0f;

        renderer.enabled = true;

        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;

            Color newColor = renderer.color;
            newColor.a = timer / fadeInTime;
            renderer.color = newColor;

            yield return null;
        }
    }
}
