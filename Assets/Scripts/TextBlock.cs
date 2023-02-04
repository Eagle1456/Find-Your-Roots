using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBlock : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textBlock;
    // Start is called before the first frame update
    void Start()
    {
        ShowText(false);
    }

    public void ShowText(bool state)
    {
        textBlock.gameObject.SetActive(state);
    }
}
