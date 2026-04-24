using UnityEngine;
using UnityEngine.InputSystem;

public class MouseClicker : MonoBehaviour
{
    public Camera m_Camera;  // Change from [SerializeField] private to public
    private bool mousePress = false;

    void Start()
    {
    }

    void Update()
    {
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            mousePress = true;
        }
    }

    void FixedUpdate()
    {
        if (mousePress)
        {
            mousePress = false;
            Mouse mouse = Mouse.current;
            Vector3 mousePosition = mouse.position.ReadValue();
            Ray ray = m_Camera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Debug.Log("Clicked on: " + hit.collider.gameObject.name);
                GOInteraction aGOI = hit.collider.gameObject.GetComponent<GOInteraction>();
                if (aGOI)
                {
                    aGOI.Interaction = true;
                }
            }
        }
    }
}