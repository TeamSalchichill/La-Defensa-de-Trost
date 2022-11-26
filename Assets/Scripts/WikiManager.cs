using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WikiManager : MonoBehaviour
{
    int worldSelected = 0;
    int idActualFirstCard = 0;

    bool[] flipedCards = new bool[3];

    public GameObject selector;
    public GameObject cards;

    public Image[] cardsPrefabs;
    public Image[] cardsPrefabsAux;

    public Sprite[] cards0;
    public Sprite[] cards0Aux;
    public Sprite[] cards1;
    public Sprite[] cards1Aux;
    public Sprite[] cards2;
    public Sprite[] cards2Aux;
    public Sprite[] cards3;
    public Sprite[] cards3Aux;
    public Sprite[] cards4;
    public Sprite[] cards4Aux;
    public Sprite[] cards5;
    public Sprite[] cards5Aux;
    public Sprite[] cards6;
    public Sprite[] cards6Aux;

    public Sprite emphyCards;
    
    public void SelectWorld(int idWorld)
    {
        worldSelected = idWorld;
        idActualFirstCard = 0;

        selector.SetActive(false);
        cards.SetActive(true);

        switch (worldSelected)
        {
            case 0:
                cardsPrefabs[0].sprite = cards0[0];
                if (cards0.Length > 0)
                {
                    cardsPrefabs[1].sprite = cards0[1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (cards0.Length > 1)
                {
                    cardsPrefabs[2].sprite = cards0[2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 1:
                cardsPrefabs[0].sprite = cards1[0];
                if (cards1.Length > 0)
                {
                    cardsPrefabs[1].sprite = cards1[1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (cards1.Length > 1)
                {
                    cardsPrefabs[2].sprite = cards1[2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 2:
                cardsPrefabs[0].sprite = cards2[0];
                if (cards2.Length > 0)
                {
                    cardsPrefabs[1].sprite = cards2[1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (cards2.Length > 1)
                {
                    cardsPrefabs[2].sprite = cards2[2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 3:
                cardsPrefabs[0].sprite = cards3[0];
                if (cards3.Length > 0)
                {
                    cardsPrefabs[1].sprite = cards3[1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (cards3.Length > 1)
                {
                    cardsPrefabs[2].sprite = cards3[2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 4:
                cardsPrefabs[0].sprite = cards4[0];
                if (cards4.Length > 0)
                {
                    cardsPrefabs[1].sprite = cards4[1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (cards4.Length > 1)
                {
                    cardsPrefabs[2].sprite = cards4[2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 5:
                cardsPrefabs[0].sprite = cards5[0];
                if (cards5.Length > 0)
                {
                    cardsPrefabs[1].sprite = cards5[1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (cards5.Length > 1)
                {
                    cardsPrefabs[2].sprite = cards5[2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 6:
                cardsPrefabs[0].sprite = cards6[0];
                if (cards6.Length > 0)
                {
                    cardsPrefabs[1].sprite = cards6[1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (cards6.Length > 1)
                {
                    cardsPrefabs[2].sprite = cards6[2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
        }
    }

    public void NextCards()
    {
        idActualFirstCard += 3;

        switch (worldSelected)
        {
            case 0:
                if (idActualFirstCard >= cards0.Length)
                {
                    idActualFirstCard = 0;
                }
                cardsPrefabs[0].sprite = cards0[idActualFirstCard + 0];
                if (idActualFirstCard + 1 < cards0.Length)
                {
                    cardsPrefabs[1].sprite = cards0[idActualFirstCard + 1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (idActualFirstCard + 2 < cards0.Length)
                {
                    cardsPrefabs[2].sprite = cards0[idActualFirstCard + 2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 1:
                if (idActualFirstCard >= cards1.Length)
                {
                    idActualFirstCard = 0;
                }
                cardsPrefabs[0].sprite = cards1[idActualFirstCard + 0];
                if (idActualFirstCard + 1 < cards1.Length)
                {
                    cardsPrefabs[1].sprite = cards1[idActualFirstCard + 1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (idActualFirstCard + 2 < cards1.Length)
                {
                    cardsPrefabs[2].sprite = cards1[idActualFirstCard + 2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 2:
                if (idActualFirstCard >= cards2.Length)
                {
                    idActualFirstCard = 0;
                }
                cardsPrefabs[0].sprite = cards2[idActualFirstCard + 0];
                if (idActualFirstCard + 1 < cards2.Length)
                {
                    cardsPrefabs[1].sprite = cards2[idActualFirstCard + 1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (idActualFirstCard + 2 < cards2.Length)
                {
                    cardsPrefabs[2].sprite = cards2[idActualFirstCard + 2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 3:
                if (idActualFirstCard >= cards3.Length)
                {
                    idActualFirstCard = 0;
                }
                cardsPrefabs[0].sprite = cards3[idActualFirstCard + 0];
                if (idActualFirstCard + 1 < cards3.Length)
                {
                    cardsPrefabs[1].sprite = cards3[idActualFirstCard + 1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (idActualFirstCard + 2 < cards3.Length)
                {
                    cardsPrefabs[2].sprite = cards3[idActualFirstCard + 2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 4:
                if (idActualFirstCard >= cards4.Length)
                {
                    idActualFirstCard = 0;
                }
                cardsPrefabs[0].sprite = cards4[idActualFirstCard + 0];
                if (idActualFirstCard + 1 < cards4.Length)
                {
                    cardsPrefabs[1].sprite = cards4[idActualFirstCard + 1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (idActualFirstCard + 2 < cards4.Length)
                {
                    cardsPrefabs[2].sprite = cards4[idActualFirstCard + 2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 5:
                if (idActualFirstCard >= cards5.Length)
                {
                    idActualFirstCard = 0;
                }
                cardsPrefabs[0].sprite = cards5[idActualFirstCard + 0];
                if (idActualFirstCard + 1 < cards5.Length)
                {
                    cardsPrefabs[1].sprite = cards5[idActualFirstCard + 1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (idActualFirstCard + 2 < cards5.Length)
                {
                    cardsPrefabs[2].sprite = cards5[idActualFirstCard + 2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 6:
                if (idActualFirstCard >= cards6.Length)
                {
                    idActualFirstCard = 0;
                }
                cardsPrefabs[0].sprite = cards6[idActualFirstCard + 0];
                if (idActualFirstCard + 1 < cards6.Length)
                {
                    cardsPrefabs[1].sprite = cards6[idActualFirstCard + 1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (idActualFirstCard + 2 < cards6.Length)
                {
                    cardsPrefabs[2].sprite = cards6[idActualFirstCard + 2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
        }
    }
    public void PreviusCards()
    {
        idActualFirstCard -= 3;
        
        switch (worldSelected)
        {
            case 0:
                if (idActualFirstCard < 0)
                {
                    int idAux = cards0.Length / 3;
                    idActualFirstCard = idAux;
                }
                cardsPrefabs[0].sprite = cards0[idActualFirstCard + 0];
                if (idActualFirstCard + 1 < cards0.Length)
                {
                    cardsPrefabs[1].sprite = cards0[idActualFirstCard + 1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (idActualFirstCard + 2 < cards0.Length)
                {
                    cardsPrefabs[2].sprite = cards0[idActualFirstCard + 2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 1:
                if (idActualFirstCard < 0)
                {
                    int idAux = cards1.Length / 3;
                    idActualFirstCard = idAux;
                }
                cardsPrefabs[0].sprite = cards1[idActualFirstCard + 0];
                if (idActualFirstCard + 1 < cards1.Length)
                {
                    cardsPrefabs[1].sprite = cards1[idActualFirstCard + 1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (idActualFirstCard + 2 < cards1.Length)
                {
                    cardsPrefabs[2].sprite = cards1[idActualFirstCard + 2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 2:
                if (idActualFirstCard < 0)
                {
                    int idAux = cards2.Length / 3;
                    idActualFirstCard = idAux;
                }
                cardsPrefabs[0].sprite = cards2[idActualFirstCard + 0];
                if (idActualFirstCard + 1 < cards2.Length)
                {
                    cardsPrefabs[1].sprite = cards2[idActualFirstCard + 1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (idActualFirstCard + 2 < cards2.Length)
                {
                    cardsPrefabs[2].sprite = cards2[idActualFirstCard + 2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 3:
                if (idActualFirstCard < 0)
                {
                    int idAux = cards3.Length / 3;
                    idActualFirstCard = idAux;
                }
                cardsPrefabs[0].sprite = cards3[idActualFirstCard + 0];
                if (idActualFirstCard + 1 < cards3.Length)
                {
                    cardsPrefabs[1].sprite = cards3[idActualFirstCard + 1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (idActualFirstCard + 2 < cards3.Length)
                {
                    cardsPrefabs[2].sprite = cards3[idActualFirstCard + 2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 4:
                if (idActualFirstCard < 0)
                {
                    int idAux = cards4.Length / 3;
                    idActualFirstCard = idAux;
                }
                cardsPrefabs[0].sprite = cards4[idActualFirstCard + 0];
                if (idActualFirstCard + 1 < cards4.Length)
                {
                    cardsPrefabs[1].sprite = cards4[idActualFirstCard + 1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (idActualFirstCard + 2 < cards4.Length)
                {
                    cardsPrefabs[2].sprite = cards4[idActualFirstCard + 2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 5:
                if (idActualFirstCard < 0)
                {
                    int idAux = cards5.Length / 3;
                    idActualFirstCard = idAux;
                }
                cardsPrefabs[0].sprite = cards5[idActualFirstCard + 0];
                if (idActualFirstCard + 1 < cards5.Length)
                {
                    cardsPrefabs[1].sprite = cards5[idActualFirstCard + 1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (idActualFirstCard + 2 < cards5.Length)
                {
                    cardsPrefabs[2].sprite = cards5[idActualFirstCard + 2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
            case 6:
                if (idActualFirstCard < 0)
                {
                    int idAux = cards6.Length / 3;
                    idActualFirstCard = idAux;
                }
                cardsPrefabs[0].sprite = cards6[idActualFirstCard + 0];
                if (idActualFirstCard + 1 < cards6.Length)
                {
                    cardsPrefabs[1].sprite = cards6[idActualFirstCard + 1];
                }
                else
                {
                    cardsPrefabs[1].sprite = emphyCards;
                }
                if (idActualFirstCard + 2 < cards6.Length)
                {
                    cardsPrefabs[2].sprite = cards6[idActualFirstCard + 2];
                }
                else
                {
                    cardsPrefabs[2].sprite = emphyCards;
                }
                break;
        }
    }

    public void FlipCard(int idCard)
    {
        switch (worldSelected)
        {
            case 0:
                if (!flipedCards[idCard])
                {
                    cardsPrefabs[idCard].sprite = cards0Aux[idActualFirstCard + idCard];
                }
                else
                {
                    cardsPrefabs[idCard].sprite = cards0[idActualFirstCard + idCard];
                }
                break;
            case 1:
                if (!flipedCards[idCard])
                {
                    cardsPrefabs[idCard].sprite = cards1Aux[idActualFirstCard + idCard];
                }
                else
                {
                    cardsPrefabs[idCard].sprite = cards1[idActualFirstCard + idCard];
                }
                break;
            case 2:
                if (!flipedCards[idCard])
                {
                    cardsPrefabs[idCard].sprite = cards2Aux[idActualFirstCard + idCard];
                }
                else
                {
                    cardsPrefabs[idCard].sprite = cards2[idActualFirstCard + idCard];
                }
                break;
            case 3:
                if (!flipedCards[idCard])
                {
                    cardsPrefabs[idCard].sprite = cards3Aux[idActualFirstCard + idCard];
                }
                else
                {
                    cardsPrefabs[idCard].sprite = cards3[idActualFirstCard + idCard];
                }
                break;
            case 4:
                if (!flipedCards[idCard])
                {
                    cardsPrefabs[idCard].sprite = cards4Aux[idActualFirstCard + idCard];
                }
                else
                {
                    cardsPrefabs[idCard].sprite = cards4[idActualFirstCard + idCard];
                }
                break;
            case 5:
                if (!flipedCards[idCard])
                {
                    cardsPrefabs[idCard].sprite = cards5Aux[idActualFirstCard + idCard];
                }
                else
                {
                    cardsPrefabs[idCard].sprite = cards5[idActualFirstCard + idCard];
                }
                break;
            case 6:
                if (!flipedCards[idCard])
                {
                    cardsPrefabs[idCard].sprite = cards6Aux[idActualFirstCard + idCard];
                }
                else
                {
                    cardsPrefabs[idCard].sprite = cards6[idActualFirstCard + idCard];
                }
                break;
        }

        flipedCards[idCard] = !flipedCards[idCard];
    }
}
