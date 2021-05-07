using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSwitcher : MonoBehaviour
{ 
    
    public float xOffset;
    public float yOffset;
    public float zOffset;
    public bool inLaneA;
    public bool inLaneB;
    public bool inLaneC;
    public bool laneSwitched;
    public float switchspeed = 5f;
    private float turnrate = 2f;
    public float yAngle;
    // Start is called before the first frame update
    void Start()
    {
      inLaneB = true;
      laneSwitched = true; 
    }

    // Update is called once per frame
    
    void Update()
    {
        transform.localPosition = new Vector3(xOffset, yOffset, zOffset);
        transform.localRotation = Quaternion.Euler(0, yAngle, 0);
       // transform.Rotate(0, yAngle, 0, Space.Self);
    // transform.rotation= Quaternion.Lerp (transform.rotation, targetRotation , 10 * smooth * Time.deltaTime); 
     // var totalRotationTime = 5.0f;
    //  var degreesPerSecond = go.transform.eulerAngles.y / totalRotationTime;
 // go.transform.Rotate(new Vector3(0, degreesPerSecond * Time.deltaTime, 0));
   
 //move right
     void laneA()
     {
         zOffset = 2;  
         inLaneA = true;
         inLaneB = false;
         inLaneC = false;
         laneSwitched = false;
     }
     void laneB()
     {
         zOffset = 0;  
         inLaneA = false;
         inLaneB = true;
         inLaneC = false;
         laneSwitched = false;
     }
     void laneC()
     {
         zOffset = -2;  
         inLaneA = false;
         inLaneB = false;
         inLaneC = true;
         laneSwitched = false;
     }

     if (Input.GetKeyDown(KeyCode.RightArrow) && inLaneA && laneSwitched)
     { Debug.Log("MoveRight");
         StartCoroutine( SwitchToBfromA());
        
     }
     if (Input.GetKeyDown(KeyCode.RightArrow) && inLaneB && !laneSwitched)
     { Debug.Log("MoveRight");
         laneSwitched = true; 
         laneC();
     }
     if (Input.GetKeyDown(KeyCode.LeftArrow) && inLaneB && laneSwitched)
     { Debug.Log("MoveLeft");
         StartCoroutine( SwitchToA());
     }
     if (Input.GetKeyDown(KeyCode.RightArrow) && inLaneC && !laneSwitched)
     { Debug.Log("MoveLeft");
         laneSwitched = true; 
         laneB();
     }

   
     IEnumerator SwitchToA()
     { laneSwitched = false;
         while(yAngle >= -10)
         {
             yAngle -= turnrate*Time.deltaTime;
             yield return null;
         }

         while (zOffset <= 2  )
         {
             zOffset += switchspeed*Time.deltaTime;
             yield return null;
         }

         yield return new WaitForEndOfFrame();
         laneA();
         laneSwitched = true;
         yield break;
     }
     
     IEnumerator SwitchToBfromA()
     { laneSwitched = false;
         while(yAngle <= 10)
         {
             yAngle += turnrate*Time.deltaTime;
             yield return null;
         }

         while (zOffset <= 0  )
         {
             zOffset -= switchspeed*Time.deltaTime;
             yield return null;
         }

         yield return new WaitForEndOfFrame();
         laneB();
         laneSwitched = true;
     }
     
     
     /*
       if (inLaneA){
          
            laneSwitched = false;
            //move right
            if (Input.GetKeyDown(KeyCode.RightArrow) && !laneSwitched)
            {
                inLaneA = false;
                inLaneB = true;
                inLaneC = false;
                laneSwitched = true;
           Debug.Log("MoveRight");
           // zOffset = 0;
            }
            //move left
            if ( Input.GetKeyDown(KeyCode.LeftArrow))
            {
                inLaneA = true;
                inLaneB = false;
                inLaneC = false;
            }
            
        }
            
 if (inLaneB){
     zOffset = 0;
     laneSwitched = false;
     if (Input.GetKeyDown(KeyCode.RightArrow) && !laneSwitched)
        {
            inLaneA = false;
            inLaneB = false;
            inLaneC = true;
            laneSwitched = true;
            Debug.Log("MoveRight");
        }
            //move left
        if ( Input.GetKeyDown(KeyCode.LeftArrow) && !laneSwitched)
        {
            inLaneA = true;
            inLaneB = false;
            inLaneC = false;
            laneSwitched = true;
          //  transform.position = transform.position + new Vector3(-1f, yOffset, 0);
         // zOffset = -2;
        }
 }
 if (inLaneC ){
     zOffset = -2;
     laneSwitched = false;
     //move right
     if (Input.GetKeyDown(KeyCode.RightArrow)  && !laneSwitched)
     {
         inLaneA = false;
         inLaneB = false;
         inLaneC = true;
         laneSwitched = true;
     }
     //move left
     if ( Input.GetKeyDown(KeyCode.LeftArrow)  && !laneSwitched)
     {
         inLaneA = false;
         inLaneB = true;
         inLaneC = false;
         laneSwitched = true;
        // transform.position = transform.position + new Vector3(0f, yOffset, 0);
       // zOffset = 0;
     }
 }
*/
   
    } }

