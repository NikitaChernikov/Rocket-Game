using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] private float flyingSpeed = 30;
    [SerializeField] private ParticleSystem engineFire;

    private bool isFly = false;
    private bool rotateLeft = false;
    private bool rotateRight = false;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (rotateLeft)
        {
            transform.Rotate(0, 0, 100 * Time.deltaTime);
        }
        if (rotateRight)
        {
            transform.Rotate(0, 0, -100 * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (!isFly)
        {
            engineFire.Stop();
            return;
        }
        engineFire.Play();
        rb.AddForce(transform.up * flyingSpeed, ForceMode.Force);
    }

    public void RotateLeft()
    {
        rotateLeft = true;
    }
    public void RotateRight()
    {
        rotateRight = true;
    }
    public void StopRotate()
    {
        rotateLeft = false;
        rotateRight = false;
    }

    public void LandOff()
    {
        isFly = true;
    }

    public void LandOn()
    {
        isFly = false;
    }
}
