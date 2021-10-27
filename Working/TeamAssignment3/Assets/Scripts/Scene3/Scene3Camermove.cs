using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class Scene3Camermove : MonoBehaviour
{
    [Serializable]
    public struct CameraMovement
    {
        public Transform pos;
        public UnityEvent OnMoveStart;
        public UnityEvent OnMoveEnd;
    }

    [SerializeField]
    public List<CameraMovement> cameraMovements;

    [Range(.0f, 10f)]
    public float intertvalTime = 3f;
    [Range(.0f, 10f)]
    public float moveTime = 3f;

    int currentIndex = 0;

    void Start()
    {
        transform.position = cameraMovements[0].pos.position;
        StartCoroutine(MoveNext());
    }

    IEnumerator CameraMove()
    {
        cameraMovements[currentIndex + 1].OnMoveStart?.Invoke();

        float timer = .0f;
        while(timer < moveTime)
        {
            timer += Time.deltaTime;
            Vector3 pos1 = cameraMovements[currentIndex].pos.position;
            Vector3 pos2 = cameraMovements[currentIndex + 1].pos.position;
            transform.position = Vector3.Lerp(pos1, pos2, Mathf.Sin((timer / moveTime) * (Mathf.PI / 2f)));
            yield return null;
        }

        cameraMovements[currentIndex + 1].OnMoveEnd?.Invoke();

        if (currentIndex < cameraMovements.Count - 2)
        {
            currentIndex++;
            StartCoroutine(MoveNext());
        }
    }

    IEnumerator MoveNext()
    {
        yield return new WaitForSeconds(intertvalTime);
        StartCoroutine(CameraMove());
    }

    public void CameraZoomIn()
    {
        StartCoroutine(ZoomIn(2.0f, 1.75f));
    }

    IEnumerator ZoomIn(float time, float size)
    {
        Camera camera = GetComponent<Camera>();

        float timer = .0f;
        float startSize = camera.orthographicSize;
        float targetSize = size;

        while (timer < time)
        {
            timer += Time.deltaTime;

            float newSize = Mathf.Lerp(startSize, targetSize, timer / time);
            camera.orthographicSize = newSize;

            yield return null;
        }
    }
}
