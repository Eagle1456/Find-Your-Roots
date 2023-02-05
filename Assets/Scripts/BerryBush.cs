using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BerryBush : MonoBehaviour
{

    public UnityEvent nextGen;
    public UnityEvent TreeEvent;
    private bool touchingPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.transform.CompareTag("Player")) {
            touchingPlayer = true;    
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.transform.CompareTag("Player")) {
            touchingPlayer = false;    
        }
    } 


    // Update is called once per frame
    void Update()
    {
        if (touchingPlayer && (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.E))){
            TreeEvent.Invoke();
            PlayerController.nextGen.Invoke();
        } 
    }
}
