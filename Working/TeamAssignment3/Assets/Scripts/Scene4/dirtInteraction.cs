using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirtInteraction : MonoBehaviour
{
    public GameObject nextDirt;

    void Start()
    {
    }


    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cloth")){
            this.gameObject.SetActive(false);
            if(nextDirt!=null)
                nextDirt.SetActive(true);
        }
    }
}
