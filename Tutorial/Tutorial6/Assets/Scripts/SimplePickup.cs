
using UnityEngine;
public class SimplePickup : MonoBehaviour
{
[SerializeField]
private GameObject explosionEffect;
// Start is called before the first frame update
void Start()
{
}
// Update is called once per frame
void Update()
{
transform.Rotate(0, 50 * Time.deltaTime, 0);
}
private void OnTriggerEnter(Collider other)
{
if (other.gameObject.CompareTag("Player") ||
other.gameObject.CompareTag("VirtualCharacter"))
{
Debug.Log("Pineapple Hit!!");
// Instantiate explosion at the point of impact
GameObject clone;
clone = Instantiate(explosionEffect, transform.position, Quaternion.identity);
clone.transform.localScale = Vector3.one * 2;
Destroy(clone, 10);
Destroy(gameObject);
}
}
}