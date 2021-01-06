using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//목표 : 에니미를 잡을때마다 점수를 표시
//속성: 현재점수 UI, 현재점수기억
public class ScoreManager : MonoBehaviour
{
    //현재점수 UI
    public Text currentScoreUI;
    //현재점수
    private int currentScore;
    //최고점수 UI
    public Text bestScoreUI;
    //최고점수
    private int bestScore;

    //싱글턴 객체
    public static ScoreManager Instance = null; //Instance는 태어난 대상변수

    public int Score
    {
        get
        {
            return currentScore;
        }

        set
        {
            //to do
            //c.ScoreManager 클래스 속성에 값을 할당한다.
            currentScore=value;
            //점수표시
            currentScoreUI.text = "현재 점수 : " + currentScore;

            //목표 : 최고 점수를 표시한다.
            //1. 현재 점수가 최고 점수보다 크다
            //->만약 현재점수가 최고 점수를 초과했다면
            if (currentScore > bestScore)
            {
                //2. 최고 점수를 갱신
                bestScore = currentScore;
                //점수표시
                bestScoreUI.text = "최고 점수 : " + bestScore;
                //목표: 최고 점수를 저장하고 싶다.
                PlayerPrefs.SetInt("Best Score", bestScore);
            }
        }
    }

    //싱글턴 객체에 값이 없으면 자기 자신을 할당
    void Awake()// 객체를 생성할 때 단 한번만 사용!(이 객체가 생성되면 Awake실행)
    {
        if(Instance == null)
        {
            Instance = this;//나를 넣어준다(ScoreManager가 생성됐을때 객체 자신을 뜻함)
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //목표 : 최고점수를 불러와 bestScore 변수에 할당한다
        //순서 : 1. 최고점수를 불러와 bestScore에 넣어주기
        //PlayerPrefs.SetInt("Best Score", 0); //점수를 초기화 하고 싶을때
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        print(bestScore);
        //2.최고 점수를 화면에 표시
        bestScoreUI.text = "최고점수 : " + bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            bestScore = 0;
            currentScore = bestScore;
            //2.최고 점수를 화면에 표시
            bestScoreUI.text = "최고점수 : " + bestScore;
        }
    }

    //currentScore에 값을 넣고 화면에 표시하기
    public void SetScore(int value)
    {
        
    }
        //currentScore 값 가져오기
        public int GetScore()
        {
            return currentScore;
        }
    }
