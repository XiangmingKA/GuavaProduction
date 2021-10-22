using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeClothesColor : MonoBehaviour
{
    bool IsTriggered;
    // Start is called before the first frame update
    void Start()
    {
        IsTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(IsTriggered && Input.GetMouseButtonDown(0))
        {
            this.GetComponent<SpriteRenderer>().color = changeCursorColor.paintColor;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cursor"))
        {
            IsTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("cursor"))
        {
            IsTriggered = false;
        }
    }
}