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
    public float pressTime;
    public Slider slider;

    public float maxPressTime = 3;
    public int dartCount;

    public GameObject mainDart;

    public GameObject gameOverUI;
    public GameObject gameClearUI;
    public Text clearText;

    public GameObject finalgameClearUI;

    public static int clearCount = 50;
    public GameObject bowAudio;
    public bool dartplaying;

    // Start is called before the first frame update
    void Start()
    {
        dartCount = 10;
        dartplaying = true;
    }

    // Update is called once per frame
    void Update()
    {
        TimeSlider();
        dartCountlessGameOver();
        dartClear();
        GameClearUI();
        clearText.text = "Goal Score : " + clearCount + " POINT";

        if(dartplaying == false)
        {
            StartCoroutine("DartPlaying");
        }


        
        
        if (isMoved)
        {
            mainDart.SetActive(true);
            //문지르는중
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            dart.transform.position = ray.origin + ray.direction * 3.1f;
            pressTime += Time.deltaTime;
            if(pressTime > maxPressTime)
            {
                pressTime = 0;
            }
            //TimeSliderRepeat();
           
            //만약 프레스타임이 맥스프레스타임이 된다면 다시 줄어들게 만들고 싶다.
          
           
           

        }
        if (dartplaying == true && Input.GetMouseButtonDown(0))
            {


            dartCount--;
            //눌렀다.
            isMoved = true;
                firstTouch = Input.mousePosition;
                dart.SetNormal();
                pressTime = 0;
            }
            if (Input.GetMouseButtonUp(0))
            {
                //뗐다
                isMoved = false;
                dartplaying = false;

                float finalForce = Mathf.Clamp01(pressTime / maxPressTime) * force;
                float finalUpForce = Mathf.Clamp01(pressTime / maxPressTime) * upforce;
                if (finalForce < force * 0.3f)
                {
                    finalForce = force * 0.3f;
                }
                Vector3 dir = new Vector3(0, finalUpForce, finalForce);

                dart.force = Camera.main.transform.TransformDirection(dir);
                dart.Shoot();
            GameObject bowobject = Instantiate(bowAudio);
            bowobject.transform.position = transform.position;
            Destroy(bowobject, 2f);

            }
        }
    
    void TimeSlider()
    {
        slider.maxValue = maxPressTime;
        slider.value = pressTime;
    }

    void TimeSliderRepeat()
    {
        pressTime += Time.deltaTime;
        if(pressTime > maxPressTime)
        {
            pressTime -= Time.deltaTime;
        }
    }
   
    IEnumerator DartPlaying()
    {
        yield return new WaitForSeconds(3f);

        dartplaying=true;
    }

    void dartCountlessGameOver()
    {
        if(dartCount < 0 && ScoreManager.instance.score < clearCount)
        {
            gameOverUI.SetActive(true);
            GameManager.instance.OnMenu = true;
        }
    }

    void dartClear()
    {
        if(dartCount < 0 && ScoreManager.instance.score >= clearCount)
        {
            gameClearUI.SetActive(true);
            GameManager.instance.OnMenu = true;
        }
    }

    void GameClearUI()
    {
        if(clearCount > 450)
        {
            finalgameClearUI.SetActive(true);
            GameManager.instance.OnMenu = true;
        }
    }
}

