using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sandwich : MonoBehaviour
{
    public GameObject[] objs;
    int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        objs = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            objs[i] = transform.GetChild(i).gameObject;
        }


        foreach (var i in objs)
        {
            i.SetActive(false);
        }
    }

    public void SandwichAppear()
    {
        StartCoroutine(Appear());
    }

    IEnumerator Appear()
    {
        float timer = .0f;
        float fadeInTime = 1f;

        SpriteRenderer renderer = objs[0].GetComponent<SpriteRenderer>();

        yield return new WaitForSeconds(1f);
        objs[0].SetActive(true);
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

    bool loading = false;

    public void EatSandwich()
    {
        objs[currentIndex].SetActive(false);
        if(currentIndex < objs.Length - 1)
        {
            objs[++currentIndex].SetActive(true);
        }
        else
        {
            LoadNextScene();
        }

    }

    void LoadNextScene()
    {
        if (!loading)
        {
            StartCoroutine(WaitAndLoadNextScene());
            loading = true;
        }
    }

    IEnumerator WaitAndLoadNextScene()
    {
        yield return new WaitForSeconds(2f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
