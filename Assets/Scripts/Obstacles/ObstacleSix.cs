using UnityEngine;

public class ObstacleSix : MonoBehaviour
{
    [SerializeField] private float obstacleSpeed = 30;
    private Rigidbody rb;
    protected bool isFlying = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        if (isFlying) return;
        RaycastHit player;
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out player, 100))
        {
            if (player.transform.CompareTag("Player"))
            {
                isFlying = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isFlying)
        {
            rb.AddForce(transform.forward * obstacleSpeed, ForceMode.Force);
            Destroy(gameObject, 3f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
