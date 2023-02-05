using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    [SerializeField]
    private Vector3 startPos;

    [SerializeField]
    private GameObject player;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void ResetGame()
    {
        player.transform.SetPositionAndRotation(startPos, Quaternion.identity);

        GameObject[] trees = GameObject.FindGameObjectsWithTag("Tree");
        
        foreach (GameObject tree in trees)
        {
            Destroy(tree);
        }
    }

    
}
