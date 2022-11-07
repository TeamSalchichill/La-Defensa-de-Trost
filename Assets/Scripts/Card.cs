using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Card : MonoBehaviour
{
    ColocatorManager colocatorManager;
    GameFlow gameFlow;
    public Hero hero;

    public enum Rarity { Normal, Rare, Legendary }
    public Rarity rarity;

    public int numCards = 0;

    public int id;
    int iter = 0;

    public Image border;
    public Button button;
    public TextMeshProUGUI text;
    public Image blockImage;

    int towerSelectedId;
    int enemySelectedId;
    int statSelected;
    int incrementAmount;
    int randomUpgrade;

    void Start()
    {
        colocatorManager = ColocatorManager.instance;
        gameFlow = GameFlow.instance;
        hero = Hero.instance;

        border = GetComponent<Image>();
        button = GetComponentInChildren<Button>();
        text = GetComponentInChildren<TextMeshProUGUI>();

        id++;

        gameObject.SetActive(false);
    }

    public void NewTowerCard(int _numCards, int _rarity)
    {
        if (id <= _numCards)
        {
            blockImage.gameObject.SetActive(false);
            button.interactable = true;
        }
        else
        {
            blockImage.gameObject.SetActive(true);
            button.interactable = false;
        }

        numCards = _numCards;

        switch (_rarity)
        {
            case 0:
                rarity = Rarity.Normal;
                break;
            case 1:
                rarity = Rarity.Rare;
                break;
            case 2:
                rarity = Rarity.Legendary;
                break;
        }

        if (rarity == Rarity.Legendary)
        {
            towerSelectedId = 0;

            if (id % 2 == 0)
            {
                statSelected = Random.Range(0, 11);
            }
            else
            {
                statSelected = 11;
            }
        }
        else
        {
            towerSelectedId = Random.Range(1, colocatorManager.towers.Length);

            statSelected = Random.Range(0, 11);
        }
        
        switch (statSelected)
        {
            case 0:
                // Health
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(50, 151);
                        text.text = "La salud de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "La salud de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(500, 1501);
                        text.text = "La salud de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                }
                break;
            case 1:
                // Range
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(5, 11);
                        text.text = "El rango de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "El rango de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(10, 11);
                        text.text = "El rango de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                }
                break;
            case 2:
                // Shoot Speed
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(2, 6);
                        text.text = "La velocidad de ataque de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "La velocidad de ataque de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(2, 6);
                        text.text = "La velocidad de ataque de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                }
                break;
            case 3:
                // Turn Speed
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(50, 101);
                        text.text = "La velocidad de giro de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "La velocidad de giro de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(50, 101);
                        text.text = "La velocidad de giro de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                }
                break;
            case 4:
                // Health Damage
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(50, 101);
                        text.text = "El da�o de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "El da�o de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(50, 101);
                        text.text = "El da�o de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                }
                break;
            case 5:
                // Ice Effect
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(1, 5);
                        text.text = "El efecto de hielo de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "El efecto de hielo de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(1, 5);
                        text.text = "El efecto de hielo de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                }
                break;
            case 6:
                // Ignite Effect
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(1, 5);
                        text.text = "El efecto de fuego de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "El efecto de fuego de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(1, 5);
                        text.text = "El efecto de fuego de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                }
                break;
            case 7:
                // Water Effect
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(1, 5);
                        text.text = "El efecto de agua de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "El efecto de agua de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(1, 5);
                        text.text = "El efecto de agua de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                }
                break;
            case 8:
                // Ascension Effect
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(1, 5);
                        text.text = "El efecto de ascension de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "El efecto de ascension de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(1, 5);
                        text.text = "El efecto de ascension de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                }
                break;
            case 9:
                // Blood Effect
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(1, 5);
                        text.text = "El efecto de sangrado de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "El efecto de sangrado de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(1, 5);
                        text.text = "El efecto de sangrado de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                }
                break;
            case 10:
                // Crazy Effect
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(1, 5);
                        text.text = "El efecto de locura de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "El efecto de locura de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(1, 5);
                        text.text = "El efecto de locura de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                }
                break;
            case 11:
                randomUpgrade = id % 2;
                randomUpgrade--;

                if (Hero.instance)
                {
                    switch (Hero.instance.zone)
                    {
                        case Hero.Zone.Hielo:
                            switch (randomUpgrade)
                            {
                                case 0:
                                    text.text = "Cuando desaparece la barrera de hielo de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " explota y hace da�o";
                                    break;
                                case 1:
                                    text.text = colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " inflinge un 30% m�s de da�o a los enemigos que tengan algo congelaci�n";
                                    break;
                                case 2:
                                    text.text = "La barrera de hielo de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " inflinge congelaci�n en un area alrededor suya";
                                    break;
                            }
                            break;
                        case Hero.Zone.Desierto:
                            switch (randomUpgrade)
                            {
                                case 0:
                                    text.text = "WIP";
                                    break;
                                case 1:
                                    text.text = "WIP";
                                    break;
                                case 2:
                                    text.text = "WIP";
                                    break;
                            }
                            break;
                        case Hero.Zone.Atlantis:
                            switch (randomUpgrade)
                            {
                                case 0:
                                    text.text = "WIP";
                                    break;
                                case 1:
                                    text.text = "WIP";
                                    break;
                                case 2:
                                    text.text = "WIP";
                                    break;
                            }
                            break;
                        case Hero.Zone.Vikingos:
                            switch (randomUpgrade)
                            {
                                case 0:
                                    text.text = "WIP";
                                    break;
                                case 1:
                                    text.text = "WIP";
                                    break;
                                case 2:
                                    text.text = "WIP";
                                    break;
                            }
                            break;
                        case Hero.Zone.Fantasia:
                            switch (randomUpgrade)
                            {
                                case 0:
                                    text.text = "WIP";
                                    break;
                                case 1:
                                    text.text = "WIP";
                                    break;
                                case 2:
                                    text.text = "WIP";
                                    break;
                            }
                            break;
                        case Hero.Zone.Infierno:
                            switch (randomUpgrade)
                            {
                                case 0:
                                    text.text = "WIP";
                                    break;
                                case 1:
                                    text.text = "WIP";
                                    break;
                                case 2:
                                    text.text = "WIP";
                                    break;
                            }
                            break;
                    }
                }
                break;
        }
    }

    public void SelectTowerCard()
    {
        if (iter == 0)
        {
            GameObject[] allTowers = GameObject.FindGameObjectsWithTag("Tower");
            List<Tower> allTowersSelected = new List<Tower>();

            foreach (var tower in allTowers)
            {
                if (tower.GetComponent<Tower>().towerName == colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName)
                {
                    allTowersSelected.Add(tower.GetComponent<Tower>());
                }
            }

            switch (statSelected)
            {
                case 0:
                    // Health
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.health += incrementAmount;
                                towerSelected.healthMax += incrementAmount;
                            }
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 + (incrementAmount * 0.01f);
                            int newHealth = (int)(colocatorManager.towers[towerSelectedId].GetComponent<Tower>().health * porcetaje);

                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.health = newHealth;
                            }
                            break;
                        case Rarity.Legendary:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.health += incrementAmount;
                                towerSelected.healthMax += incrementAmount;
                            }
                            break;
                    }
                    break;
                case 1:
                    // Range
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.range += incrementAmount;
                            }
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 + (incrementAmount * 0.01f);
                            int newHealth = (int)(colocatorManager.towers[towerSelectedId].GetComponent<Tower>().range * porcetaje);

                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.range = newHealth;
                            }
                            break;
                        case Rarity.Legendary:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.range += incrementAmount;
                            }
                            break;
                    }
                    break;
                case 2:
                    // Shoot Speed
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.fireRate += incrementAmount;
                            }
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 + (incrementAmount * 0.01f);
                            int newHealth = (int)(colocatorManager.towers[towerSelectedId].GetComponent<Tower>().fireRate * porcetaje);

                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.fireRate = newHealth;
                            }
                            break;
                        case Rarity.Legendary:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.fireRate += incrementAmount;
                            }
                            break;
                    }
                    break;
                case 3:
                    // Turn Speed
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.turnSpeed += incrementAmount;
                            }
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 + (incrementAmount * 0.01f);
                            int newHealth = (int)(colocatorManager.towers[towerSelectedId].GetComponent<Tower>().turnSpeed * porcetaje);

                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.turnSpeed = newHealth;
                            }
                            break;
                        case Rarity.Legendary:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.turnSpeed += incrementAmount;
                            }
                            break;
                    }
                    break;
                case 4:
                    // Health Damage
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.healthDamage += incrementAmount;
                            }
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 + (incrementAmount * 0.01f);
                            int newHealth = (int)(colocatorManager.towers[towerSelectedId].GetComponent<Tower>().healthDamage * porcetaje);

                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.healthDamage = newHealth;
                            }
                            break;
                        case Rarity.Legendary:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.healthDamage += incrementAmount;
                            }
                            break;
                    }
                    break;
                case 5:
                    // Ice Effect
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.iceDamage += incrementAmount;
                            }
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 + (incrementAmount * 0.01f);
                            int newHealth = (int)(colocatorManager.towers[towerSelectedId].GetComponent<Tower>().iceDamage * porcetaje);

                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.iceDamage = newHealth;
                            }
                            break;
                        case Rarity.Legendary:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.iceDamage += incrementAmount;
                            }
                            break;
                    }
                    break;
                case 6:
                    // Ignite Effect
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.igniteDamage += incrementAmount;
                            }
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 + (incrementAmount * 0.01f);
                            int newHealth = (int)(colocatorManager.towers[towerSelectedId].GetComponent<Tower>().igniteDamage * porcetaje);

                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.igniteDamage = newHealth;
                            }
                            break;
                        case Rarity.Legendary:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.igniteDamage += incrementAmount;
                            }
                            break;
                    }
                    break;
                case 7:
                    // Water Effect
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.waterDamage += incrementAmount;
                            }
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 + (incrementAmount * 0.01f);
                            int newHealth = (int)(colocatorManager.towers[towerSelectedId].GetComponent<Tower>().waterDamage * porcetaje);

                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.waterDamage = newHealth;
                            }
                            break;
                        case Rarity.Legendary:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.waterDamage += incrementAmount;
                            }
                            break;
                    }
                    break;
                case 8:
                    // Ascension Effect
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.ascentDamage += incrementAmount;
                            }
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 + (incrementAmount * 0.01f);
                            int newHealth = (int)(colocatorManager.towers[towerSelectedId].GetComponent<Tower>().ascentDamage * porcetaje);

                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.ascentDamage = newHealth;
                            }
                            break;
                        case Rarity.Legendary:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.ascentDamage += incrementAmount;
                            }
                            break;
                    }
                    break;
                case 9:
                    // Blood Effect
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.bloodDamage += incrementAmount;
                            }
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 + (incrementAmount * 0.01f);
                            int newHealth = (int)(colocatorManager.towers[towerSelectedId].GetComponent<Tower>().bloodDamage * porcetaje);

                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.bloodDamage = newHealth;
                            }
                            break;
                        case Rarity.Legendary:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.bloodDamage += incrementAmount;
                            }
                            break;
                    }
                    break;
                case 10:
                    // Crazy Effect
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.transformationDamage += incrementAmount;
                            }
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 + (incrementAmount * 0.01f);
                            int newHealth = (int)(colocatorManager.towers[towerSelectedId].GetComponent<Tower>().transformationDamage * porcetaje);

                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.transformationDamage = newHealth;
                            }
                            break;
                        case Rarity.Legendary:
                            foreach (var towerSelected in allTowersSelected)
                            {
                                towerSelected.transformationDamage += incrementAmount;
                            }
                            break;
                    }
                    break;
                case 11:
                    if (Hero.instance)
                    {
                        switch (Hero.instance.zone)
                        {
                            case Hero.Zone.Hielo:
                                switch (randomUpgrade)
                                {
                                    case 0:
                                        hero.gameObject.GetComponent<Tower>().exploteIceWall = true;
                                        break;
                                    case 1:
                                        float porcetaje = 1 + (30 * 0.01f);
                                        int newHealth = (int)(hero.gameObject.GetComponent<Tower>().healthDamage * porcetaje);
                                        hero.gameObject.GetComponent<Tower>().healthDamage = newHealth;
                                        break;
                                    case 2:
                                        hero.gameObject.GetComponent<Tower>().frezzeIceWall = true;
                                        break;
                                }
                                break;
                            case Hero.Zone.Desierto:
                                switch (randomUpgrade)
                                {
                                    case 0:

                                        break;
                                    case 1:

                                        break;
                                    case 2:

                                        break;
                                }
                                break;
                            case Hero.Zone.Atlantis:
                                switch (randomUpgrade)
                                {
                                    case 0:

                                        break;
                                    case 1:

                                        break;
                                    case 2:

                                        break;
                                }
                                break;
                            case Hero.Zone.Vikingos:
                                switch (randomUpgrade)
                                {
                                    case 0:

                                        break;
                                    case 1:

                                        break;
                                    case 2:

                                        break;
                                }
                                break;
                            case Hero.Zone.Fantasia:
                                switch (randomUpgrade)
                                {
                                    case 0:

                                        break;
                                    case 1:

                                        break;
                                    case 2:

                                        break;
                                }
                                break;
                            case Hero.Zone.Infierno:
                                switch (randomUpgrade)
                                {
                                    case 0:

                                        break;
                                    case 1:

                                        break;
                                    case 2:

                                        break;
                                }
                                break;
                        }
                    }
                    break;
            }

            foreach (var cardScript in gameFlow.cardsScripts)
            {
                cardScript.InvokeEnemyCards();
                cardScript.iter++;
            }
        }
        else
        {
            gameFlow.cardSelected = true;
            gameFlow.dadosBackGround.gameObject.SetActive(false);
            
            foreach (var cardPos in gameFlow.cardsPos)
            {
                cardPos.gameObject.SetActive(false);
            }

            switch (statSelected)
            {
                case 0:
                    // Health
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().health += incrementAmount;
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 + (incrementAmount * 0.01f);
                            int newHealth = (int)(gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().health * porcetaje);
                            gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().health = newHealth;
                            break;
                        case Rarity.Legendary:
                            gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().health += incrementAmount;
                            break;
                    }
                    break;
                case 1:
                    // Damage
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().damage += incrementAmount;
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 + (incrementAmount * 0.01f);
                            int newHealth = (int)(gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().damage * porcetaje);
                            gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().damage = newHealth;
                            break;
                        case Rarity.Legendary:
                            gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().damage += incrementAmount;
                            break;
                    }
                    break;
                case 2:
                    // Speed
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().normalSpeed += incrementAmount;
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 + (incrementAmount * 0.01f);
                            int newHealth = (int)(gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().normalSpeed * porcetaje);
                            gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().normalSpeed = newHealth;
                            break;
                        case Rarity.Legendary:
                            gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().normalSpeed += incrementAmount;
                            break;
                    }
                    break;
                case 3:
                    // Range
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().range += incrementAmount;
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 + (incrementAmount * 0.01f);
                            int newHealth = (int)(gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().range * porcetaje);
                            gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().range = newHealth;
                            break;
                        case Rarity.Legendary:
                            gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().range += incrementAmount;
                            break;
                    }
                    break;
                case 4:
                    // Gold
                    switch (rarity)
                    {
                        case Rarity.Normal:
                            gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().gold -= incrementAmount;
                            break;
                        case Rarity.Rare:
                            float porcetaje = 1 - (incrementAmount * 0.01f);
                            int newHealth = (int)(gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().gold * porcetaje);
                            gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().gold = newHealth;
                            break;
                        case Rarity.Legendary:
                            gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().gold -= incrementAmount;
                            break;
                    }
                    break;
            }

            foreach (var cardScript in gameFlow.cardsScripts)
            {
                cardScript.InvokeEnemyCards();
                cardScript.iter = 0;
            }
        }
    }

    public void InvokeEnemyCards()
    {
        Invoke("NewEnemyCard", 0.2f);
    }

    public void NewEnemyCard()
    {
        if (rarity == Rarity.Legendary)
        {
            enemySelectedId = 0;
        }
        else
        {
            enemySelectedId = Random.Range(1, gameFlow.enemies.Length);
        }

        statSelected = Random.Range(0, 5);

        switch (statSelected)
        {
            case 0:
                // Health
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(50, 151);
                        text.text = "La salud de " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "La salud de " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(1000, 2001);
                        text.text = "La salud de " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " incrementa en " + incrementAmount + ".";
                        break;
                }
                break;
            case 1:
                // Damage
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(2, 7);
                        text.text = "El da�o de " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "El da�o de " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(5, 11);
                        text.text = "El da�o de " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " incrementa en " + incrementAmount + ".";
                        break;
                }
                break;
            case 2:
                // Speed
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(1, 4);
                        text.text = "La velocidad de " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "La velocidad de " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(2, 4);
                        text.text = "La velocidad de " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " incrementa en " + incrementAmount + ".";
                        break;
                }
                break;
            case 3:
                // Range
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(1, 3);
                        text.text = "El rango de " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "El rango de " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(3, 6);
                        text.text = "El rango de " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " incrementa en " + incrementAmount + ".";
                        break;
                }
                break;
            case 4:
                // Gold
                switch (rarity)
                {
                    case Rarity.Normal:
                        incrementAmount = Random.Range(10, 31);
                        text.text = "El oro que da " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " decrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "El oro que da " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " decrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(1000, 2001);
                        text.text = "El oro que da " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " decrementa en " + incrementAmount + ".";
                        break;
                }
                break;
        }
    }

    public void SelectEnemyCard()
    {

    }
}
