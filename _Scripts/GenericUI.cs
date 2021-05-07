using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Profiling.LowLevel.Unsafe;

public class GenericUI : MonoBehaviour
{ public static GenericUI instance;
    public GameManager gm;
     public GameObject banner;

  
    public Image bannerBg;
    public TMP_Text bannerText;
    public GameObject bannerButtonRestart;
    public GameObject bannerButtonContinue;
  
   

    [Space(3)]
    public TMP_Text gatestotal;
    public TMP_Text gatesdone;
    public TMP_Text gatesTotaldone;
    [Header("points")]
    public GameObject pointCalculation;
    public GameObject pointsButtonContinue;
    public TMP_Text gatesTotalPoints;
   // public TMP_Text gatesCorrect;
    public TMP_Text gatesCorrectPoints;
    //public TMP_Text gatesWrong;
    public TMP_Text gatesWrongPoints;
    public TMP_Text timePoints;   
    public TMP_Text grandTotalPoints;
    public TMP_Text bank;
    public float gatesTotaldonePointsFloat;
    public float grandTotalPointsFloat;

    [Header("shop")] 
    public bool _shopScreen;
    public GameObject shopScreen;
        public TMP_Text enginepoints;
        public TMP_Text engineacc;
        public TMP_Text hullpoints;
        public TMP_Text shopBank;
        public GameObject buttons;
        [Header("levelselect")]
        public bool _LevelScreen;
        public GameObject levelSelect;
        public TMP_Text levelBank;
    // Start is called before the first frame update
    void Awake ()
    {
        // set instance to this script.
        instance = this;
    }
    void Start()
    {
        gatestotal.text = gm.checkpointstotal.ToString("F0");
    }

    public void CheckTotalCheckpoints()
    {
        gatestotal.text = gm.checkpointstotal.ToString("F0");
    }
    // Update is called once per frame
    void Update()
    {
        gatesdone.text = gm.checkpointsdone.ToString("F0");
        levelBank.text = gm.totalPoints.ToString("F0");
        if (_shopScreen)
        {
            shopBank.text = gm.totalPoints.ToString("F0");
            enginepoints.text = gm.maxSpeed.ToString("F0");
            engineacc.text = gm.moderation.ToString("F0");
            hullpoints.text = + gm.health + "%";
            if (gm.totalPoints < 2f)
            {
                buttons.gameObject.SetActive(false);
            }
            
          
        }
    }
    public  void GetReadyUI()
    {
        bannerText.text = "GET READY!";
        bannerBg.color=Color.magenta;
        bannerButtonContinue.gameObject.SetActive(false);
        bannerButtonRestart.gameObject.SetActive(false);
        banner.gameObject.SetActive(true);
    }
    public  void GetReadyUiHide()
    {
        banner.gameObject.SetActive(false);
    }
    public void RaceWin()
    {
        bannerText.text = "RACE COMPLETE!";
        bannerBg.color=Color.cyan;
        banner.gameObject.SetActive(true);
    bannerButtonContinue.gameObject.SetActive(true);
    }
    public void RaceLost()
    {
        bannerText.text = "GAME OVER";
        bannerBg.color=Color.red;
        banner.gameObject.SetActive(true); 
        bannerButtonRestart.gameObject.SetActive(true);
    }
    public void PointCalculationScene()
    { _shopScreen = false;
        pointCalculation.gameObject.SetActive(true);
        levelSelect.gameObject.SetActive(false);
        shopScreen.gameObject.SetActive(false);
        StartCoroutine(CalculatePoints());
    }

    public void showShop()
    {
        _shopScreen = true;
        shopScreen.gameObject.SetActive(true);
        levelSelect.gameObject.SetActive(false);
        pointCalculation.gameObject.SetActive(false);
    }
    public void showLevels()
    {  _shopScreen = false;
        levelSelect.gameObject.SetActive(true);
       pointCalculation.gameObject.SetActive(false);
       shopScreen.gameObject.SetActive(false);
    }
    public IEnumerator CalculatePoints()
    {
         grandTotalPointsFloat = 0;
        grandTotalPoints.text = grandTotalPointsFloat.ToString("F0");

        float gatesTotaldoneFloat = gm.checkpointsdone;
        float _gatesTotaldonePointsFloat = gatesTotaldoneFloat * 2f;
        
        gatesTotaldone.text = gatesTotaldoneFloat.ToString("F0");
        
        float gatesCorrectFloat = gm.checkpointsright;
        float _gatesCorrectPointsFloat = gatesCorrectFloat * 5f;
        float gatesCorrectPointsFloat = 0;
        gatesCorrectPoints.text = gatesCorrectFloat.ToString("F0");
        
        float gatesWrongFloat = gm.checkpointswrong;
        float _gatesWrongPointsFloat = gatesWrongFloat * -5;
        float gatesWrongPointsFloat = 0;
        gatesWrongPoints.text = gatesWrongFloat.ToString("F0");
        
        float timeFloat =gm.remainingTime;
        float _timePointsFloat = timeFloat * 3;
        float timePointsFloat = 0;
       // timePoints.text = timePointsFloat.ToString();
        
        float _grandTotalPointsFloat = _gatesTotaldonePointsFloat + gatesCorrectPointsFloat + gatesWrongPointsFloat + timePointsFloat;

       // yield return new WaitForSeconds(0);
        
        while (_gatesTotaldonePointsFloat > gatesTotaldonePointsFloat)
        { gatesTotaldonePointsFloat += 15*Time.deltaTime;
            gatesTotalPoints.text = gatesTotaldonePointsFloat.ToString("F0");
            yield return null;
        }
        
        while (_gatesCorrectPointsFloat > gatesCorrectPointsFloat)
        { gatesCorrectPointsFloat += 15*Time.deltaTime;
            gatesCorrectPoints.text = gatesCorrectPointsFloat.ToString("F0");
            yield return null;
        }
        while (_gatesWrongPointsFloat > gatesWrongPointsFloat)
        { gatesWrongPointsFloat += 15*Time.deltaTime;
            gatesWrongPoints.text = gatesWrongPointsFloat.ToString("F0");
            yield return null;
        }
        
        while (_timePointsFloat > timePointsFloat)
        { timePointsFloat += 25*Time.deltaTime;
            timePoints.text = timePointsFloat.ToString("F0");
            yield return null;
        }
        
        while (grandTotalPointsFloat < _grandTotalPointsFloat)
        {
            grandTotalPointsFloat += 15*Time.deltaTime;
            grandTotalPoints.text = grandTotalPointsFloat.ToString("F0");
            yield return null;
           
        }
        grandTotalPoints.text = _grandTotalPointsFloat.ToString("F0");
        pointsButtonContinue.gameObject.SetActive(true);
        gm.addPoints(_grandTotalPointsFloat);
        Debug.Log("CalculatePoints done.");
    }
    
    
}
