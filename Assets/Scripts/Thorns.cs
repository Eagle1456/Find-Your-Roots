using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Thorns : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D other){
        if (other.transform.CompareTag("Player")) {
            //Reset everything for next load
            NewTree.TreeEvent.Invoke();
            PlayerController.nextGen.Invoke();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
