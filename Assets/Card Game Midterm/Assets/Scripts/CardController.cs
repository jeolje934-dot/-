using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public int cardID;             // 어떤 원소인지 알려주는 번호 (0~6)
    public GameObject frontObject; // 앞면 (원소 기호)
    public GameObject backObject;  // 뒷면 (검은색)

    private bool isOpened = false; // 현재 뒤집혀 있는지 체크

    // 게임 시작 시 카드를 뒷면으로 초기화
    void Start()
    {
        CloseCard();
    }

    // 카드를 클릭했을 때 실행되는 함수
    public void OnClickCard()
    {
        // 이미 열려있다면 무시합니다.
        if (isOpened) return;

        // 심판(GameManager)에게 "저 클릭됐어요!"라고 알려줍니다.
        // 이 한 줄이 있어야 짝 맞추기가 시작됩니다.
        FindObjectOfType<GameManager>().CardClicked(this);
    }

    public void OpenCard()
    {
        isOpened = true;
        frontObject.SetActive(true);
        backObject.SetActive(false);
    }

    public void CloseCard()
    {
        isOpened = false;
        frontObject.SetActive(false);
        backObject.SetActive(true);
    }

    // 짝이 맞았을 때 카드를 화면에서 사라지게 함
    public void Matched()
    {
        gameObject.SetActive(false);
    }
}