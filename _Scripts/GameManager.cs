using System.Collections;
using System.Collections.Generic;
using PathCreation.Examples;
using Unity.Profiling.LowLevel.Unsafe;
using UnityEngine;

public class GameManager : MonoBehaviour
{      public AudioClip yay;
        public AudioClip nay;
        public  AudioSource audioSource;
        public bool gameRunning;
    public float moderation = 1.5f;
    public float decrease = 1f;
    public float speed = 5;
    public float maxSpeed;
    public float health;
    public float maxHealth;
    public float boost = 0f;
    public Problem[] problems;      // list of all problems
    public int curProblem;          // current problem the player needs to solve
    public float timePerProblem;    // time allowed to answer each problem
    public GameObject checkpointParent;
    public float checkpointstotal;
    public float checkpointsright;
    public float checkpointswrong;
    public float checkpointsdone;
    public float remainingTime;
    public float totalPoints;// time remaining for the current problem
    public GameObject waitPoster;   
    public PathFollower player; // player object
    // Start is called before the first frame update
    // instance
    public static GameManager instance;
    public GameObject playerCollider;
    void Awake ()
    {
        // set instance to this script.
        instance = this;
        checkpointstotal = checkpointParent.transform.childCount;
            playerCollider.gameObject.SetActive(false);
    }
    
    void Start ()
    {
        GenericUI.instance.GetReadyUI();
       
        // set the initial problem
        SetProblem(0);
        gameRunning = false;
        StartCoroutine(GetReady());
    }
    

    void Win ()
    {    
        GenericUI.instance.RaceWin();
    }
 
// called if the remaining time on a problem reaches 0
    void Lose ()
    { Debug.Log("GameOver");
       GenericUI.instance.RaceLost();
    }

    void Pause()
    {
        Time.timeScale = 0.0f;
        // TODO set UI text

    }
    // sets the current problem
    void SetProblem (int problem)
    {
        curProblem = problem;
        remainingTime = timePerProblem;
      
        ProblemUI.instance.SetProblemText(problems[curProblem]);
        // set UI text to show problem and answers
    }
    // called when the player enters the correct gate
    void CorrectAnswer()
    {   Debug.Log("Right Answer");
        audioSource.PlayOneShot(yay, 0.7F);
        boost = 20f;
        // is this the last problem?
        if(problems.Length - 1 == curProblem)
            Win();
        else
            SetProblem(curProblem + 1);
        checkpointsright += 1;
        checkpointsdone += 1;
    }
 
// called when the player enters the incorrect gate
    void IncorrectAnswer ()
    {  audioSource.PlayOneShot(nay, 0.7F);
        Damage(10);
       Debug.Log("Wrong Answer");
       speed = speed - 10;
       checkpointswrong += 1;
       checkpointsdone += 1;
    }
    
// called when the player enters a gate
    public void OnPlayerEnterTube (int tube)
    {
        // did they enter the correct gate?
        if (tube == problems[curProblem].correctTube)
            CorrectAnswer();
        else
            IncorrectAnswer();
    }

void Update ()
{
    if (checkpointsdone == checkpointstotal && checkpointstotal > 0)
    {
        GenericUI.instance.RaceWin();
    }
    //Speed
    if (Input.GetKey("space") && gameRunning )
    {
        speed += moderation * Time.deltaTime;
    }
    else
    { 
        speed -= decrease;
    }
    speed =  Mathf.Clamp(speed,0f,25f) + boost;

    if (boost > 0)
    {
        boost -= 1f;
    }
    
    //Loose
    if (gameRunning){
    remainingTime -= Time.deltaTime;
    }
    if(remainingTime <= 0.0f)
    {
        GenericUI.instance.RaceLost();
    }
}


	

public void Damage(float damagePoints)
{
    if (health > 0)
        health -= damagePoints;
}
public void Heal(float healingPoints)
{
    if (health < maxHealth)
        health += healingPoints;
}

public void removePoints(float points)
{
    totalPoints =- points;
}
public void addPoints(float points)
{
    totalPoints =+ points;
}

public void upgradeMaxSpeed(float points)
{
 maxSpeed =+ points;
}
public void upgradeAccSpeed(float points)
{
    moderation =+ points;
}

public IEnumerator GetReady()
{

    float elapsedTime = 0f;
    float totalDuration = 1.8f;

    while (elapsedTime < totalDuration)
    {
        elapsedTime += Time.deltaTime;
        yield return null;
    }

    gameRunning = true;
    GenericUI.instance.GetReadyUiHide();
        
    playerCollider.gameObject.SetActive(true);
    Debug.Log("Coroutine done. Game started");
}


}
