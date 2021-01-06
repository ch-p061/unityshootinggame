using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            //부딪힌 물체를 비활성화
            other.gameObject.SetActive(false);
            //PlayerFire클래스 얻어오기
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            //리스트에 총알을 삽입
            player.bulletObjectPool.Add(other.gameObject);
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}