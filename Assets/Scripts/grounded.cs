using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grounded : MonoBehaviour
{
    [SerializeField] public PlayerController p;
    // Start is called before the first frame update
    void Start()
    {
        p.grounded = true;
        p.touchingtree = true;
    }

    void OnTriggerEnter2D(Collider2D other){
        // if (other.CompareTag("ground")){
            p.grounded = true;
        if (other.transform.CompareTag("Tree")) {
            p.touchingtree = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("ground")){
            p.grounded = false;
        }
        if (other.transform.CompareTag("Tree")) {
            p.touchingtree = false;
        }
        p.grounded = false;
    }
    // Update is called once per frame
    void Update()
    {
        print (p.grounded);
    }
}
