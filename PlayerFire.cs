using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 총알공장
    public GameObject bulletFactory;
    // 총구
    public GameObject firePosition;

    //탄창에 넣을 수 있는 총알의 갯수
    public int poolSize = 10;
    //오브젝트 배열
    //GameObject[] bulletObjectPool;
    //오브젝트 리스트
    public List<GameObject> bulletObjectPool;

    // Start is called before the first frame update
    void Start()
    {
        //태어날 때 오브젝트풀(탄창)에 총알을 생성해 넣는다
        //1. 태어날 때
        //2. 탄창을 총알을 담을 수 있는 크기로 만들어준다
        //배열 : bulletObjectPool = new GameObject[poolSize];
        //리스트
        bulletObjectPool = new List<GameObject>();
        //3. 탄창에 넣을 총알 개수 만큼 반복한다.
        for (int i = 0; i < poolSize; i++)
        {
            //4. 총알 공장에서 총알을 생성한다
            GameObject bullet = Instantiate(bulletFactory);
            //5. 총알을 오브젝트 풀에 넣는다.
            //배열방식 : bulletObjectPool[i] = bullet;
            //리스트 방식
            bulletObjectPool.Add(bullet);
            //비활성화!!!
            bullet.SetActive(false);
        }
        //실행되는 플랫폼이 안드로이드일 경우 조이스틱을 활성화
#if UNITY_ANDROID
    GameObject.Find("Joystick canvas XYBZ").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
        GameObject.Find("Joystick canvas XYBZ").SetActive(false);
#endif
    }

    // Update is called once per frame

    // 목표 : 사용자가 발사버튼을 누르면 총알발사
    // 순서 : 1. 발사버튼을 누른다
    // 만약 사용자가 발사버튼을 누른다면
    void Update()
    {
        //유니티 데이터와 PC 환경일 때 동작
#if UNITY_EDITOR || UNITY_STANDALONE
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
#endif
    }
    public void Fire()
    {
        //2. 비활성화된 총알이 있다면
        if (bulletObjectPool.Count > 0)
        {
            //3. 비활성화된 총알을 하나 가져온다
            GameObject bullet = bulletObjectPool[0]; //첫번째 인덱스에 접근
            //4. 총알을 발사한다(활성화 시킨다)
            bullet.SetActive(true);
            //오브젝트풀에서 총알을 제거
            bulletObjectPool.Remove(bullet);
            //총알을 위치시킨다
            bullet.transform.position = firePosition.transform.position;


            //2. 총알 공장에서 총알을 만든다
            //GameObject bullet = Instantiate(bulletFactory);
            //3. 총알을 발사한다
            //bullet.transform.position = firePosition.transform.position;
        }
    }
}