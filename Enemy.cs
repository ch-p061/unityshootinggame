using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표 : 적이 다른 물체와 충돌했을때 폭발효과를 준다
// 순서:1. 적이 다른 물체와 충돌했으니
// 2. 폭발공장에서 효과를 하나 만든다
// 3. 폭발공장주소(Enemy위치)
public class Enemy : MonoBehaviour
{
    //필요한 속성: 이동속도
    public float speed = 5;
    Vector3 dir;

    //폭발 공장 주소(외부에서 값을 넣어준다.)
    public GameObject explosionFactory;

    private void OnCollisionEnter(Collision other)
    {
        //에니미를 잡을때마다 현재 점수를 표시하고 싶다.
        ScoreManager.Instance.Score++; //아래 주석과 동일!

        /*
        //a.씬에서 ScoreManager 게임 오브젝트를 찾아온다.
        GameObject smObject = GameObject.Find("ScoreManager");
        //b.ScoreManager 게임오브젝트에서 얻어온다.
        ScoreManager sm = smObject.GetComponent<ScoreManager>();
        //c.ScoreManager의 Get/Sset 함수로 수정
        sm.SetScore(sm.GetScore() + 1);
        */

        // 2. 폭발공장에서 효과를 하나 만든다
        GameObject explosion = Instantiate(explosionFactory);
        // 3. 폭발공장주소(Enemy위치)
        explosion.transform.position = transform.position;//Enemy의 위치

        if (other.gameObject.name.Contains("Bullet"))
        {
            //부딪힌 물체를 비활성화
            other.gameObject.SetActive(false);

            //PlayerFire 클래스 얻어오기
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            //리스트에 총알 삽입
            player.bulletObjectPool.Add(other.gameObject);
        }
        else
        {
            //너죽고 
            Destroy(other.gameObject); //Destroy(collision.gameObject)와 동일
        }

        //나죽자
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        //0부터 9까지 10개의 값중에 하나를 랜덤으로 가져온다
        int randValue = UnityEngine.Random.Range(0, 10);
        //만약 3보다 작으면 플레이어 방향
        if (randValue < 3)
        {
            //플레이어를 찾는다
            GameObject target = GameObject.Find("Player");
            //플레이어 방향을 구한다
            dir = target.transform.position - transform.position;
            //방향의 크기를 1로 하고 싶다
            dir.Normalize(); //벡터 정규화 --> 크기를 1로 만든다.(단위벡터)
        }
        else // 그렇지 않으면 아래 방향
        {
            dir = Vector3.down;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //1. 방향을 구한다.
        // Vector3 dir = Vector3.down;

        //2. P=P0+vt
        transform.position += dir * speed * Time.deltaTime;
    }
}
