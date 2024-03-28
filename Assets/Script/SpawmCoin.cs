using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawmCoin : MonoBehaviour
{

    // Từ 3-5s sinh coin một lần
    // Số lượng coin sinh ra từ 5-15 coin
    // Coin sinh ra theo hình sin
    // Vị trí trước player ngoài khung hình (15-30 unit)
    // Coin bị xóa khi nhân vật đi quá (ngoài màn hình) -- chuwa code


    bool enableSpawm;
    public Transform player; //nhân vật
    public GameObject coin; //prefab coin
    public float rangeToDestroyObject = 50f; //Khoảng cách để tạo sẵn coin và hủy
    public void Start()
    {
        enableSpawm = true;
    }

    void Update()
    {
        // Cứ 5 giây thì làm một điều gì đó
        // timer += Time.deltaTime; //mỗi giây timer tăng lên 1 giá trị
        
        // if (timer > =5f)
        // {
        //    //TO DO
        //    timer = 0f;
        // }

        //Nếu enableSpawm == true thì cho phép sinh coin
        if (enableSpawm)
        {
            enableSpawm = false; //không cho sinh coin nữa
                                 //TODO
                                 //Thực hiện sinh coin
                                 //Test Debug.Log("Đã sinh coin");

            //12f là khoảng rộng nửa màn hình , nên lấy số to hơn một chút để coin hiện ngoài màn
            //float viTriX = player.position.x + 12f;

            float viTriX = player.position.x + Random.Range(30f, 35f);
            float viTriY = 0.9f * Mathf.Sin(viTriX) + 0.5f;

            //Sinh coin, ở vị trí nào, hướng xoay (không đổi), là con của đối tượng nào
            //Instantiate(coin, new Vector3(viTriX, viTriY, 0),Quaternion.identity, transform); //Sinh ra một coin

            int soCoin = Random.Range(5, 10);

            for (int i = 0; i< soCoin;  i++)
            {
                GameObject newCoin = Instantiate(coin, new Vector3(viTriX, viTriY, 0), Quaternion.identity, transform); //Sinh ra một coin
                if (newCoin != null) 
                {
                    StartCoroutine(DestroyCoin(newCoin));
                }
                viTriX += Random.Range(1.5f, 1.8f); //khoảng cách mỗi coin tiếp theo là ngẫu nhiên 
                viTriY = 0.9f * Mathf.Sin(viTriX) + 0.5f;
            }

            //Chờ 5-10s thì sinh coin tiếp
            //Với các hàm IE, gọi bằng coroutine
            StartCoroutine(DelayForSpawm()); 
        }
        
    }

    IEnumerator DelayForSpawm()
    {
        float timer = Random.Range(3f, 5f);
        yield return new WaitForSeconds(timer);
        enableSpawm = true;
    }
    IEnumerator DestroyCoin(GameObject coinOld)
    {
        yield return new WaitUntil(() => Vector2.Distance(player.position, coinOld.transform.position) > rangeToDestroyObject);
        Destroy(coinOld);
    }
}
