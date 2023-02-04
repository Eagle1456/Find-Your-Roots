using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class NewTree : MonoBehaviour
{
    public static UnityEvent TreeEvent = new UnityEvent();

    [SerializeField]
    private float treeOffset;

    [SerializeField]
    private GameObject tree;

    private bool createdTree = false;
    private void Start()
    {
        
    }

    private void CreateTree()
    {
        if (!createdTree)
        {
            Vector3 newTreePos = new Vector3(transform.position.x, transform.position.y + treeOffset);
            Instantiate(tree, newTreePos, Quaternion.identity);
            createdTree = true;
        }
        
    }

    private void OnEnable()
    {
        TreeEvent.AddListener(CreateTree);
    }

    private void OnDisable()
    {
        TreeEvent.AddListener(CreateTree);
    }
}
