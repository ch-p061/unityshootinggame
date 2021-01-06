using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //필요속성 : 이동속도
    public float speed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //방향을 구한다
    Vector3 dir = Vector3.up;

    //이동공식 적용
    transform.position += dir * speed * Time.deltaTime;
    }
}
