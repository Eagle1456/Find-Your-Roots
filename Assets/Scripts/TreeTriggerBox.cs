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

    public bool IsTouching { get; private set; }

    private void Start()
    {
        IsTouching = false;
        InvokeRepeating("ResetPos", 0f, .5f);
    }

    void ResetPos()
    {
        Vector3 playerPos = player.transform.position;
        Vector3Int treePos = new Vector3Int((int)Mathf.Floor(playerPos.x), (int)Mathf.Floor(playerPos.y), (int)Mathf.Floor(playerPos.z));
        Vector3 cellPos = grid.GetCellCenterLocal(treePos);
        this.transform.position = cellPos;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IsTouching = true;
        Debug.Log("Touching!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        IsTouching = false;
        Debug.Log("No longer Touching!");
    }
}
