using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene6GameManager : MonoBehaviour
{
    public GameObject scene6_1;
    public GameObject scene6_2;

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
        FlashBack(scene6_1);
        yield return new WaitForSeconds(stayTime);
        FlashBack(scene6_2);
        yield return new WaitForSeconds(stayTime - 3f);
        Scene3Movement.movable = true;

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

        if (sprite == scene6_2)
            LoadNextScene();
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
