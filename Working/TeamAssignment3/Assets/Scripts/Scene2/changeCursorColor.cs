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
}
