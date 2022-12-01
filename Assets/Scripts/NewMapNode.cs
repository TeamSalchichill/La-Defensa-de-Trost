using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMapNode : MonoBehaviour
{
    Generator generator;
    GameFlow gameFlow;
    ColocatorManager colocatorManager;

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
        colocatorManager = ColocatorManager.instance;

        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        if (!generator.openMap.Contains(mapPos))
        {
            generator.openMap.Add(mapPos);
        }
        else
        {
            generator.repiteNewMapNode++;

            generator.newMapNodes.Remove(gameObject);

            Destroy(gameObject);
            Destroy(spawn);
            Destroy(auxGrass);
            generator.navRemovers.Remove(navRemorer);
            Destroy(navRemorer);
        }
    }

    private void OnMouseDown()
    {
        if (gameFlow.cardSelected && gameFlow.canExpand)
        {
            CameraController.instance.CameraCanMove();

            generator.newMapNodes.Remove(gameObject);

            gameFlow.lastNodePosition = transform.position;

            //MainTower.instance.restRounds--;
            if (Hero.instance != null)
            {
                Hero.instance.nextRound = true;
                Hero.instance.GetComponentInParent<Tower>().health = Hero.instance.GetComponentInParent<Tower>().health;
            }

            foreach (var tower in gameFlow.towers)
            {
                if (tower.GetComponent<RecolocateManual>())
                {
                    tower.GetComponent<RecolocateManual>().nextRound = true;
                }
            }

            generator.Generate(startSide, startSideOrientation, offsetStart, mapPos, idX, idZ);
            colocatorManager.canBuild = false;

            Destroy(gameObject);
            Destroy(spawn);
            Destroy(auxGrass);
            generator.navRemovers.Remove(navRemorer);
            Destroy(navRemorer);
        }
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
