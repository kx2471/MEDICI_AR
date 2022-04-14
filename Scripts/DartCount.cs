using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartCount : MonoBehaviour
{


    
    public GameObject[] dartlist;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < dartlist.Length; i++)
        {
            dartlist[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //만약 다트카운트가 하나 줄어든다면

        for (int i = 9; i >= 0; i--)
        {
            if (PlayerUnityEngine.instance.dartCount == i)
            {
                dartlist[i].SetActive(false);
            }
        }
        //리스트의 마지막 게임오브젝트부터 비활성화 시키고 싶다.

    }
}
