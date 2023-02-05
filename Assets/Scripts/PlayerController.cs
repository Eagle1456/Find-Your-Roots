using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float playerSpeed;
    public TreeCreate tree;
    private Rigidbody2D rb;
    public bool grounded { get; private set; }
    private bool touchingtree = false;
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
        dx = 0;
        seeds = 3;
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
        seeds = 3;
    }

    void OnTriggerEnter2D(Collider2D other){
        grounded = true;
        if (other.transform.CompareTag("Tree")) {
            touchingtree = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        grounded = false;
        touchingtree = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        dx = multiplier / 2 * playerSpeed * Input.GetAxis ("Horizontal") * Time.fixedDeltaTime;
        if (grounded && rb.velocity.y == 0.0f){
            if (Input.GetAxis ("Vertical") > 0) {
                rb.AddForce(transform.up * multiplier * playerSpeed);
            } 
        }
        rb.velocity = new Vector2(dx, rb.velocity.y);
    }
    
    private void Update()
    {
        if (grounded && !touchingtree && Input.GetAxis ("Vertical") < 0 && !makingseed) {
            StartCoroutine(seedPlace());
        }
        if (Input.GetKeyDown(KeyCode.O)) {
            InvokeTree();
        }
    }
    public void InvokeTree()
    {
        NewTree.TreeEvent.Invoke();
    }
}
