using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : MonoBehaviour
{
    private void OnMouseDown()
    {
        TableQuiz.instance.tableChosen(gameObject.name);
    }
}
