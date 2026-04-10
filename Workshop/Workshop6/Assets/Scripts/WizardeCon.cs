using UnityEngine;
using System.Collections;

public class WizardCon : MonoBehaviour
{
    // A reference to the player GameObject.
    private GameObject player;

    // The speed of the character.
    [SerializeField]
    private float moveSpeed = 1.0f;

    // Adjustable charge distance (instead of hard-coded 7).
    [SerializeField]
    private float chargeDistance = 10f;

    // A reference to the animator.
    private Animator anim;
    // Store the current AnimatorStateInfo.
    AnimatorStateInfo currentStateInfo;

    // Hashes to animator parameters.
    private int speedHash = Animator.StringToHash("Speed");
    private int dyingHash = Animator.StringToHash("IsDead");

    // Respawn wait time changed to 5 seconds.
    private float WaitTime = 5;
    private float WaitTimer = 0;

    // Charging control
    private bool isCharging = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        currentStateInfo = anim.GetCurrentAnimatorStateInfo(0);

        // Handle death state and respawn.
        if (currentStateInfo.IsName("Dead"))
        {
            WaitTimer += Time.deltaTime;
            if (WaitTimer > WaitTime)
            {
                anim.SetBool("IsDead", false);
                WaitTimer = 0;
            }
            return; // Skip movement while dead.
        }

        // Check distance to player.
        if (!isCharging && Vector3.Distance(transform.position, player.transform.position) < chargeDistance)
        {
            StartCoroutine(ChargePlayer());
        }
        else if (!isCharging)
        {
            anim.SetFloat(speedHash, 0);
        }
    }

    IEnumerator ChargePlayer()
    {
        isCharging = true;
        anim.SetFloat(speedHash, 0.7f);

        float timer = 0f;
        while (timer < 2f) // Charge for 2 seconds
        {
            Vector3 tmp = player.transform.position;
            tmp.y = this.transform.position.y;
            transform.LookAt(tmp, Vector3.up);

            currentStateInfo = anim.GetCurrentAnimatorStateInfo(0);
            if (currentStateInfo.IsName("Walk"))
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }

            timer += Time.deltaTime;
            yield return null;
        }

        anim.SetFloat(speedHash, 0);
        isCharging = false;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter - " + other.gameObject.name);
        if (other.gameObject.tag.Contains("Projectile"))
        {
            anim.SetBool(dyingHash, true);
            Destroy(other.gameObject);
        }
    }
}
