using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUnityEngine : MonoBehaviour
{
    public static PlayerUnityEngine instance;
    private void Awake()
    {
        instance = this;
    }

    public Dartpin dart;
    bool isMoved;
    Vector3 firstTouch;
    public float force = 30;
    public float upforce = 10;
    float pressTime;
    public Slider slider;

    public float maxPressTime = 3;
    public int dartCount;

    public GameObject mainDart;

    public GameObject gameOverUI;
    public GameObject gameClearUI;
    public Text clearText;

    public GameObject finalgameClearUI;

    public static int clearCount = 50;

    // Start is called before the first frame update
    void Start()
    {
        dartCount = 10;
    }

    // Update is called once per frame
    void Update()
    {
        TimeSlider();
        dartCountlessGameOver();
        dartClear();
        GameClearUI();
        clearText.text = "Goal Score : " + clearCount + " POINT";




        
        
            if (isMoved)
            {
            mainDart.SetActive(true);
            //¹®Áö¸£´ÂÁß
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                dart.transform.position = ray.origin + ray.direction * 3.1f;
                pressTime += Time.deltaTime;


            }
            if (Input.GetMouseButtonDown(0))
            {

            dartCount--;
            //´­·¶´Ù.
            isMoved = true;
                firstTouch = Input.mousePosition;
                dart.SetNormal();
                pressTime = 0;
            }
            if (Input.GetMouseButtonUp(0))
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
    

    void TimeSlider()
    {
        slider.maxValue = maxPressTime;
        slider.value = pressTime;
    }

    void dartCountlessGameOver()
    {
        if(dartCount < 0 && ScoreManager.instance.score < clearCount)
        {
            gameOverUI.SetActive(true);
        }
    }

    void dartClear()
    {
        if(dartCount < 0 && ScoreManager.instance.score >= clearCount)
        {
            gameClearUI.SetActive(true);
        }
    }

    void GameClearUI()
    {
        if(clearCount > 450)
        {
            finalgameClearUI.SetActive(true);
        }
    }
}

