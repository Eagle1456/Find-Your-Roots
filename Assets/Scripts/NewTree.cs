using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTree : MonoBehaviour
{
    [SerializeField]
    private float treeOffset;

    [SerializeField]
    private GameObject tree;

    private void Start()
    {
        Invoke("CreateTree", 2f);
    }

    private void CreateTree()
    {
        Vector3 newTreePos = new Vector3(transform.position.x, transform.position.y + treeOffset);
        Instantiate(tree, newTreePos, Quaternion.identity);
    }
}
