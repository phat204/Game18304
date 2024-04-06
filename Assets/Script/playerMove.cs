using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System;
public class playerMove : MonoBehaviour
{
    //Khai báo biến nhân vật
    public Rigidbody2D rb; //private Rigidbody2D rb;
    public Animator amt;
    //Khai báo biến tham số
    //Tốc độ di chuyển
    public float moveSpeed, jumpSpeed, jumpCount, jumpMax;
    public TextMeshProUGUI Score, ScoreDeath, HightScore, TopHightScore;
    public GameObject thongBaoPanel;
    public int tongDiem, HS, numHS;
    public List<int> arrHS;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        amt = GetComponent<Animator>();
        tinhDiem(0);
        // tongDiem = PlayerPrefs.GetInt("Score");

        HS = PlayerPrefs.GetInt("HighScore");
        HightScore.text = "Hight score: " + HS.ToString("n0");
        TopHightScore.text = "Hight score: \n" + HS.ToString("n0");
        numHS = 3;
        arrHS[0] = PlayerPrefs.GetInt("HighScore0");
        arrHS[1] = PlayerPrefs.GetInt("HighScore1");
        arrHS[2] = PlayerPrefs.GetInt("HighScore2");
        // arrHS[3] = PlayerPrefs.GetInt("HighScore3");
        // arrHS[4] = PlayerPrefs.GetInt("HighScore4");

        HS = arrHS[numHS - 1];
        TopHightScore.text = "Hight score: \n" + arrHS[0].ToString("n0")
                                                + arrHS[1].ToString("n0")
                                                + arrHS[2].ToString("n0")
        //                                         + arrHS[3].ToString("n0")
        //                                         + arrHS[4].ToString("n0")
        ;
    }
    
    // Update is called once per frame
    void Update()
    {

        //Nếu phím 
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (jumpCount < jumpMax)
            {
                jumpCount++;
                playerJump(jumpSpeed);
            }
        }

        if (rb == null)
        {
            if (tongDiem > HS) 
            {
                HS = tongDiem;
                int viTriLuu = 0;
                for (int i = 0; i < numHS; i++)
                {
                    if (HS > arrHS[i])
                    {
                        viTriLuu = i;
                        break;
                    }
                }

                for (int i = numHS - 1; i > viTriLuu; i--)
                {
                    arrHS[i] = arrHS[i-1];
                }

                arrHS[viTriLuu] = HS;

                PlayerPrefs.SetInt("HighScore", HS);
                PlayerPrefs.SetInt("HighScore0", arrHS[0]);
                PlayerPrefs.SetInt("HighScore1", arrHS[1]);
                PlayerPrefs.SetInt("HighScore2", arrHS[2]);
                // PlayerPrefs.SetInt("HighScore3", arrHS[3]);
                // PlayerPrefs.SetInt("HighScore0", arrHS[0]);
                TopHightScore.text = "Hight score: \n" + arrHS[0].ToString("n0")
                                                + arrHS[1].ToString("n0")
                                                + arrHS[2].ToString("n0");
                // PlayerPrefs.Save();
                thongBaoPanel.SetActive(true);
            }
        }
    }
    void tinhDiem (int score) {
            tongDiem += score;
            Score.text = ": " + tongDiem.ToString("n0");
            ScoreDeath.text = "Điểm của bạn là: " + tongDiem.ToString("n0");
        }
        
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "ground")
        {
            amt.SetFloat("isRunning", 0);
            jumpCount = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "coin")
        {
            PlayerPrefs.SetInt("Score", tongDiem);
            
            Destroy(other.gameObject);
            tinhDiem(1); // Tăng điểm khi nhặt được coin
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
