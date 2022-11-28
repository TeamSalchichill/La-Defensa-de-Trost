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
        doMovement = true;

        colocatorManager = ColocatorManager.instance;
        hudManager = HUD_Manager.instance;
    }

    void Update()
    {
        if (!doMovement)
        {
            return;
        }

        transform.position = new(transform.position.x, 50, transform.position.z);

        // Mover la cámara con el teclado
        RaycastHit HitInfo;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out HitInfo, 100.0f);

        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.up * panSpeed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.down * panSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime);
        }
        if (Input.GetKey("q"))
        {
            transform.RotateAround (HitInfo.point, Vector3.up, 90 * Time.deltaTime);
        }
        if (Input.GetKey("e"))
        {
            transform.RotateAround(HitInfo.point, -Vector3.up, 90 * Time.deltaTime);
        }

        // Hacer zoom con el ratón
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float size = Camera.main.orthographicSize;

        if (Input.GetMouseButtonDown(0))
        {
            touchStart = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            cameraIsMove = true;
        }
        if (Input.GetMouseButton(0) && cameraIsMove && doMovement)
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

        if (transform.position.x > 150)
        {
            transform.position = new Vector3(150, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -50)
        {
            transform.position = new Vector3(-50, transform.position.y, transform.position.z);
        }
        if (transform.position.z > 70)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 70);
        }
        if (transform.position.z < -128)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -128);
        }
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

    public void CameraCanMove()
    {
        doMovement = false;
        Invoke("InvokeCameraCanMove", 0.25f);
    }
    public void InvokeCameraCanMove()
    {
        doMovement = true;
    }
}
