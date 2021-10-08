using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Sirenix.OdinInspector;

[ExecuteAlways]
public class TableNumberUpdater : SerializedMonoBehaviour
{
    [OnValueChanged("UpdateTableNumbers"), ReadOnly] public string objectName;

    public TextMeshPro text;
    [OnValueChanged("UpdateTableNumbers")]public bool tableNumbersActive = false;

    public void Start()
    {
        UpdateTableNumbers();
    }

    public void UpdateTableNumbers()
    {
        text.gameObject.SetActive(tableNumbersActive);
        objectName = gameObject.name;
        text.text = objectName;
    }
}
