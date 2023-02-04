using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTriggerBox : MonoBehaviour
{
    private const float rePositionDelay = .5f;

    [SerializeField]
    Grid grid;

    [SerializeField]
    Transform player;

    private void Start()
    {
        InvokeRepeating("ResetPos", 0f, .5f);
    }
    // Update is called once per frame
    void Update()
    {

        
    }

    void ResetPos()
    {
        Vector3 playerPos = player.transform.position;
        Vector3Int treePos = new Vector3Int((int)Mathf.Floor(playerPos.x), (int)Mathf.Floor(playerPos.y), (int)Mathf.Floor(playerPos.z));
        Vector3 cellPos = grid.GetCellCenterLocal(treePos);
        this.transform.position = cellPos;
    }

    
}
