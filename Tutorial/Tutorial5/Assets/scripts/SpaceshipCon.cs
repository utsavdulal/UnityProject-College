using UnityEngine;
public class SpaceshipCon : MonoBehaviour
{
[SerializeField]
private float moveSpeed = 20f;
[SerializeField]
private float turnSpeed = 100f;
// Start is called once before the first
// execution of Update after the MonoBehaviour is created
void Start()
{
}
// Update is called once per frame
void Update()
{
// Get input for forward/backward movement.
float moveInput = Input.GetAxis("Vertical"); // W/S or Up/Down Arrow.
// Get input for turning left/right.
float turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right Arrow.
// Move the spaceship forward/backward.
transform.Translate(Vector3.forward * moveInput * moveSpeed * Time.deltaTime);
// Rotate the spaceship left/right.
transform.Rotate(Vector3.up, turnInput * turnSpeed * Time.deltaTime);
}
}