using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public struct BlockCards
{
    public string Tower;
    public int Atributte;
}

public class Card : MonoBehaviour
{
    ColocatorManager colocatorManager;
    GameFlow gameFlow;
    public Hero hero;

    public enum Rarity { Normal, Rare, Legendary }
    public Rarity rarity;

    List<BlockCards> blockedCards = new List<BlockCards>();

    public int numCards = 0;

    public int id;
    int iter = 0;

    public Image border;
    public Button button;
    public TextMeshProUGUI text;
    public Image blockImage;
    public Sprite[] tiersBorders;

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

        AddBlockCards();
    }

    public void NewTowerCard(int _numCards, int _rarity)
    {
        border.sprite = tiersBorders[_rarity];

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

            /*
            if (id % 2 == 0)
            {
                statSelected = Random.Range(0, 11);
            }
            else
            {
                statSelected = 11;
            }
            */
        }
        else
        {
            towerSelectedId = Random.Range(1, colocatorManager.towers.Length);
        }

        bool goodChoose = false;

        while (!goodChoose)
        {
            statSelected = Random.Range(0, 11);

            BlockCards block = new BlockCards();
            block.Tower = colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName;
            block.Atributte = statSelected;

            if (!blockedCards.Contains(block))
            {
                print("1");
                goodChoose = true;
            }
            else
            {
                print("2");
            }
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
                        text.text = "El daño de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "El daño de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(50, 101);
                        text.text = "El daño de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " incrementa en " + incrementAmount + ".";
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
                                    text.text = "Cuando desaparece la barrera de hielo de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " explota y hace daño";
                                    break;
                                case 1:
                                    text.text = colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " inflinge un 30% más de daño a los enemigos que tengan algo congelación";
                                    break;
                                case 2:
                                    text.text = "La barrera de hielo de " + colocatorManager.towers[towerSelectedId].GetComponent<Tower>().towerName + " inflinge congelación en un area alrededor suya";
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
                            int newHealth = (int)Mathf.Ceil((colocatorManager.towers[towerSelectedId].GetComponent<Tower>().iceDamage * porcetaje));
                            
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
                            int newHealth = (int)Mathf.Ceil((colocatorManager.towers[towerSelectedId].GetComponent<Tower>().igniteDamage * porcetaje));

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
                            int newHealth = (int)Mathf.Ceil((colocatorManager.towers[towerSelectedId].GetComponent<Tower>().waterDamage * porcetaje));

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
                            int newHealth = (int)Mathf.Ceil((colocatorManager.towers[towerSelectedId].GetComponent<Tower>().ascentDamage * porcetaje));

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
                            int newHealth = (int)Mathf.Ceil((colocatorManager.towers[towerSelectedId].GetComponent<Tower>().bloodDamage * porcetaje));

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
                            int newHealth = (int)Mathf.Ceil((colocatorManager.towers[towerSelectedId].GetComponent<Tower>().transformationDamage * porcetaje));

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
                        text.text = "El daño de " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " incrementa en " + incrementAmount + ".";
                        break;
                    case Rarity.Rare:
                        incrementAmount = Random.Range(5, 51);
                        text.text = "El daño de " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " incrementa en " + incrementAmount + "%.";
                        break;
                    case Rarity.Legendary:
                        incrementAmount = Random.Range(5, 11);
                        text.text = "El daño de " + gameFlow.enemies[enemySelectedId].GetComponent<Enemy>().enemyName + " incrementa en " + incrementAmount + ".";
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

    void AddBlockCards()
    {
        //Mundo 0 - Barricada
        BlockCards block8 = new BlockCards();
        block8.Tower = "Barricada";
        block8.Atributte = 3;
        blockedCards.Add(block8);

        BlockCards block17 = new BlockCards();
        block17.Tower = "Barricada";
        block17.Atributte = 1;
        blockedCards.Add(block17);

        BlockCards block7 = new BlockCards();
        block7.Tower = "Barricada";
        block7.Atributte = 4;
        blockedCards.Add(block7);

        BlockCards block1 = new BlockCards();
        block1.Tower = "Barricada";
        block1.Atributte = 5;
        blockedCards.Add(block1);

        BlockCards block2 = new BlockCards();
        block2.Tower = "Barricada";
        block2.Atributte = 6;
        blockedCards.Add(block2);

        BlockCards block3 = new BlockCards();
        block3.Tower = "Barricada";
        block3.Atributte = 7;
        blockedCards.Add(block3);

        BlockCards block4 = new BlockCards();
        block4.Tower = "Barricada";
        block4.Atributte = 8;
        blockedCards.Add(block4);

        BlockCards block5 = new BlockCards();
        block5.Tower = "Barricada";
        block5.Atributte = 9;
        blockedCards.Add(block5);

        BlockCards block6 = new BlockCards();
        block6.Tower = "Barricada";
        block6.Atributte = 10;
        blockedCards.Add(block6);

        BlockCards blockblock104 = new BlockCards();
        blockblock104.Tower = "Barricada";
        blockblock104.Atributte = 2;
        blockedCards.Add(blockblock104);

        //Mundo 0 - Mina de oro
        BlockCards block18 = new BlockCards();
        block18.Tower = "Mina de oro";
        block18.Atributte = 1;
        blockedCards.Add(block18);

        BlockCards block9 = new BlockCards();
        block9.Tower = "Mina de oro";
        block9.Atributte = 3;
        blockedCards.Add(block9);

        BlockCards block11 = new BlockCards();
        block11.Tower = "Mina de oro";
        block11.Atributte = 5;
        blockedCards.Add(block11);

        BlockCards block12 = new BlockCards();
        block12.Tower = "Mina de oro";
        block12.Atributte = 6;
        blockedCards.Add(block12);

        BlockCards block13 = new BlockCards();
        block13.Tower = "Mina de oro";
        block13.Atributte = 7;
        blockedCards.Add(block13);

        BlockCards block14 = new BlockCards();
        block14.Tower = "Mina de oro";
        block14.Atributte = 8;
        blockedCards.Add(block14);

        BlockCards block15 = new BlockCards();
        block15.Tower = "Mina de oro";
        block15.Atributte = 9;
        blockedCards.Add(block15);

        BlockCards block16 = new BlockCards();
        block16.Tower = "Mina de oro";
        block16.Atributte = 10;
        blockedCards.Add(block16);

        //Mundo 0 - Cañón
        BlockCards block20 = new BlockCards();
        block20.Tower = "Cañón";
        block20.Atributte = 3;
        blockedCards.Add(block20);

        BlockCards block21 = new BlockCards();
        block21.Tower = "Cañón";
        block21.Atributte = 8;
        blockedCards.Add(block21);

        //Mundo 0 - Arqueras
        BlockCards block22 = new BlockCards();
        block22.Tower = "Arqueras";
        block22.Atributte = 3;
        blockedCards.Add(block22);

        BlockCards block23 = new BlockCards();
        block23.Tower = "Arqueras";
        block23.Atributte = 8;
        blockedCards.Add(block23);

        //Mundo 1 - Snow Keeper
        BlockCards block24 = new BlockCards();
        block24.Tower = "Snow Keeper";
        block24.Atributte = 3;
        blockedCards.Add(block24);

        BlockCards block25 = new BlockCards();
        block25.Tower = "Snow Keeper";
        block25.Atributte = 8;
        blockedCards.Add(block25);

        //Mundo 1 - Snow Keeper
        BlockCards block26 = new BlockCards();
        block26.Tower = "Snow Man";
        block26.Atributte = 3;
        blockedCards.Add(block26);

        BlockCards block27 = new BlockCards();
        block27.Tower = "Snow Man";
        block27.Atributte = 8;
        blockedCards.Add(block27);

        //Mundo 1 - Rey Fannar
        BlockCards block28 = new BlockCards();
        block28.Tower = "Rey Fannar";
        block28.Atributte = 3;
        blockedCards.Add(block28);

        BlockCards block29 = new BlockCards();
        block29.Tower = "Rey Fannar";
        block29.Atributte = 8;
        blockedCards.Add(block29);

        //Mundo 1 - Spray de nieve
        BlockCards block30 = new BlockCards();
        block30.Tower = "Spray de nieve";
        block30.Atributte = 3;
        blockedCards.Add(block30);

        BlockCards block31 = new BlockCards();
        block31.Tower = "Spray de nieve";
        block31.Atributte = 8;
        blockedCards.Add(block31);

        BlockCards block32 = new BlockCards();
        block32.Tower = "Spray de nieve";
        block32.Atributte = 2;
        blockedCards.Add(block32);

        BlockCards block33 = new BlockCards();
        block33.Tower = "Spray de nieve";
        block33.Atributte = 6;
        blockedCards.Add(block33);

        BlockCards block34 = new BlockCards();
        block34.Tower = "Spray de nieve";
        block34.Atributte = 7;
        blockedCards.Add(block34);

        BlockCards block35 = new BlockCards();
        block35.Tower = "Spray de nieve";
        block35.Atributte = 9;
        blockedCards.Add(block35);

        BlockCards block36 = new BlockCards();
        block36.Tower = "Spray de nieve";
        block36.Atributte = 10;
        blockedCards.Add(block36);

        //Mundo 2 - Syrius Purple
        BlockCards block37 = new BlockCards();
        block37.Tower = "Syrius Purple";
        block37.Atributte = 3;
        blockedCards.Add(block37);

        BlockCards block38 = new BlockCards();
        block38.Tower = "Syrius Purple";
        block38.Atributte = 8;
        blockedCards.Add(block38);

        //Mundo 2 - PeRigie
        BlockCards block39 = new BlockCards();
        block37.Tower = "PeRigie";
        block37.Atributte = 3;
        blockedCards.Add(block39);

        BlockCards block40 = new BlockCards();
        block40.Tower = "PeRigie";
        block40.Atributte = 8;
        blockedCards.Add(block40);

        //Mundo 2 - Test-Lah
        BlockCards block41 = new BlockCards();
        block41.Tower = "Test-Lah";
        block41.Atributte = 3;
        blockedCards.Add(block41);

        BlockCards block42 = new BlockCards();
        block42.Tower = "Test-Lah";
        block42.Atributte = 8;
        blockedCards.Add(block42);

        BlockCards block43 = new BlockCards();
        block43.Tower = "Test-Lah";
        block43.Atributte = 2;
        blockedCards.Add(block43);

        //Mundo 2 - Rey Axiryus
        BlockCards block44 = new BlockCards();
        block44.Tower = "Rey Axiryus";
        block44.Atributte = 3;
        blockedCards.Add(block44);

        BlockCards block45 = new BlockCards();
        block45.Tower = "Rey Axiryus";
        block45.Atributte = 8;
        blockedCards.Add(block45);

        //Mundo 3 - Tuex
        BlockCards block46 = new BlockCards();
        block46.Tower = "Tuex";
        block46.Atributte = 3;
        blockedCards.Add(block46);

        BlockCards block47 = new BlockCards();
        block47.Tower = "Tuex";
        block47.Atributte = 8;
        blockedCards.Add(block47);

        //Mundo 3 - Reina Maribel
        BlockCards block48 = new BlockCards();
        block48.Tower = "Reina Maribel";
        block48.Atributte = 3;
        blockedCards.Add(block48);

        BlockCards block49 = new BlockCards();
        block49.Tower = "Reina Maribel";
        block49.Atributte = 8;
        blockedCards.Add(block49);

        //Mundo 3 - Pium
        BlockCards block50 = new BlockCards();
        block50.Tower = "Pium";
        block50.Atributte = 3;
        blockedCards.Add(block50);

        BlockCards block51 = new BlockCards();
        block51.Tower = "Pium";
        block51.Atributte = 8;
        blockedCards.Add(block51);

        //Mundo 3 - Suw Balony
        BlockCards block52 = new BlockCards();
        block52.Tower = "Suw Balony";
        block52.Atributte = 3;
        blockedCards.Add(block52);

        BlockCards block53 = new BlockCards();
        block53.Tower = "Suw Balony";
        block53.Atributte = 8;
        blockedCards.Add(block53);

        //Mundo 4 - Beowulf
        BlockCards block54 = new BlockCards();
        block54.Tower = "Beowulf";
        block54.Atributte = 1;
        blockedCards.Add(block54);

        BlockCards block55 = new BlockCards();
        block55.Tower = "Beowulf";
        block55.Atributte = 3;
        blockedCards.Add(block55);

        BlockCards block56 = new BlockCards();
        block56.Tower = "Beowulf";
        block56.Atributte = 4;
        blockedCards.Add(block56);

        BlockCards block57 = new BlockCards();
        block57.Tower = "Beowulf";
        block57.Atributte = 5;
        blockedCards.Add(block57);

        BlockCards block58 = new BlockCards();
        block58.Tower = "Beowulf";
        block58.Atributte = 6;
        blockedCards.Add(block58);

        BlockCards block59 = new BlockCards();
        block59.Tower = "Beowulf";
        block59.Atributte = 7;
        blockedCards.Add(block59);

        BlockCards block60 = new BlockCards();
        block60.Tower = "Beowulf";
        block60.Atributte = 8;
        blockedCards.Add(block60);

        BlockCards block61 = new BlockCards();
        block61.Tower = "Beowulf";
        block61.Atributte = 9;
        blockedCards.Add(block61);

        BlockCards block62 = new BlockCards();
        block62.Tower = "Beowulf";
        block62.Atributte = 10;
        blockedCards.Add(block62);

        //Mundo 4 - Altar de Odín
        BlockCards block63 = new BlockCards();
        block63.Tower = "Altar de Odín";
        block63.Atributte = 3;
        blockedCards.Add(block63);

        BlockCards block64 = new BlockCards();
        block64.Tower = "Altar de Odín";
        block64.Atributte = 8;
        blockedCards.Add(block64);

        //Mundo 4 - Kyria
        BlockCards block65 = new BlockCards();
        block65.Tower = "Kyria";
        block65.Atributte = 3;
        blockedCards.Add(block65);

        BlockCards block66 = new BlockCards();
        block66.Tower = "Kyria";
        block66.Atributte = 8;
        blockedCards.Add(block66);

        //Mundo 4 - Thor
        BlockCards block67 = new BlockCards();
        block67.Tower = "Thor";
        block67.Atributte = 3;
        blockedCards.Add(block67);

        BlockCards block68 = new BlockCards();
        block68.Tower = "Thor";
        block68.Atributte = 8;
        blockedCards.Add(block68);

        //Mundo 5 - Viva Porub
        BlockCards block69 = new BlockCards();
        block69.Tower = "Viva Porub";
        block69.Atributte = 3;
        blockedCards.Add(block69);

        BlockCards block70 = new BlockCards();
        block70.Tower = "Viva Porub";
        block70.Atributte = 8;
        blockedCards.Add(block70);

        BlockCards block71 = new BlockCards();
        block71.Tower = "Viva Porub";
        block71.Atributte = 5;
        blockedCards.Add(block71);

        BlockCards block72 = new BlockCards();
        block72.Tower = "Viva Porub";
        block72.Atributte = 6;
        blockedCards.Add(block72);

        BlockCards block73 = new BlockCards();
        block73.Tower = "Viva Porub";
        block73.Atributte = 7;
        blockedCards.Add(block72);

        BlockCards block74 = new BlockCards();
        block74.Tower = "Viva Porub";
        block74.Atributte = 9;
        blockedCards.Add(block74);

        BlockCards block75 = new BlockCards();
        block75.Tower = "Viva Porub";
        block75.Atributte = 10;
        blockedCards.Add(block75);

        //Mundo 5 - Antium
        BlockCards block76 = new BlockCards();
        block76.Tower = "Antium";
        block76.Atributte = 3;
        blockedCards.Add(block76);

        BlockCards block77 = new BlockCards();
        block77.Tower = "Antium";
        block77.Atributte = 8;
        blockedCards.Add(block77);

        //Mundo 5 - Reina Tatiana
        BlockCards block78 = new BlockCards();
        block78.Tower = "Reina Tatiana";
        block78.Atributte = 3;
        blockedCards.Add(block78);

        BlockCards block79 = new BlockCards();
        block79.Tower = "Reina Tatiana";
        block79.Atributte = 8;
        blockedCards.Add(block79);

        //Mundo 5 - ThornGun
        BlockCards block80 = new BlockCards();
        block80.Tower = "ThornGun";
        block80.Atributte = 3;
        blockedCards.Add(block80);

        BlockCards block81 = new BlockCards();
        block81.Tower = "ThornGun";
        block81.Atributte = 8;
        blockedCards.Add(block81);

        //Mundo 6 - Charmando
        BlockCards block82 = new BlockCards();
        block82.Tower = "Charmando";
        block82.Atributte = 3;
        blockedCards.Add(block82);

        BlockCards block83 = new BlockCards();
        block83.Tower = "Charmando";
        block83.Atributte = 8;
        blockedCards.Add(block83);

        //Mundo 6 - Rey Bubuyog
        BlockCards block84 = new BlockCards();
        block84.Tower = "Rey Bubuyog";
        block84.Atributte = 3;
        blockedCards.Add(block84);

        BlockCards block85 = new BlockCards();
        block85.Tower = "Rey Bubuyog";
        block85.Atributte = 8;
        blockedCards.Add(block85);

        //Mundo 6 - Eklypsion
        BlockCards block86 = new BlockCards();
        block86.Tower = "Eklypsion";
        block86.Atributte = 2;
        blockedCards.Add(block86);

        BlockCards block87 = new BlockCards();
        block87.Tower = "Eklypsion";
        block87.Atributte = 3;
        blockedCards.Add(block87);

        BlockCards block88 = new BlockCards();
        block88.Tower = "Eklypsion";
        block88.Atributte = 4;
        blockedCards.Add(block88);

        BlockCards block89 = new BlockCards();
        block89.Tower = "Eklypsion";
        block89.Atributte = 5;
        blockedCards.Add(block89);

        BlockCards block90 = new BlockCards();
        block90.Tower = "Eklypsion";
        block90.Atributte = 6;
        blockedCards.Add(block90);

        BlockCards block91 = new BlockCards();
        block91.Tower = "Eklypsion";
        block91.Atributte = 7;
        blockedCards.Add(block91);

        BlockCards block92 = new BlockCards();
        block92.Tower = "Eklypsion";
        block92.Atributte = 8;
        blockedCards.Add(block92);

        BlockCards block93 = new BlockCards();
        block93.Tower = "Eklypsion";
        block93.Atributte = 9;
        blockedCards.Add(block93);

        BlockCards block94 = new BlockCards();
        block94.Tower = "Eklypsion";
        block94.Atributte = 10;
        blockedCards.Add(block94);

        //Mundo 6 - Hihell
        BlockCards block95 = new BlockCards();
        block95.Tower = "Hihell";
        block95.Atributte = 1;
        blockedCards.Add(block95);

        BlockCards block96 = new BlockCards();
        block96.Tower = "Hihell";
        block96.Atributte = 3;
        blockedCards.Add(block96);

        BlockCards block97 = new BlockCards();
        block97.Tower = "Hihell";
        block97.Atributte = 4;
        blockedCards.Add(block97);

        BlockCards block98 = new BlockCards();
        block98.Tower = "Hihell";
        block98.Atributte = 5;
        blockedCards.Add(block98);

        BlockCards block99 = new BlockCards();
        block99.Tower = "Hihell";
        block99.Atributte = 6;
        blockedCards.Add(block99);

        BlockCards block100 = new BlockCards();
        block100.Tower = "Hihell";
        block100.Atributte = 7;
        blockedCards.Add(block100);

        BlockCards block101 = new BlockCards();
        block101.Tower = "Hihell";
        block101.Atributte = 8;
        blockedCards.Add(block92);

        BlockCards block102 = new BlockCards();
        block102.Tower = "Hihell";
        block102.Atributte = 9;
        blockedCards.Add(block102);

        BlockCards blockblock103 = new BlockCards();
        blockblock103.Tower = "Hihell";
        blockblock103.Atributte = 10;
        blockedCards.Add(blockblock103);
    }
}
