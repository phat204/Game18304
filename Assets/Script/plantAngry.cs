using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantAngry : MonoBehaviour
{
    public GameObject _bullet;
    public Transform _bulletPos;
    public float _timer; // để public để nhìn khi chạy
    Animator _animator;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > 3f) //đủ đk hơn 35, thay đối chõ này không phải cố định 3s mà ngẫu nhiên 3-5s bắn 1 lần
        {
            _animator. SetTrigger("atk");
            _timer = 0.0f;
        }
    }
    private void PlaintShoot ()
    {
        GameObject tmp = Instantiate(_bullet, _bulletPos.position, Quaternion. identity);
        Destroy(tmp, 3f);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
        }
    }
}
