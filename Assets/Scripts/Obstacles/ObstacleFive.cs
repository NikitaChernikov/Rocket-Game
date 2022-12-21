using UnityEngine;

public class ObstacleFive : MonoBehaviour
{
    [SerializeField] private Rigidbody cover;
    [SerializeField] GameObject particles;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            cover.AddForce(new Vector3(-1, 1, 0) * Random.Range(8, 15), ForceMode.Impulse);
            particles.SetActive(false);
        }
    }
}
