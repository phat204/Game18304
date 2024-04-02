using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class chieuL : MonoBehaviour
{
    public TextMeshProUGUI countdownText; // Text để hiển thị thời gian hồi chiêu
    public float cooldownTime = 15f; // Thời gian hồi chiêu
    private playerMove pm2Script;
    private float currentCooldownTime; // Thời gian còn lại cho hồi chiêu

    private bool isCooldown = false; // Biến kiểm tra xem kỹ năng có đang trong thời gian hồi chiêu hay không

    // Start is called before the first frame update
    void Start()
    {
        currentCooldownTime = cooldownTime;
        UpdateCooldownText();
        pm2Script = GetComponent<playerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        // Nếu nhấn phím L và không trong thời gian hồi chiêu
        if (Input.GetKeyDown(KeyCode.L) && !isCooldown)
        {
            // Bắt đầu hồi chiêu
            StartCooldown();
        }

        // Nếu trong thời gian hồi chiêu
        if (isCooldown)
        {
            // Giảm thời gian còn lại và cập nhật Text
            currentCooldownTime -= Time.deltaTime;
            UpdateCooldownText();

            // Nếu thời gian còn lại là 0, kết thúc hồi chiêu
            if (currentCooldownTime <= 0f)
            {
                EndCooldown();
            }
        }
    }

    // Bắt đầu hồi chiêu
    void StartCooldown()
    {
        isCooldown = true;
        currentCooldownTime = cooldownTime;
        UpdateCooldownText();
        
        // Dịch chuyển đối tượng
        transform.position += new Vector3(10f, 1.5f, 0f);
    }

    // Kết thúc hồi chiêu
    void EndCooldown()
    {
        isCooldown = false;
        currentCooldownTime = cooldownTime;
        UpdateCooldownText();
    }

    // Cập nhật Text hiển thị thời gian hồi chiêu
    void UpdateCooldownText()
    {
        if (isCooldown)
        {
            countdownText.text = "L: " + Mathf.CeilToInt(currentCooldownTime).ToString("n0");
        }
        else
        {
            countdownText.text = ""; // Khi không trong thời gian hồi chiêu, không hiển thị gì cả
        }
    }
}
