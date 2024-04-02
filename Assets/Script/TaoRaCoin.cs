using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Mỗi lần tạo ra N coin, ví dụ 10
//Sau một khoảng thời gian 5 giây, lại vẽ ra coin 1 lần
//Mỗi lần vẽ ra coin ở phía bên tay phải người chơi, phía ngoài màn hình (20)
//Khoảng cách mỗi coin 1f


public class TaoRaCoin : MonoBehaviour
{
    public Transform _player;
    public GameObject _coinPrefab;
    public int _soCoin; //Số coin tạo ra mỗi lần
    public float _thoiGianVe; //Bao lâu vẽ một lần
    private float _khoangCachVe; //Vẽ cách nhân vật bao xa
    private float _viTriVeX;
    private float _viTriVeY;
    public float _chieuCaoSin;
    public float _chieuRongSin;
    private float _chieuCaoToiThieu;
    private float _thoiGian;

    void Start()
    {
        _soCoin = 12;
        _thoiGianVe = 3.5f;
        _khoangCachVe = 20f;
        _chieuCaoSin = 2f;
        _chieuRongSin = 2f;
        _chieuCaoToiThieu = -0.5f;
        
        _thoiGian = 0;
        veCoin2();
    }

    // Update is called once per frame
    void Update()
    {
        _thoiGian += Time.deltaTime;
        if ( _thoiGian > _thoiGianVe)
        {
            veCoin2();
            _thoiGian = 0;
        }
    }

    private void veCoin()
    {
        _viTriVeX = _player.position.x + _khoangCachVe;
        for (int i=0; i < _soCoin; i++)
        {
            _viTriVeY = _chieuCaoSin*Mathf.Abs(Mathf.Sin(_viTriVeX/ _chieuRongSin))+ _chieuCaoToiThieu;
            Instantiate(_coinPrefab, new Vector3(_viTriVeX, _viTriVeY, 0), Quaternion.identity, transform);
            _viTriVeX++;
        }
    }
    private void veCoin2() //đồ thi parabol
    {
        int _soCoin2 = (int)(_soCoin / 2); //Nửa số coin int _soCoin2;
        _soCoin2 = Random. Range (2, 7);
        float _a; //độ cong hình parabol, ngẫu nhiên mỗi lần vẽ
        _a = Random. Range(0.07f, 0.12f);
        float _b; //d6 lech chieu cao, ngau nhien moi lan ve
        _b = Random. Range(0.2f, 0.7f);
        //Vị trí đầu tiên vẽ coin là vị trí người chơi, cộng thêm khoảng cách vẽ vào X, và chiều cao vào y
        Vector3 _nextPos = _player.position + new Vector3(_khoangCachVe, _chieuCaoToiThieu, 0); //
        for (int i = -1*_soCoin2; i<= _soCoin2; i++ ) 
        {
            //y = -a*x*x + độ lệch để đưa đường parabol về gốc tọa độ. Trong đó a quyết định độ cong
            Vector3 _toaDoVe = _nextPos + new Vector3(i + _soCoin2, -1 * _a * i * i + _a *_soCoin + _b, 0f);
            Instantiate(_coinPrefab, _toaDoVe, Quaternion. identity, transform);
        }
    }
}
