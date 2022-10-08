using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    Vector3 touchStart;
    public  bool doMovement;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float zoomMin = 10f;
    public float zoomMax = 80f;

    void Awake()
    {
        instance = this;
    }

    void FixedUpdate()
    {
        // Mover la cámara con el teclado
        if (Input.GetKey("w"))
        {
            transform.Translate(new Vector3(-1, 0, 1) * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(new Vector3(1, 0, -1) * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(new Vector3(1, 0, 1) * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(new Vector3(-1, 0, -1) * panSpeed * Time.deltaTime, Space.World);
        }

        // Hacer zoom con el ratón
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float size = Camera.main.orthographicSize;
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            zoom(difference * 0.01f, size);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Camera.main.transform.position += direction;
        }
        zoom(scroll, size);
    }

    void zoom(float increment, float size)
    {
        if (increment < 0)
        {
            size += 5;
        }else if(increment > 0) {
            size -= 5;
        }

        size = Mathf.Clamp(size, zoomMin, zoomMax);
        Camera.main.orthographicSize = size;
    }
}
