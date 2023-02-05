using UnityEngine;
using System.Collections;
 
// Quits the player when the user hits escape
 
public class Esc : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
}