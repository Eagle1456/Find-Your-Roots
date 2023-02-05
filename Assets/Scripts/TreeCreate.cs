using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCreate : MonoBehaviour
{
    [SerializeField]
    Grid grid;

    [SerializeField]
    private GameObject tree;

    [SerializeField]
    private TreeTriggerBox trigger;

    [SerializeField]
    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            GameManager.Instance.ResetGame();
        }
    }
    public void SetTreeToPlayer()
    {
        Vector3 playerPos = this.transform.position;
        Vector3 treePos = new Vector3(playerPos.x, playerPos.y-.34f, playerPos.z);
        // Vector3 cellPos = grid.GetCellCenterWorld(treePos);
        GameObject NewTree = Instantiate(tree, treePos, Quaternion.identity);
    }
}
