using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene4GameManger : MonoBehaviour
{
    public GameObject scene4_1;
    public GameObject scene4_2;
    public GameObject scene4_3;
    public GameObject scene4_4;
    public GameObject scene4_6;

    public static bool NextButtonStatus;

    [Range(1f, 10f)]
    public float fadeInTime = 2.0f;
    [Range(1f, 10f)]
    public float stayTime = 6.0f;

    void Start()
    {
        NextButtonStatus = false;
        StartCoroutine("ChangeScene");
    }
    void Update()
    {

    }

    IEnumerator ChangeScene()
    {
        Cursor.visible = false;
        yield return new WaitForSeconds(stayTime - 2f);
        FlashBack(scene4_1);
        yield return new WaitForSeconds(stayTime);
        FlashBack(scene4_2);
        yield return new WaitForSeconds(stayTime);
        FlashBack(scene4_3);
        yield return new WaitForSeconds(stayTime);
        FlashBack(scene4_4);
        yield return new WaitForSeconds(stayTime);
        FlashBack(scene4_6);
        Cursor.visible = true;
    }

    void FlashBack(GameObject sprite)
    {
        StartCoroutine(FadeOut(sprite));
    }

    IEnumerator FadeOut(GameObject sprite)
    {
        SpriteRenderer renderer = sprite.GetComponent<SpriteRenderer>();
        float timer = .0f;
        //yield return new WaitForSeconds(stayTime);

        timer = .0f;
        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;

            Color newColor = renderer.color;
            newColor.a = 1.0f - (timer / fadeInTime);
            renderer.color = newColor;

            yield return null;
        }

        sprite.SetActive(false);
    }
}
