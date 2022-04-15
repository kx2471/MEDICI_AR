using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 다트는 포물선으로 날아가고 과녁에 감지되면 멈췄다가 2초뒤에 사라지고 싶다
public class Dart : MonoBehaviour
{
    public GameObject lessdart;
    public GameObject mainDart;


    
    // Start is called before the first frame update
    void update()
    {
        // max distance laycast
    }
       // 과녁판이 다트를 감지하면(trigger) 스코어가 올라간다
    private void OnTriggerEnter(Collider other) {
        // 다트보드라는 이름이 들어간 애랑 닿으면
        if (other.gameObject.CompareTag("DartBoard"))
        {
            PlayerUnityEngine.instance.dartplaying = true;
            mainDart.SetActive(false);
            DartBoard board = other.gameObject.GetComponent<DartBoard>();
            
            // 각 구역에 할당된 인덱스의 값만큼  
            
            //ScoreManager 컴포넌트에 점수를 올리고 싶다. 컴포넌트로 승 패 가름
            int score = ScoreManager.instance.GetScore() +board.myScore ; //
            ScoreManager.instance.SetScore(score);

            Instantiate(lessdart, this.transform.position, Quaternion.identity);
            
        }
    }

  

}
