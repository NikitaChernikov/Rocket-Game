using UnityEngine;

public class LandHelper : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private bool isHelping;

    private void OnTriggerEnter(Collider other)
    {
        isHelping = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (isHelping)
            {
                player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.identity, 0.8f * Time.deltaTime);
                player.transform.position = Vector3.Lerp(player.transform.position, transform.position, 0.3f * Time.deltaTime);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isHelping = false;
    }
}
