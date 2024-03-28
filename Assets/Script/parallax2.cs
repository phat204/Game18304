using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class parallax2 : MonoBehaviour
{
    Material mat;
    float distance;
    [Range(0f, 0.5f)]
    public float speed = 0.2f;

    void Start()
    {
        mat = GetComponent<Renderer>().material;    
    }

    void Update()
    {
        distance += Time.deltaTime * speed;
        mat.SetTextureOffset("_MainTex", Vector2.right * distance);
    }
}
