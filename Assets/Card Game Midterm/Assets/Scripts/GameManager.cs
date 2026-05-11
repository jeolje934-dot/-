using UnityEngine;
using System.Collections.Generic;
using System.Collections; // Wait 기능을 쓰기 위해 꼭 필요해요

public class GameManager : MonoBehaviour
{
    public GameObject[] cardPrefabs;
    public Transform board;

    // 뒤집은 카드들을 잠시 저장할 변수 (CardController로 이름 맞춤)
    private CardController firstCard;
    private CardController secondCard;

    void Start()
    {
        GenerateCards();
    }

    void GenerateCards()
    {
        List<GameObject> spawnList = new List<GameObject>();

        for (int i = 0; i < cardPrefabs.Length; i++)
        {
            spawnList.Add(cardPrefabs[i]);
            spawnList.Add(cardPrefabs[i]);
        }

        // 섞기 기능 (랜덤 배치)
        for (int i = 0; i < spawnList.Count; i++)
        {
            int randomIndex = Random.Range(i, spawnList.Count);
            GameObject temp = spawnList[i];
            spawnList[i] = spawnList[randomIndex];
            spawnList[randomIndex] = temp;
        }

        foreach (GameObject card in spawnList)
        {
            Instantiate(card, board);
        }
    }

    // ★ CardController에서 빨간 에러가 났던 바로 그 함수입니다 ★
    public void CardClicked(CardController card)
    {
        if (firstCard == null)
        {
            firstCard = card;
            firstCard.OpenCard();
        }
        else if (secondCard == null && card != firstCard)
        {
            secondCard = card;
            secondCard.OpenCard();

            // 두 카드가 같은지 검사 시작
            StartCoroutine(CheckMatch());
        }
    }

    IEnumerator CheckMatch()
    {
        // 0.7초 기다렸다가 판정 (너무 빨리 닫히면 안 되니까요)
        yield return new WaitForSeconds(0.7f);

        if (firstCard.cardID == secondCard.cardID)
        {
            // 짝이 맞으면 삭제
            firstCard.Matched();
            secondCard.Matched();
        }
        else
        {
            // 틀리면 다시 뒤집기
            firstCard.CloseCard();
            secondCard.CloseCard();
        }

        // 변수 비워주기
        firstCard = null;
        secondCard = null;
    }
}