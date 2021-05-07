using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{

    public int tubeId;  // identifier number for this tube
    public AudioClip impact;
    AudioSource audioSource;
// called when something enters the tube's collider
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter (Collider col)
    {
       // Debug.Log("collsion " + col);
        // was it the player?
        if(col.CompareTag("Player"))
        { Debug.Log("Gate: " + col + tubeId);
            // tell the game manager that the player entered this tube
            GameManager.instance.OnPlayerEnterTube(tubeId);
            audioSource.PlayOneShot(impact, 0.4F);
        //  Destroy(transform.parent.gameObject);
        }
    }
}
