using PathCreation.Examples;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SpeedUI : MonoBehaviour
{
    public TMP_Text speedText;
    public Image speedBar;
    private float _speed;
    private float _maxspeed;
    float lerpSpeed;
    //public PathFollower pathFollower;
    public GameManager gm;
    private void Start()
    {
       // speed = PathFollower.throttle;
        _speed = 0;
        speedText.text =  "0 %";
    }

    private void Update()
    {
       _speed = (float) (Mathf.Round(gm.speed * 1f) / 1f); ;
        _maxspeed = gm.maxSpeed;
        //_speed = _speed = GameManager.instance.speed;
        float _speedp = (_speed /_maxspeed )* 100 ;
       
        speedText.text = _speedp + " %";
       // if (speed > maxSpeed) speed = maxSpeed;

        lerpSpeed = 3f * Time.deltaTime;

        SpeedBarFiller();
        ColorChanger();
    }

    void SpeedBarFiller()
    {
      speedBar.fillAmount = Mathf.Lerp(speedBar.fillAmount, (_speed / _maxspeed), lerpSpeed);
      //  ringHealthBar.fillAmount = Mathf.Lerp(speedBar.fillAmount, (health / maxHealth), lerpSpeed);


    }
    void ColorChanger()
    {
        Color speedColor = Color.Lerp(Color.red, Color.green, (_speed / GameManager.instance.maxSpeed));
        speedBar.color = speedColor;
       // ringHealthBar.color = healthColor;
    }

    
}
