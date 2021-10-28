using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    public GameObject threeYearsOld;
    public GameObject sixYearsOld;
    public GameObject tenYearsOld;

    public GameObject threeYearsOldMemory;
    public GameObject sixYearsOldMemory;
    public GameObject tenYearsOldMemory;

    public GameObject[] footSteps;
    [Range(1, 10)]
    public int footstepsToNext = 4;

    [Range(1f, 10f)]
    public float fadeInTime = 2.0f;
    [Range(1f, 10f)]
    public float stayTime = 3.0f;

    int currentInteractionIndex = 0;
    int currentFootstepIndex = 0;

    bool bottonActive = true;
    // Start is called before the first frame update
    void Start()
    {
        threeYearsOld.SetActive(false);
        sixYearsOld.SetActive(false);
        tenYearsOld.SetActive(false);
        threeYearsOldMemory.SetActive(false);
        sixYearsOldMemory.SetActive(false);
        tenYearsOldMemory.SetActive(false);
        foreach (var i in footSteps)
        {
            i.SetActive(false);
        }

        SpriteAppear(threeYearsOld);
        FlashBack(threeYearsOldMemory);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonDown()
    {
        if(bottonActive)
        {
            currentInteractionIndex++;
            if (currentInteractionIndex == 5)
            {
                SpriteAppear(sixYearsOld);
                FlashBack(sixYearsOldMemory);
            }
            else if (currentInteractionIndex == 10)
            {
                SpriteAppear(tenYearsOld);
                FlashBack(tenYearsOldMemory);
                StartCoroutine(LoadNextScene());
            }
            else
            {
                SpriteAppear(footSteps[currentFootstepIndex++]);
            }
        }
        
    }

    void SpriteAppear(GameObject obj)
    {
        obj.SetActive(true);
        StartCoroutine(SpriteFadeIn(obj));
    }

    IEnumerator SpriteFadeIn(GameObject sprite)
    {
        SpriteRenderer renderer = sprite.GetComponent<SpriteRenderer>();
        float timer = .0f;
        while(timer < fadeInTime)
        {
            timer += Time.deltaTime;

            Color newColor = renderer.color;
            newColor.a = timer / fadeInTime;
            renderer.color = newColor;

            yield return null;
        }
    }

    void FlashBack(GameObject sprite)
    {
        StartCoroutine(FadeInAndOut(sprite));
    }

    IEnumerator FadeInAndOut(GameObject sprite)
    {
        bottonActive = false;
        SpriteRenderer renderer = sprite.GetComponent<SpriteRenderer>();
        float timer = .0f;

        yield return new WaitForSeconds(fadeInTime);

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
            newColor.a =  1.0f - (timer / fadeInTime);
            renderer.color = newColor;

            yield return null;
        }

        sprite.SetActive(false);
        bottonActive = true;
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(fadeInTime * 2 + stayTime);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public GameObject button;
    IEnumerator ButtonFadeOut()
    {
        UnityEngine.UI.Image img = button.GetComponent<UnityEngine.UI.Image>();
        float timer = .0f;
        while (timer < fadeInTime)
        {
            timer += Time.deltaTime;

            Color newColor = img.color;
            newColor.a = 1.0f - (timer / fadeInTime);
            img.color = newColor;

            yield return null;
        }
    }
}
