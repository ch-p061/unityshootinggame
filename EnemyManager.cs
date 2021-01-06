using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//목표 : 적 자동생성
public class EnemyManager : MonoBehaviour
{
    //최소시간
    float minTime = 1;
    //최대시간
    float maxTime = 5;
    
    // 현재시간
    float currentTime;
    // 일정시간
    float createTime;
    // 적공장
    public GameObject enemyFactory;

    // Start is called before the first frame update
    void Start() // 지워도 무방하다!
    {
        //적 생성시간을 설정
        createTime = UnityEngine.Random.Range(minTime, maxTime);
    }

    // Update is called once per frame
    void Update()
    {
        // 1. 시간이 흐른다
        currentTime += Time.deltaTime;//0.1초씩+됨\

        // 2. 만약에 현재시간이 일정시간이 되면
        if(currentTime > createTime)
        {
            // 3. 적 공장에서 적을 생성해
            GameObject enemy = Instantiate(enemyFactory);
            //내 위치에 가져가 놓는다
            enemy.transform.position = transform.position;
            // 현재 시간을 0으로 초기화
            currentTime = 0;

            //적을 생성한 후 적의 생성시간을 다시 설정 (업데이트 할 때마다 적의 생성시간 만듬)
            createTime = UnityEngine.Random.Range(minTime, maxTime);
        }
    }
}
