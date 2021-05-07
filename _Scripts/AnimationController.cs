using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator; 
    public Animation anim;   
    public bool laneSwitched = true;
    public bool laneSwitcing;
    public bool inLaneA;
    public bool inLaneB = true;
    public bool inLaneC;
    // Start is called before the first frame update
    void Start()
    {
      //  anim = gameObject.GetComponent<Animation>();
       // anim["NormalDriving"].layer = 1;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.RightArrow) && inLaneA )
        {
            animator.SetTrigger("FromAtoB");
        }   
        if (Input.GetKeyDown(KeyCode.LeftArrow) && inLaneB)
        { 
            animator.SetTrigger("FromBtoA");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && inLaneB)
        { 
            animator.SetTrigger("FromBtoC");
        }
      if (Input.GetKeyDown(KeyCode.LeftArrow) && inLaneC)
            { 
                animator.SetTrigger("FromCtoB");
            }
    }
}
