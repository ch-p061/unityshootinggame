using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 플레이어가 이동할 속력
    public float speed = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        print("h : " + h + "v : " + v);

        //Vector3 dir = Vector3.right * h + Vector3.up * v;
        //이거를 줄여서
        Vector3 dir = new Vector3(h, v, 0); //Unity에서 제공하는 방법
        // transform.Translate(dir * speed * Time.deltaTime);
        
        //P=P0+vt 공식으로 변경
        transform.position += dir * speed * Time.deltaTime;

        //트랜스폼아 니가 가진 트렌슬레이트 기능을 불러와봐!
        //transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
