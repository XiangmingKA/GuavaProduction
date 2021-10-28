using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scene5Manager : MonoBehaviour
{
    public GameObject jump1;
    public GameObject jump2;
    public GameObject jump3;
    public GameObject Blackout;
    public GameObject EndImg;
    public GameObject End;
    public UnityEngine.Video.VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        jump1.SetActive(false);
        jump2.SetActive(false);
        jump3.SetActive(false);
        Blackout.SetActive(false);
        End.SetActive(false);
        EndImg.SetActive(false);
        StartCoroutine(FadeInAndOut(0f, jump1));
        StartCoroutine(FadeInAndOut(2f, jump2));
        StartCoroutine(FadeInAndOut(4f, jump3));
        StartCoroutine(FadeInAndOut(6f, Blackout));
        StartCoroutine(LastScene(6f, End));
        StartCoroutine(FadeIn(10f, EndImg));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LastScene(float delay, GameObject sprite)
    {
        videoPlayer.Prepare();
        yield return new WaitForSeconds(delay);
        sprite.SetActive(true);
        videoPlayer.Play();

        yield return new WaitForSeconds(7f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);

    }


    float fadeInTime = 1.0f;
    float stayTime = 1.0f;
    IEnumerator FadeInAndOut(float delay, GameObject sprite)
    {
        SpriteRenderer renderer = sprite.GetComponent<SpriteRenderer>();
        float timer = .0f;

        yield return new WaitForSeconds(delay);

        sprite.SetActive(true);

        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;

            Color newColor = renderer.color;
            newColor.a = timer / fadeInTime;
            renderer.color = newColor;

            yield return null;
        }

        yield return new WaitForSeconds(stayTime);

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

    IEnumerator FadeIn(float delay, GameObject sprite)
    {
        SpriteRenderer renderer = sprite.GetComponent<SpriteRenderer>();
        float timer = .0f;

        yield return new WaitForSeconds(delay);

        sprite.SetActive(true);

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
