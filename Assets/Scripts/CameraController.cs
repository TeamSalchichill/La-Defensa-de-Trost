using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

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

        if (scroll < 0)
        {
            size += 5;
        }
        else if (scroll > 0)
        {
            size -= 5;
        }

        size = Mathf.Clamp(size, zoomMin, zoomMax);
        Camera.main.orthographicSize = size;

        // Comprobar si se puede mover la cámara con el ratón
        if (!doMovement)
        {
            return;
        }

        // Mover la cámara con el ratón
        if (Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            transform.Translate(new Vector3(-1, 0, 1) * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(new Vector3(1, 0, -1) * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.x >= Screen.width - panBorderThickness)
        {
            transform.Translate(new Vector3(1, 0, 1) * panSpeed * Time.deltaTime, Space.World);
        }
        if (Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(new Vector3(-1, 0, -1) * panSpeed * Time.deltaTime, Space.World);
        }
    }
}
