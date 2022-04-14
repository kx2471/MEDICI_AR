using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 점수를 표현하고 싶다.
// 점수가 갱신되면 ui에도 표현하고 싶다.
// 과녁판이 다트를 감지하면(trigger) 스코어가 올라간다 << 감지
//  과녁판에 각 구역마다 다른 점수가 입력되고 싶다.   
//  
// 
public class ScoreManager : MonoBehaviour
{

public static ScoreManager instance;

    private void Awake()
    {
        ScoreManager.instance = this;
    }
    public int score;  // 구조상 퍼블릭으로 하면 좋진 않음

    public int GetScore()
    {
        return score;
    }
    public void SetScore(int value) // SetScore 에 값을 넣으면 = score 
    {
        score = value;
        textScore.text = "Current Score : " + score.ToString() + " POINT";
        ClearScore.text = "Your Score : " + score.ToString();
    }
    public Text textScore;
    public Text ClearScore;
    

    // Start is called before the first frame update
    void Start()
    {
        SetScore(0);
        //태어날 때 스코어를 0점으로 표현하고 싶다.

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
