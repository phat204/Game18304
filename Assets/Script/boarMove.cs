using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heoMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator atm;
    public int moveSpeed;
    bool isMovingRight = true; // Biến này để xác định hướng di chuyển của boar

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        atm = GetComponent<Animator>();
        moveSpeed = 3;
        atm.SetBool("running", true);
    }

    // Update is called once per frame
    void Update()
    {
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

    }
}
