using UnityEngine;
using UnityEngine.UI;

public class ShowTopPanel : MonoBehaviour
{
    public GameObject topPanel; // Tham chiếu đến panel chứa top 5 điểm
    public GameObject startGamePanel;
    public TopScoreManager top; // Tham chiếu đến script quản lý top điểm

    // Đăng ký sự kiện click cho button trong Start
    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnTopButtonClick);
        }
    }

    // Xử lý sự kiện click
    void OnTopButtonClick()
    {
        // Hiển thị hoặc ẩn panel chứa top 5 điểm
        if (topPanel != null)
        {
            topPanel.SetActive(!topPanel.activeSelf); // Đảo trạng thái hiển thị của panel
            startGamePanel.SetActive(!startGamePanel.activeSelf);
        }
    }
}
