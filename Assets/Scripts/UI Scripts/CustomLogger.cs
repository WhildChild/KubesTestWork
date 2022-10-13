using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CustomLogger : MonoBehaviour
{
    [SerializeField]
    private TMP_Text messageField;

    public void WriteMessage(string message) 
    {
        messageField.text = message;
    }
}
