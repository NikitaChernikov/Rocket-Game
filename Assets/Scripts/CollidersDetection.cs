using UnityEngine;
using UnityEngine.UI;

public class CollidersDetection : MonoBehaviour
{
    [SerializeField] private Text textField;
    [SerializeField] private GameObject explosionParticle;
    [SerializeField] private GameObject shattle;
    [SerializeField] private ParticleSystem landingPointer;
    [SerializeField] private MoveCamera moveCamera;

    private float timer = 0;
    private RocketMovement rocketMovement;

    private void Awake()
    {
        rocketMovement = GetComponent<RocketMovement>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Danger"))
        {
            rocketMovement.enabled = false;
            shattle.SetActive(false);
            explosionParticle.SetActive(true);
            textField.text = "You lose";
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Finish"))
        {
            timer = 0;
            landingPointer.Stop();
        }
        if (collision.transform.CompareTag("MoveCamera"))
        {
            moveCamera.MoveCameraPosition(true);
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Finish"))
        {
            timer += Time.deltaTime;
            if (timer > 3)
            {
                rocketMovement.enabled = false;
                textField.text = "You win";
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        landingPointer.Play();
        if (collision.transform.CompareTag("MoveCamera"))
        {
            moveCamera.MoveCameraPosition(false);
        }
    }
}
