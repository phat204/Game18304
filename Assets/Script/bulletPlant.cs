using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletPlant : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-5, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("heo"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("nen"))
        {
            Destroy(gameObject);
        }
    }
}
