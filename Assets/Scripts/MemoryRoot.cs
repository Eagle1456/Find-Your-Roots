using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemoryRoot : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private Button button;

    [SerializeField]
    private TextMeshProUGUI textBlock;

    [SerializeField]
    [TextArea(15, 20)]
    private string text;
    private SpriteRenderer rootSprite;
    private BoxCollider2D boxCollider;

    private void Start()
    {
        rootSprite = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
    }


    public void ClosePanel()
    {
        panel.SetActive(false);
        button.onClick.RemoveAllListeners();
        textBlock.text = "";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rootSprite.enabled = false;
            boxCollider.enabled = false;

            panel.SetActive(true);
            button.onClick.AddListener(ClosePanel);
            textBlock.text = text;
            textBlock.gameObject.SetActive(true);
        }
    }
}
