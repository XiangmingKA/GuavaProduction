using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clothInteraction : MonoBehaviour
{
    public GameObject cursor;
    public bool held;

    // Start is called before the first frame update
    void Start()
    {
        held = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (held)
        {
            Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = cursorPos;
        }
    }

/*    void OnTriggerEnter2D(Collider2D other)
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

    private void OnMouseDown()
    {
        held = true;
    }

    private void OnMouseUp()
    {
        held = false;
    }
}
