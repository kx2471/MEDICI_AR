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
        //���� ��Ʈī��Ʈ�� �ϳ� �پ��ٸ�

        for (int i = 9; i >= 0; i--)
        {
            if (PlayerUnityEngine.instance.dartCount == i)
            {
                dartlist[i].SetActive(false);
            }
        }
        //����Ʈ�� ������ ���ӿ�����Ʈ���� ��Ȱ��ȭ ��Ű�� �ʹ�.

    }
}
