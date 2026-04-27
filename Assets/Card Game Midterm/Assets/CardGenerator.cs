using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public GameObject cardPrefab; // 아까 만든 파란색 Card 틀을 여기 넣을 거야
    public int pairCount = 10;    // 10쌍(20개)을 만들겠다는 뜻!

    void Start()
    {
        for (int i = 0; i < pairCount * 2; i++)
        {
            // 한 줄에 5개씩, 총 4줄로 예쁘게 정렬하는 마법의 계산식이야
            float x = (i % 5) * 2.0f;
            float y = (i / 5) * -2.5f;

            // "카드 틀로, 이 위치에, 복사본을 만들어라!"
            Instantiate(cardPrefab, new Vector3(x, y, 0), Quaternion.identity);
        }
    }
}