using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class pm2 : MonoBehaviour
{
    //Khai báo biến nhân vật
    public Rigidbody2D rb; //private Rigidbody2D rb;
    public Animator amt;
    //Khai báo biến tham số
    //Tốc độ di chuyển
    public float moveSpeed, jumpSpeed, jumpCount, jumpMax;
    public TextMeshProUGUI Score;

    private int tongDiem = 0;
    // Start is called before the first frame update

    void Start()
    {
        //Gán giá trị mặc định ban đầu cho tốc độ di chuyển, nhảy
        // moveSpeed = 5f;
        // jumpSpeed = 5f;
        // jumpCount = 0;
        // jumpMax = 2;
        //Khi chạy, tự tìm 1 Rigidbody2D để gắn vào,
        //Chỉ tìm các component bên trong nó
        rb = GetComponent<Rigidbody2D>();
        amt = GetComponent<Animator>();
        tinhDiem(0);
    }

    // Update is called once per frame
    void Update()
    {

        //Nếu phím 
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (jumpCount < jumpMax)
            {
                jumpCount++;
                playerJump(jumpSpeed);
            }
        }
    }
    void tinhDiem (int score) {
            tongDiem += score;
            Score.text = "" + tongDiem;
        }
        
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            amt.SetFloat("isRunning", 0);
            jumpCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag =="coin")
        {
            Destroy(other.gameObject);
            tinhDiem(1);
        }
    }
    private void FixedUpdate()
    {
        playerRun(moveSpeed);
    }

    void playerJump(float jumpSpeed)
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        amt.SetFloat("isRunning", 1);
    }

    void playerRun(float moveSpeed)
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }
    
}
