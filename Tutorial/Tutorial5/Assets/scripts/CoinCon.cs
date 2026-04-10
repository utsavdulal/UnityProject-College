using UnityEngine;
public class CoinCon : MonoBehaviour
{
[SerializeField]
private float rotationSpeed = 90f; // Degrees per second.
[SerializeField]
private GameObject explosionEffect;
void Update()
{
// Spin the object around its Y-axis
transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
}
void OnTriggerEnter(Collider other)
{
Debug.Log(other.gameObject);
if (other.CompareTag("Player"))
{
GameObject clone;
clone = Instantiate(explosionEffect, transform.position, Quaternion.identity);
clone.transform.localScale = Vector3.one * 2;
Destroy(gameObject);
Destroy(clone, 10); // destroys the fx in x seconds.
}
}
}