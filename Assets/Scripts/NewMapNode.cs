using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapNode : MonoBehaviour
{
    Generator generator;
    GameFlow gameFlow;
    public GameObject spawn;
    public GameObject auxGrass;
    public GameObject navRemorer;

    public Color hoverColor;
    private Color startColor;
    private Renderer rend;

    public int startSide;
    public string startSideOrientation;

    public Vector3 offsetStart;
    public Vector2 mapPos;

    public int idX;
    public int idZ;

    void Start()
    {
        generator = Generator.instance;
        gameFlow = GameFlow.instance;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        if (!generator.openMap.Contains(mapPos))
        {
            generator.openMap.Add(mapPos);
        }
        else
        {
            Destroy(gameObject);
            Destroy(spawn);
            Destroy(auxGrass);
            generator.navRemovers.Remove(navRemorer);
            Destroy(navRemorer);
        }
    }

    private void OnMouseDown()
    {
        generator.Generate(startSide, startSideOrientation, offsetStart, mapPos, idX, idZ);

        Destroy(gameObject);
        Destroy(spawn);
        Destroy(auxGrass);
        generator.navRemovers.Remove(navRemorer);
        Destroy(navRemorer);
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
