using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    public enum RootDir
    {
        LEFT,
        RIGHT
    }

    public RootDir rootDirection;
    [SerializeField]
    private float rootOffset;

    [SerializeField]
    private GameObject root;

    private bool createdRoot = false;

    private void CreateTree()
    {
        if (!createdRoot)
        {
            Vector3 newTreePos = Vector3.zero;
            switch (rootDirection){
                case RootDir.LEFT:
                    newTreePos = new Vector3(transform.position.x - rootOffset, transform.position.y);
                    break;
                case RootDir.RIGHT:
                    newTreePos = new Vector3(transform.position.x + rootOffset, transform.position.y);
                    break;
                default:
                    Debug.LogError("You fucked up");
                    break;
            }
            GameObject newRoot = Instantiate(root, newTreePos, Quaternion.identity);
            newRoot.GetComponent<Root>().rootDirection = rootDirection;
            createdRoot = true;
        }

    }

    private void OnEnable()
    {
        NewTree.TreeEvent.AddListener(CreateTree);
    }

    private void OnDisable()
    {
        NewTree.TreeEvent.RemoveListener(CreateTree);
    }
}
