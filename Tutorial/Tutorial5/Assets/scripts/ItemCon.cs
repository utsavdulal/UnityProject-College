using UnityEngine;
public class ItemCon : MonoBehaviour
{
[SerializeField]
private GameObject explosionEffect;
// Start is called once before the first
// execution of Update after the MonoBehaviour is created
void Start()
{
}
// Update is called once per frame
void Update()
{
}
void OnCollisionEnter(Collision collision)
{
// Check if the colliding object has the "Projectile" tag.
if (collision.gameObject.CompareTag("Projectile"))
{
// Instantiate explosion at the point of impact
ContactPoint contact = collision.contacts[0];
GameObject clone;
clone = Instantiate(explosionEffect, contact.point, Quaternion.identity);
clone.transform.localScale = Vector3.one * 2;
Destroy(gameObject); // destroys this object.
Destroy(collision.gameObject); // destroys the projectile.
Destroy(clone, 10); // destroys the fx in x seconds.
}
}
}