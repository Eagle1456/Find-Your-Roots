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

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetTreeToPlayer();
        }
    }
    void SetTreeToPlayer()
    {
        Vector3 playerPos = this.transform.position;
        Vector3Int treePos = new Vector3Int(Mathf.FloorToInt(playerPos.x), (int) Mathf.FloorToInt(playerPos.y), (int) Mathf.FloorToInt(playerPos.z));
        Vector3 cellPos = grid.GetCellCenterWorld(treePos);
        GameObject NewTree = Instantiate(tree, cellPos, Quaternion.identity);
    }
}
