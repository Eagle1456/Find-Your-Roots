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
        //Delete this when done 
        if (Input.GetKeyDown(KeyCode.J) && !trigger.IsTouching )
        {
            SetTreeToPlayer();
        }

        // Delete this when done
        if (Input.GetKeyDown(KeyCode.H))
        {
            NewTree.TreeEvent?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            GameManager.Instance.ResetGame();
        }
    }
    public void SetTreeToPlayer()
    {
        Vector3 playerPos = this.transform.position;
        Vector3Int treePos = new Vector3Int(Mathf.FloorToInt(playerPos.x), Mathf.FloorToInt(playerPos.y), (int) Mathf.FloorToInt(playerPos.z));
        Vector3 cellPos = grid.GetCellCenterWorld(treePos);
        GameObject NewTree = Instantiate(tree, cellPos, Quaternion.identity);
    }
}
