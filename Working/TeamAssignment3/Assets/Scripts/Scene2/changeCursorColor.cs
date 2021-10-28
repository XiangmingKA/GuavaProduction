using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCursorColor : MonoBehaviour
{
    // the color that the user will paint on the clothes
    public static Color paintColor;

    void Start()
    {
        Cursor.visible = false;
        paintColor = Color.white;
    }

    void Update()
    {
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPos;
        GetComponent<SpriteRenderer>().color = paintColor;
    }

/*    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger");
        if (other.gameObject.CompareTag("cursor"))
        {
            Debug.Log("Trigger stay");
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Pressed primary button.");
                this.gameObject.GetComponent<Transform>().position = other.gameObject.GetComponent<Transform>().position;
            }
        }
    }*/
}
