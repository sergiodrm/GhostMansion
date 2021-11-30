using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugText : MonoBehaviour
{
    public Text m_text;

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        m_text.text = "Mouse position on screen: " + mousePosition + "\n" +
            "Mouse position on world: " + Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
