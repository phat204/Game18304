using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class heoMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator atm;
    public int moveSpeed;
    bool isMovingRight = true; // Biến này để xác định hướng di chuyển của boar
    public Slider sliderMau;
    public float maxMau;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        atm = GetComponent<Animator>();
        moveSpeed = 3;
        atm.SetBool("running", true);
        sliderMau.maxValue = maxMau;
        sliderMau.value = maxMau;
    }

    // Update is called once per frame
    void Update()
    {
        atm.SetBool("running", true);
        if (isMovingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "tuong")
        {
            // Thay đổi hướng di chuyển
            isMovingRight = !isMovingRight;
            // Quay đầu theo hướng mới
            Flip();
        }
        if (other.gameObject.tag == "danCoin")
        {
            sliderMau.value --;
            if (sliderMau.value == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Flip()
    {
        // Đảo chiều scale của đối tượng theo hướng mới
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
        }
    }
}
