using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCreate : MonoBehaviour
{
    [SerializeField]
    Grid grid;

    [SerializeField]
    GameObject tree;

    // Start is called before the first frame update
    void Start()
    {

        SetTreeToPlayer();
    }

    void SetTreeToPlayer()
    {
        Vector3 playerPos = this.transform.position;
        Vector3Int treePos = new Vector3Int((int) Mathf.Round(playerPos.x), (int) Mathf.Round(playerPos.y), (int) Mathf.Round(playerPos.z));
        Vector3 cellPos = grid.GetCellCenterWorld(treePos);
        GameObject NewTree = Instantiate(tree, cellPos, Quaternion.identity);
    }
}
