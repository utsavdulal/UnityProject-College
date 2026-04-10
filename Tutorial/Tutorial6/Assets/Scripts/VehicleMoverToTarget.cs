
using UnityEngine;
public class VehicleMoverToTarget : MonoBehaviour
{
private GameObject target;
private const float CLOSE_DISTANCE = 1;
private const float SPEED = 200.0f;
[SerializeField]
private bool flipLookDirection = false;
// An array of gameobjects (gos).
private GameObject[] gos;
// Start is called once before the first execution of Update...
void Start()
{
gos = GameObject.FindGameObjectsWithTag("Pineapple");
target = FindClosest(gos);
}
// Update is called once per frame
void Update()
{
if (target == null)
{
target = FindClosest(gos);
if (target == null)
{
return;
}
}
// Determine the direction to the current target waypoint.
Vector3 direction = target.transform.position - transform.position;
direction.y = 0;
// Calculates the length of the relative position vector
float distance = direction.magnitude;
// Face in the right direction.
if (distance > 0)
{
Quaternion rotation;
if (flipLookDirection)
{
rotation = Quaternion.LookRotation(-direction, Vector3.up);
}
else
{
rotation = Quaternion.LookRotation(direction, Vector3.up);
}
transform.rotation = rotation;
}
// Calculate the normalised direction to the target from a game object.
Vector3 normDirection = direction / distance;
// Move the game object.
transform.position = transform.position + normDirection * SPEED * Time.deltaTime;
}

private GameObject FindClosest(GameObject[] tmpGos)
{
GameObject closest = null;
float distanceSqr = Mathf.Infinity;
foreach (GameObject go in tmpGos)
{
if (go != null)
{
// Get a vector to the gameobject.
Vector3 direction = go.transform.position - transform.position;
// Determine the distance squared of the vector.
float tmpDistanceSqr = direction.sqrMagnitude;
if (tmpDistanceSqr < distanceSqr)
{
closest = go;

distanceSqr = tmpDistanceSqr;

}
}
}
// Could do this:
if (closest != null)
{
closest.transform.localScale = closest.transform.localScale * 2;
}
return closest;
}
}