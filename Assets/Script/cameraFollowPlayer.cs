using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowPlayer : MonoBehaviour
{
    public GameObject player;

    void Update()
    {
        if (player != null) // Kiểm tra xem player đã được gán chưa
        {
            Vector3 targetPosition = player.transform.position;
            targetPosition.y = transform.position.y; // Cố định vị trí Y của camera
            targetPosition.z = transform.position.z;
            transform.position = targetPosition;
        }
    }
}
