using UnityEngine;

public class ObstacleFour : MonoBehaviour
{
    [SerializeField] float limit = 30f;

    private void Update()
    {
        float angle = limit * Mathf.Sin(Time.time * 1.5f); 
        transform.localRotation = Quaternion.Euler(angle, 0, 0);
    }
}
