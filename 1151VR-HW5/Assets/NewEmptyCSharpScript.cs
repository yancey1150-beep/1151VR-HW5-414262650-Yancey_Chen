using UnityEngine;

public class PokeballThrow : MonoBehaviour
{
    public Vector3 throwVelocity = new Vector3(8f, 6f, 0f);
    public GameObject captureEffectPrefab;

    private Rigidbody rb;
    private bool hasThrown = false;
    private bool hasCaught = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    void Update()
    {
        if (!hasThrown && Input.GetKeyDown(KeyCode.Space))
        {
            hasThrown = true;
            rb.useGravity = true;
            rb.linearVelocity = throwVelocity;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!hasCaught && other.CompareTag("Pokemon"))
        {
            hasCaught = true;

            if (captureEffectPrefab != null)
            {
                Instantiate(captureEffectPrefab, other.transform.position, Quaternion.identity);
            }

            other.gameObject.SetActive(false);

            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
