using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    public static DebugText s_instance {get; private set;}
    public Text m_text;
    public string m_textToPrint;

    private void Awake()
    {
        s_instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        m_text.text = "Mouse position on screen: " + mousePosition + "\n" +
            "Mouse position on world: " + Camera.main.ScreenToWorldPoint(mousePosition) + "\n" +
            m_textToPrint;
    }
}
