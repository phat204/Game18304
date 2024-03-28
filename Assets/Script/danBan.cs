using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danBan : MonoBehaviour
{
    // Start is called before the first frame update
    public float tocdodan =0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x+tocdodan * -1, transform.position.y, transform.position.z);
    }
}
