using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float playerSpeed;
    public TreeCreate tree;
    private Animator a;
    private Rigidbody2D rb;
    public bool grounded = false;
    public bool touchingtree = false;
    private bool makingseed = false;
    private float multiplier = 30; 
    private float dx;
    public int seeds;
    public static UnityEvent nextGen = new UnityEvent();
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        tree = gameObject.GetComponent<TreeCreate>();
        a = gameObject.GetComponent<Animator>();
        dx = 0;
        seeds = 0;
    }

    IEnumerator seedPlace ()
    {
        makingseed = true;
        if (seeds>0) {
            tree.SetTreeToPlayer();
            --seeds;
            yield return new WaitForSeconds(2);
        }
        makingseed = false;
    }

    void OnEnable () {
        nextGen.AddListener(NextGen);
    }
    
    void OnDisable () {
        nextGen.RemoveListener(NextGen);
    }

    void NextGen() {
        gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        tree.SetTreeToPlayer();
        gameObject.transform.position = new Vector2(-10, -3);
        rb.velocity = new Vector2(0,0);
        seeds = 0;
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        // print (grounded && rb.velocity.y <= 0.001f);
        dx = multiplier / 2 * playerSpeed * Input.GetAxis ("Horizontal") * Time.fixedDeltaTime;

        Debug.Log(rb.velocity.y);
        if (grounded && rb.velocity.y <= 0.00001f){
            if (Input.GetAxis ("Vertical") > 0) {
                rb.AddForce(transform.up * multiplier * playerSpeed);
            } 
        }
        rb.velocity = new Vector2(dx, rb.velocity.y);
        a.SetBool("grounded", rb.velocity.y < 0.00001);
        a.SetFloat("Velocity", dx);
    }
    
    private void Update()
    {
        if (grounded && rb.velocity.y == 0.0f && !touchingtree && Input.GetAxis ("Vertical") < 0 && !makingseed) {
            StartCoroutine(seedPlace());
        }
    }
    public void InvokeTree()
    {
        NewTree.TreeEvent.Invoke();
    }
}
