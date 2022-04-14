using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Dartpin dart;
    bool isMoved;
    Vector3 firstTouch;
    public float force = 50;
    public float upforce = 10; 
    float pressTime;
    public Slider slider;
    public GameObject mainDart;

    public float maxPressTime = 3;


    public int dartCount;
    
    // Start is called before the first frame update
    void Start()
    {
        dartCount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        TimeSlider();
        if (Input.touchCount > 0)
        {
            
            Touch touch = Input.GetTouch(0);

            if (isMoved)
            {
                mainDart.SetActive(true);
                dartCount--;
                //¹®Áö¸£´ÂÁß
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                dart.transform.position = ray.origin + ray.direction * 3.1f;
                pressTime += Time.deltaTime;
                 
                
            }
            if (touch.phase == TouchPhase.Began)
            {
                //´­·¶´Ù.
                isMoved = true;
                firstTouch = Input.mousePosition;
                dart.SetNormal();
                pressTime = 0;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                //¶Ã´Ù
                isMoved = false;


                float finalForce = Mathf.Clamp01(pressTime / maxPressTime) * force;
                float finalUpForce = Mathf.Clamp01(pressTime / maxPressTime) * upforce;
                if (finalForce < force * 0.3f)
                {
                    finalForce = force * 0.3f;
                }
                Vector3 dir = new Vector3(0, finalUpForce, finalForce);

                dart.force = Camera.main.transform.TransformDirection(dir);
                dart.Shoot();


            }
        }
    }

    void TimeSlider()
    {
        slider.maxValue = maxPressTime;
        slider.value = pressTime;
    }

}
