using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    ColocatorManager colocatorManager;
    HUD_Manager hudManager;
    
    public  bool doMovement;

    public float panSpeed = 30f;
    public float panBorderThickness = 10f;

    public float zoomMin = 10f;
    public float zoomMax = 80f;

    Vector3 touchStart;
    bool cameraIsMove = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        colocatorManager = ColocatorManager.instance;
        hudManager = HUD_Manager.instance;
    }

    void FixedUpdate()
    {
        // Bloquear movimiento de la cámara con el ratón
        if (Input.GetKeyDown(KeyCode.L))
        {
            doMovement = !doMovement;
        }

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

            cameraIsMove = true;
        }

        if (Input.touchCount == 2 && doMovement && !colocatorManager.canBuild && !hudManager.isShowInfo)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            Zoom(difference * 0.01f, size);
        }
        else if (Input.GetMouseButton(0) && doMovement && !colocatorManager.canBuild && !hudManager.isShowInfo && cameraIsMove)
        {
            Vector3 direction = touchStart - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = new Vector3(direction.x, 0, direction.z);
            Camera.main.transform.position += direction;
        }

        if (Input.GetMouseButtonUp(0))
        {
            cameraIsMove = false;
        }

        Zoom(scroll, size);
    }

    public void Zoom(float increment, float size)
    {
        if (increment < 0)
        {
            size += 5;
        }
        else if(increment > 0) 
        {
            size -= 5;
        }

        size = Mathf.Clamp(size, zoomMin, zoomMax);
        Camera.main.orthographicSize = size;
    }
}
