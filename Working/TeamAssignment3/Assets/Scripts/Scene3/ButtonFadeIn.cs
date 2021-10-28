using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFadeIn : MonoBehaviour
{
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button.GetComponent<UnityEngine.UI.Image>().enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeIN()
    {
        StartCoroutine(Appear());
    }

    IEnumerator Appear()
    {
        float timer = .0f;
        float fadeInTime = 1f;

        UnityEngine.UI.Image renderer = button.GetComponent<UnityEngine.UI.Image>();

        yield return new WaitForSeconds(1f);
        button.SetActive(true);
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
