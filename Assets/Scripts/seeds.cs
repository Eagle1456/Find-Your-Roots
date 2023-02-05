using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeds : MonoBehaviour
{
    private bool hasSeeds = true;
    [SerializeField] private PlayerController player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if (hasSeeds && other.transform.CompareTag("Player")) {
            player.seeds = 3;
            hasSeeds = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Method()
    {
        hasSeeds = true;
    }

    private void OnEnable()
    {
        PlayerController.nextGen.AddListener(Method);
    }

    private void OnDisable()
    {
        PlayerController.nextGen.RemoveListener(Method);
    }
}
