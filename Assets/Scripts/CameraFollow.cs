using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3((player.transform.position.x>90)?90:(player.transform.position.x<0)?0:player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
}
