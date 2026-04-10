using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    private string message = "";  // stores the message to display

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Sphere"))
        {
            message = "The asteroid has hit the earth!";
        }
    }

    private void OnGUI()
    {
        GUI.color = Color.red;
        GUI.Label(new Rect(10, 10, Screen.width, Screen.height), message);
    }
}