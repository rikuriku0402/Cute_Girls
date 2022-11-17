using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class BackGround : MonoBehaviour
{
    Vector3 _cameraRectMin;

    [SerializeField]
    [Header("スクロールスピード")]
    float _scrollSpeed = -1;

    private void Start()
    {
        _cameraRectMin = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0f, Camera.main.transform.position.z));

        this.UpdateAsObservable().Subscribe(x => Move());
    }

    void Move()
    {
        transform.Translate(Vector3.right * _scrollSpeed * Time.deltaTime);

        if (transform.position.x < (_cameraRectMin.x - Camera.main.transform.position.x) * 2)
        {
            transform.position = new Vector2((Camera.main.transform.position.x - _cameraRectMin.x) * 2, transform.position.y);
        }
    }
}
