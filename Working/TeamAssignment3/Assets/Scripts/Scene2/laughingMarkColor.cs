using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laughingMarkColor : MonoBehaviour
{
    public static laughingMarkColor instance;
    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }
        

    public void setLaughingColor()
    {
        GetComponent<SpriteRenderer>().color = obj.GetComponent<SpriteRenderer>().color;
    }
}
