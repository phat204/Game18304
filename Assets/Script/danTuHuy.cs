using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danTuHuy : MonoBehaviour
{
    Rigidbody2D rb;
    public float thoiGianHuy = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, thoiGianHuy);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-5, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("hoa"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("heo"))
        {
            // Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("nen"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("builet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
