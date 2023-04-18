using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI headerField;

    [SerializeField]
    private TextMeshProUGUI contentField;

    [SerializeField]
    private LayoutElement layoutElement;

    [SerializeField]
    private int maxCharacter;

    [SerializeField]
    private RectTransform rectTransform;

    public void SetText(string content,string header="")
    {
        if(header == "")
            headerField.gameObject.SetActive(false);
        else
        {
            headerField.gameObject.SetActive(true);
            headerField.text = header;
        }

        contentField.text = content;

        int headerLenght = headerField.text.Length;
        int contentLenght = contentField.text.Length;

        layoutElement.enabled = (headerLenght > maxCharacter || contentLenght > maxCharacter) ? true : false;

    }

    public void Update()
    {
        Vector2 mousePosition = Input.mousePosition;

        float pivotX = mousePosition.x / Screen.width;
        float pivotY = mousePosition.y / Screen.height;

        rectTransform.pivot = new Vector2(pivotX, pivotY);

        transform.position = mousePosition;
    }
}
