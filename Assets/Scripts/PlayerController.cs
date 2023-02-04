using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float playerSpeed;

    private Rigidbody2D rb;
    private bool grounded;
    private float multiplier = 30; 
    private float dx;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        dx = 0;
    }

    void OnTriggerEnter2D(Collider2D other){
        grounded = true;
    }

    void OnTriggerExit2D(Collider2D other){
        grounded = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dx = multiplier / 2 * playerSpeed * Input.GetAxis ("Horizontal") * Time.fixedDeltaTime;

        if (rb.velocity.y == 0 && grounded && Input.GetAxis ("Vertical") > 0) {
            rb.AddForce(transform.up * multiplier * playerSpeed);
        }
        
        rb.velocity = new Vector2(dx, rb.velocity.y);
    }
}
