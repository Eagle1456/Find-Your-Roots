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
    private float rootOffset;

    [SerializeField]
    private GameObject tree;

    [SerializeField]
    private GameObject root;

    [SerializeField]
    private bool isSapling = true;

    private bool createdTree = false;
    private void Start()
    {
        
    }

    private void CreateTree()
    {
        if (isSapling) {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (!createdTree)
        {
            Vector3 newTreePos = new Vector3(transform.position.x, transform.position.y + treeOffset);
            Instantiate(tree, newTreePos, Quaternion.identity);
            createdTree = true;
        }
        else if (isSapling)
        {
            Vector3 newTreePosR = new Vector3(transform.position.x + rootOffset, transform.position.y - .5f);
            Vector3 newTreePosL = new Vector3(transform.position.x - rootOffset, transform.position.y - .5f);

            GameObject root1 = Instantiate(root, newTreePosL, Quaternion.identity);
            root1.GetComponent<Root>().rootDirection = Root.RootDir.LEFT;
            GameObject root2 = Instantiate(root, newTreePosR, Quaternion.identity);
            root2.GetComponent<Root>().rootDirection = Root.RootDir.RIGHT;

            isSapling = false;
        }
        
    }

    private void OnEnable()
    {
        TreeEvent.AddListener(CreateTree);
    }

    private void OnDisable()
    {
        TreeEvent.RemoveListener(CreateTree);
    }
}
