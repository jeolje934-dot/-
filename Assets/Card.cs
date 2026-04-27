using UnityEngine;

public class Card : MonoBehaviour
{
    public int cardId;       // 카드 번호 (1, 5, 0, 7)
    public GameObject front; // 숫자 (Text TMP)
    public GameObject back;  // 검은색 가림막 (Image)

    // 이 함수가 실행되면 카드가 뒤집힙니다!
    public void OpenCard()
    {
        // 이미 숫자가 보이고 있다면 아무것도 안 함
        if (front.activeSelf == true) return;

        // 가림막을 끄고, 숫자를 켭니다.
        back.SetActive(false);
        front.SetActive(true);
    }

    // 나중에 틀렸을 때 다시 가리는 함수
    public void CloseCard()
    {
        back.SetActive(true);
        front.SetActive(false);
    }
}
