using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public GameObject backGroundPanel;
    public GameObject escapePanel;
    public GameObject deathPanel;
    public GameObject topPanel;
    private GameObject player; // Khai báo biến player

    void Start()
    {
        Time.timeScale = 1;
        // Gán giá trị cho biến player
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (player == null)
        {
            // Hiển thị panel death và tạm dừng trò chơi
            Time.timeScale = 0;
            ShowDeathPanel();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = (Time.timeScale == 0) ? 1 : 0;
            ToggleEscapePanel();
        }

    }

    public void LoadSceneStart()
    {
        SceneManager.LoadScene("Start");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene("Scene_1");
    }

    public void reloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToggleEscapePanel()
    {
        // Đảo ngược trạng thái của escapePanel (ẩn nếu đang hiển thị, hiển thị nếu đang ẩn)
        escapePanel.SetActive(!escapePanel.activeSelf);
        backGroundPanel.SetActive(!backGroundPanel.activeSelf);
    }

    public void ContinueGame()
    {
        // Ẩn escapePanel khi nhấn nút "Tiếp tục"
        Time.timeScale = 1;
        escapePanel.SetActive(false);
        backGroundPanel.SetActive(!backGroundPanel.activeSelf);
    }

    public void QuitGame()
    {
        // Thoát game khi nhấn nút "Thoát game"
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }

    void ShowDeathPanel()
    {
        deathPanel.SetActive(true);
        backGroundPanel.SetActive(false);
        escapePanel.SetActive(false);
    }
}
