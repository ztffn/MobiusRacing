using System;

using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    
    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            print("1 key was pressed");
            LoadThisScene("LVL1");
                    
        }
        if (Input.GetKeyDown("2"))
        {
            print("2 key was pressed");
            LoadThisScene("LVL2");
                    
        }
        if (Input.GetKeyDown("3"))
        {
            print("3 key was pressed");
            LoadThisScene("LVL3");
            
        }
        if (Input.GetKey("r")) {
            Restart();
        }
    }
//
    void Start()
    {
     
    }

    public void LoadThisScene(string scenename)
    {
        Debug.Log("sceneName to load: " + scenename);
        SceneManager.LoadScene(scenename);
    }
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}