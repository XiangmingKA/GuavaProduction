using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExitGame());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ExitGame()
    {
        yield return new WaitForSeconds(5f);
        Application.Quit();
    }
}
