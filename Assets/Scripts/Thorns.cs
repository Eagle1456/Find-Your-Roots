using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Thorns : MonoBehaviour
{
    public UnityEvent nextGen;
    public UnityEvent TreeEvent;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.transform.CompareTag("Player")) {
            //Reset everything for next load
            TreeEvent.Invoke();
            PlayerController.nextGen.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
