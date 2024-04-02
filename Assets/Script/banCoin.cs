using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class banCoin : MonoBehaviour
{
    public GameObject danCoin;
    public Transform coinPos;
    public float fireRate = 0.1f;
    private bool isFiring = false;
    public Rigidbody2D rb;
    public TextMeshProUGUI danConLai;
    public int dan;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) || Input.GetMouseButtonDown(1))
        {
            isFiring = true;
            InvokeRepeating("Fire", 0f, fireRate);
        }
        if (Input.GetKeyUp(KeyCode.I) || Input.GetMouseButtonUp(1))
        {
            isFiring = false;
            CancelInvoke("Fire");
        }
        // Cập nhật số coin còn lại trên giao diện
        UpdateCoinCountUI();
    }

    void Fire()
    {
        if (isFiring)
        {
            if (dan > 0) // Kiểm tra nếu còn coin
            {
                Instantiate(danCoin, coinPos.position, Quaternion.identity);
                dan --;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "coin")
        {
            dan ++;
        }
    }
    // Cập nhật số coin còn lại trên giao diện
    void UpdateCoinCountUI()
    {
        danConLai.text = "Đạn: " + dan.ToString("n0");
    }
}
