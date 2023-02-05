using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnClick() {
        SceneManager.LoadScene(scene); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
