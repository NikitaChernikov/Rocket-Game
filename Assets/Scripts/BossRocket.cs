using UnityEngine;

public class BossRocket : ObstacleSix
{
    private void Start()
    {
        isFlying = true;
    }

    protected override void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Danger"))
        {
            Destroy(gameObject);
        }
        if (collision.transform.CompareTag("Boss"))
        {
            collision.transform.GetComponent<Boss>().LoseHp();
            Destroy(gameObject);
        }
    }
}
