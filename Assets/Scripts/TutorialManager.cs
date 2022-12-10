using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;

    [Header("Images")]
    public int idStep;
    public Image dialogoImage;
    public Sprite[] dialogos;
    public GameObject finalScreen;

    [Header("Interactuable")]
    public GameObject nextStepButton;
    public GameObject[] towersIcon;
    public Vector3 cameraPos;
    public GameObject Turn1;
    public GameObject Turn2;
    public GameObject Zoom1;
    public GameObject Zoom2;
    public GameObject firstNewMapNode;
    public GameObject sellButton;
    public GameObject upgradeButton;
    
    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        foreach (var button in towersIcon)
        {
            button.SetActive(false);
        }

        nextStepButton.SetActive(true);
        GameFlow.instance.canExpand = false;
        CameraController.instance.doMovement = false;
    }

    void Update()
    {
        GameObject[] groundTiles = GameObject.FindGameObjectsWithTag("Ground");
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        HUD_Manager.instance.winScreen.SetActive(false);

        if (GameFlow.instance.round == 1)
        {
            foreach (var enemy in enemies)
            {
                if (enemy.transform.position.y > -10)
                {
                    enemy.GetComponent<Enemy>().normalSpeed = 0;
                }
            }
        }

        foreach (var tower in towers)
        {
            if (tower.transform.position.y > -10)
            {
                tower.GetComponent<Tower>().range = 30;
            }
        }

        switch (idStep)
        {
            case 0:
                CameraController.instance.doMovement = false;
                firstNewMapNode.SetActive(false);
                break;
            case 1:

                break;
            case 2:

                break;
            case 3:
                if (Vector3.Distance(CameraController.instance.gameObject.transform.position, cameraPos) > 3)
                {
                    NextStep();
                }
                break;
            case 4:
                if (Input.GetKey("q") || Input.GetKey("e"))
                {
                    NextStep();
                }
                break;
            case 5:
                if (Input.GetAxis("Mouse ScrollWheel") != 0)
                {
                    NextStep();
                }
                break;
            case 6:
                
                break;
            case 7:
                
                break;
            case 8:
                if (groundTiles.Length > 3)
                {
                    NextStep();
                    GameFlow.instance.canExpand = false;
                }
                break;
            case 9:
                
                break;
            case 10:
                
                break;
            case 11:
                if (towers.Length > 3 && (Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")))
                {
                    towersIcon[1].SetActive(false);
                }
                if (GameFlow.instance.round == 1 && GameFlow.instance.enemiesLeft1 == 0)
                {
                    NextStep();
                }
                break;
            case 12:
                if (GameFlow.instance.cardSelected)
                {
                    NextStep();
                }
                break;
            case 13:
                if (HUD_Manager.instance.isShowInfo)
                {
                    NextStep();
                }
                break;
            case 14:
                
                break;
            case 15:
                
                break;
            case 16:
                if (towers.Length > 3 && (Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")))
                {
                    NextStep();
                }
                break;
            case 17:
                
                break;
            case 18:

                break;
            case 19:
                if (towers.Length > 4 && (Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")))
                {
                    NextStep();
                }
                break;
            case 20:

                break;
            case 21:
                if (towers.Length > 5 && (Input.GetButtonDown("Fire1") || Input.GetButton("Fire1")))
                {
                    NextStep();
                }
                break;
            case 22:
                
                break;
            case 23:

                break;
            case 24:
                if (GameFlow.instance.round == 4 && GameFlow.instance.enemiesLeft1 == 0 && GameFlow.instance.enemiesLeft2 == 0)
                {
                    NextStep();
                }
                break;
            case 25:
                if (GameFlow.instance.round == 5)
                {
                    NextStep();
                }
                break;
            case 26:
                if (GameFlow.instance.round == 5 && GameFlow.instance.enemiesLeft1 == 0 && GameFlow.instance.enemiesLeft2 == 0 && GameFlow.instance.enemiesLeft3 == 0)
                {
                    NextStep();
                }
                break;
        }
    }

    public void NextStep()
    {
        if (idStep >= dialogos.Length)
        {
            Invoke("ExitLevel", 5);
            nextStepButton.SetActive(false);
            finalScreen.SetActive(true);
            return;
        }

        dialogoImage.sprite = dialogos[idStep];
        print(idStep);

        switch (idStep)
        {
            case 0:
                
                break;
            case 1:

                break;
            case 2:
                nextStepButton.SetActive(false);
                CameraController.instance.doMovement = true;
                cameraPos = CameraController.instance.gameObject.transform.position;
                break;
            case 3:
                Turn1.SetActive(true);
                Turn2.SetActive(true);
                break;
            case 4:
                Zoom1.SetActive(true);
                Zoom2.SetActive(true);
                break;
            case 5:
                nextStepButton.SetActive(true);
                break;
            case 6:

                break;
            case 7:
                firstNewMapNode.SetActive(true);
                nextStepButton.SetActive(false);
                GameFlow.instance.canExpand = true;
                break;
            case 8:
                nextStepButton.SetActive(true);
                break;
            case 9:
                nextStepButton.SetActive(false);
                towersIcon[1].SetActive(true);
                break;
            case 10:
                
                break;
            case 11:
                
                break;
            case 12:

                break;
            case 13:
                upgradeButton.SetActive(true);
                break;
            case 14:
                sellButton.SetActive(true);
                break;
            case 15:
                towersIcon[1].SetActive(true);
                sellButton.SetActive(false);
                break;
            case 16:
                towersIcon[1].SetActive(false);
                nextStepButton.SetActive(true);
                break;
            case 17:
                
                break;
            case 18:
                nextStepButton.SetActive(false);
                towersIcon[2].SetActive(true);
                break;
            case 19:
                nextStepButton.SetActive(true);
                towersIcon[2].SetActive(false);
                break;
            case 20:
                nextStepButton.SetActive(false);
                towersIcon[0].SetActive(true);
                break;
            case 21:
                nextStepButton.SetActive(false);
                towersIcon[0].SetActive(false);
                break;
            case 22:
                nextStepButton.SetActive(true);
                break;
            case 23:
                GameFlow.instance.canExpand = true;
                dialogoImage.enabled = false;
                nextStepButton.SetActive(false);
                break;
            case 24:
                dialogoImage.sprite = dialogos[idStep - 1];
                dialogoImage.enabled = true;
                break;
            case 25:
                dialogoImage.enabled = false;
                break;
            case 26:
                dialogoImage.sprite = dialogos[idStep - 1];
                dialogoImage.enabled = true;
                nextStepButton.SetActive(true);
                break;
        }

        idStep++;
    }

    public void ButtonDown(int id)
    {
        if (id == 1 && idStep == 10)
        {
            NextStep();
        }
        if (id == -4 && idStep == 4)
        {
            NextStep();
        }
        if (id == -5 && idStep == 5)
        {
            NextStep();
        }
        if (id == -14 && idStep == 14)
        {
            NextStep();
        }
        if (id == -15 && idStep == 15)
        {
            NextStep();
        }
        if (id == -22 && idStep == 22)
        {
            NextStep();
        }
    }

    void ExitLevel()
    {
        SceneManager.LoadScene(1);
    }
}
