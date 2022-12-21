using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform[] positions;
    [SerializeField] RocketMovement rocketMovement;

    private bool isMoving;
    private int counter = 0;

    private void Update()
    {
        if (isMoving)
        {
            transform.position = Vector3.Lerp(transform.position, positions[counter].position, 0.01f);
            transform.rotation = Quaternion.Lerp(transform.rotation, positions[counter].rotation, 0.01f);
        }
    }

    public void MoveCameraPosition(bool moving)
    {
        isMoving = moving;
        StartCoroutine(BlockRocketMovement());
        counter++;
    }

    IEnumerator BlockRocketMovement()
    {
        rocketMovement.enabled = false;
        yield return new WaitForSeconds(2f);
        rocketMovement.enabled = true;
    }
}
