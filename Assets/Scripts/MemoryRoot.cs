using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MemoryRoot : MonoBehaviour
{

    [SerializeField]
    private bool isEnd = false;

    [SerializeField]
    private GameObject panel;

    [SerializeField]
    private Button button;

    [SerializeField]
    private GameObject textBlock;

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
        Debug.Log("Clicked!");
        panel.SetActive(false);
        if (!isEnd)
        {
            button.onClick.RemoveAllListeners();
        }
        textBlock.GetComponent<TextMeshProUGUI>().text = "";
    }

    public void EndScript()
    {
        button.onClick.RemoveAllListeners();
        Debug.Log("End game!");
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            rootSprite.enabled = false;
            boxCollider.enabled = false;

            panel.SetActive(true);
            textBlock.SetActive(true);
            button.onClick.AddListener(ClosePanel);
            if(isEnd)
            {
                button.onClick.AddListener(EndScript);
            }
            textBlock.GetComponent<TextMeshProUGUI>().text = text;

        }
    }
}
