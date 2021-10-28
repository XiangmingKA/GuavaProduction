using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject scene2_1;
    public GameObject scene2_2;
    public GameObject scene2_3;
    public GameObject scene2_4;
    public GameObject scene2_5;
    public GameObject[] drawingItems2_3;
    public GameObject[] drawingItems2_4;
    public GameObject[] drawingItems2_5;
    public GameObject[] Items2_3;
    public GameObject[] Items2_4;
    public GameObject canvas;
    public GameObject[] buttons;

    public static bool NextButtonStatus;

    [Range(1f, 10f)]
    public float fadeInTime = 2.0f;
    [Range(1f, 10f)]
    public float stayTime = 6.0f;

    void Start()
    {
        NextButtonStatus = false;
        drawingItems2_3 = GameObject.FindGameObjectsWithTag("drawingItems2_3");
        drawingItems2_4 = GameObject.FindGameObjectsWithTag("drawingItems2_4");
        drawingItems2_5 = GameObject.FindGameObjectsWithTag("drawingItems2_5");
        Items2_3 = GameObject.FindGameObjectsWithTag("2_3items");
        Items2_4 = GameObject.FindGameObjectsWithTag("2_4items");
        buttons = GameObject.FindGameObjectsWithTag("button");
        StartCoroutine("ChangeScene");
    }
    void Update()
    {
        
    }

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(stayTime-2f);
        FlashBack(scene2_1);
        yield return new WaitForSeconds(stayTime);
        FlashBack(scene2_2);
    }
    IEnumerator ChangeScene2()
    {
        setClothesColor();
        ButtonGroupFlashBack(drawingItems2_3, Items2_3);
        yield return new WaitForSeconds(stayTime);
        GroupFlashBack(drawingItems2_4, Items2_4);
        Scene2Sound.instance.PlayLaughSound();
    }
    public void ButtonClick()
    {
        StartCoroutine("ChangeScene2");
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

    void setClothesColor()
    {
        for (int i = 0; i< drawingItems2_3.Length; i++)
        {
            drawingItems2_4[i].GetComponent<SpriteRenderer>().color = drawingItems2_3[i].GetComponent<SpriteRenderer>().color;
            drawingItems2_5[i].GetComponent<SpriteRenderer>().color = drawingItems2_3[i].GetComponent<SpriteRenderer>().color;
        }
    }

    void GroupFlashBack(GameObject[] sprites, GameObject[] items)
    {
        StartCoroutine(GroupFadeOut(sprites,items));
    }
    IEnumerator GroupFadeOut(GameObject[] sprites, GameObject[] items)
    {
        float timer = .0f;
        //yield return new WaitForSeconds(stayTime);

        timer = .0f;
        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;
            foreach (var sprite in sprites)
            {
                SpriteRenderer renderer = sprite.GetComponent<SpriteRenderer>();
                Color newColor = renderer.color;
                newColor.a = 1.0f - (timer / fadeInTime);
                renderer.color = newColor;
            }
            foreach (var item in items)
            {
                SpriteRenderer renderer = item.GetComponent<SpriteRenderer>();
                Color newColor = renderer.color;
                newColor.a = 1.0f - (timer / fadeInTime);
                renderer.color = newColor;
            }


            yield return null;
        }
        foreach (var sprite in sprites)
        {
            sprite.SetActive(false);
        }
        foreach (var item in items)
        {
            item.SetActive(false);
        }
    }
    void ButtonGroupFlashBack(GameObject[] sprites, GameObject[] items)
    {
        StartCoroutine(ButtonGroupFadeOut(sprites, items));
    }
    IEnumerator ButtonGroupFadeOut(GameObject[] sprites, GameObject[] items)
    {
        float timer = .0f;
        //yield return new WaitForSeconds(stayTime);

        timer = .0f;
        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;
            foreach (var sprite in sprites)
            {
                SpriteRenderer renderer = sprite.GetComponent<SpriteRenderer>();
                Color newColor = renderer.color;
                newColor.a = 1.0f - (timer / fadeInTime);
                renderer.color = newColor;
            }
            foreach (var item in items)
            {
                SpriteRenderer renderer = item.GetComponent<SpriteRenderer>();
                Color newColor = renderer.color;
                newColor.a = 1.0f - (timer / fadeInTime);
                renderer.color = newColor;
            }
            foreach (var button in buttons)
            {
                UnityEngine.UI.Image img = button.GetComponent<UnityEngine.UI.Image>();
                Color newColor = img.color;
                newColor.a = 1.0f - (timer / fadeInTime);
                img.color = newColor;
            }


            yield return null;
        }
        foreach (var sprite in sprites)
        {
            sprite.SetActive(false);
        }
        foreach (var item in items)
        {
            item.SetActive(false);
        }
        canvas.SetActive(false);
    }
}
