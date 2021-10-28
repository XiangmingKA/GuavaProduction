using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LogoScene : MonoBehaviour
{
    UnityEngine.Video.VideoPlayer videoPlayer;
    bool isLoading = false;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(videoPlayer.isPaused && !isLoading)
        {
            LoadNextScene();
        }
    }

    void LoadNextScene()
    {
        isLoading = true;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
