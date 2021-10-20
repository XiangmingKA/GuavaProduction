using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour
{
    [Range(.0f, 20.0f)]
    public float range = 1.0f;
    [Range(.0f, 20.0f)]
    public float frequence = 1.0f;

    public float explosionRadius = 5.0f;

    Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = origin + Vector3.up * Mathf.Sin(frequence * Time.realtimeSinceStartup) * range;
    }

    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawLine(transform.position - Vector3.up * range, transform.position + Vector3.up * range);
    }
}
