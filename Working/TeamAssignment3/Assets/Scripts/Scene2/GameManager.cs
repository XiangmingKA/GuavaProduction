using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ChangeScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(4f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex+1);
    }

}
