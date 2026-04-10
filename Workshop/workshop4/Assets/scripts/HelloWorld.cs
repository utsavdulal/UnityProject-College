using UnityEngine;
using UnityEditor;

public class HelloWorld : MonoBehaviour
{
    private string info = "Game Over";
    private float aNum = 42;

    private string text1;
    private string text2;
    private string textPos;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello World");
        Debug.Log($"info string contains: {info}");
        float res = 20 + aNum;
        Debug.Log($"res contains: {res}");

        text1 = "Hello World";
        text2 = "info string contains: " + info;
    }

    // Update is called once per frame
    void Update()
    {
        textPos = "My position: " + transform.position.ToString();
    }

    private void OnGUI()
    {
        GUI.color = Color.magenta;
        GUI.Label(new Rect(10, 10, Screen.width, Screen.height), text1);

        GUI.color = Color.red;
        GUI.Label(new Rect(10, 30, Screen.width, Screen.height), text2);
    }

    private void OnDrawGizmos()
    {
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.blue;
        Handles.Label(transform.position + Vector3.up * 2.5f, textPos, style);
    }
}