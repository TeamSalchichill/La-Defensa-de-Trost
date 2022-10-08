using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolocate : MonoBehaviour
{
    public enum Type { None, Spawn }
    public Type type;

    public Vector3 offsetPos;
    public Quaternion offsetRot;

    void Start()
    {
        switch (type)
        {
            case Type.None:
                transform.position += offsetPos;
                transform.rotation = offsetRot;
                break;
            case Type.Spawn:

                break;
        }
    }
}
