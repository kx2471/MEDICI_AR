using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 5f;
    float yVelocity;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
        // 2. ���� ����Ƚ���� �ִ�����Ƚ������ �۰� ���� ��ư�� ������ y�ӵ��� jumpPower�� �����ϰ�ʹ�.
        if (Input.GetButtonDown("Jump"))
        {
            
            
        }
        // �̵����� P = P0 + vt 
        // v : velocity : ����� �ӷ��� ���� ������

        // 1. ������� �Է¿�����
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        // 2. �����¿�� ������ �����
        Vector3 dir = Vector3.right * h + Vector3.forward * v;
        // �����߻�!! dir�� ũ�Ⱑ 1�� �ƴѰ�찡 �ִ�. ũ�⸦ 1�� ������ְ�ʹ�.
        dir.Normalize();
        // 3. �� �������� �̵��ϰ�ʹ�.
        transform.position += dir * speed * Time.deltaTime;
    }
}