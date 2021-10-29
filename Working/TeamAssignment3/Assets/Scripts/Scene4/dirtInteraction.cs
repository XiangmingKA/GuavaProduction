using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dirtInteraction : MonoBehaviour
{
    public GameObject nextDirt;
    public GameObject DirtInMirror;
    [SerializeField] public int dirtIndex;

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
            DirtInMirror.SetActive(false);
            Scene4GameManger.dirtWiped[dirtIndex] = true;

            if (nextDirt!=null)
                nextDirt.SetActive(true);
        }
    }
}
