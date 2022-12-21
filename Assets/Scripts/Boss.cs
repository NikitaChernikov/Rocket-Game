using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    [SerializeField] private float cooldown = 5;
    [SerializeField] private GameObject bossMesh;

    [Header("Attack")]
    [SerializeField] private Transform attackSpawnerPoint;
    [SerializeField] private GameObject rocket;
    [SerializeField] private Vector2 range; 

    private float timer = 0;
    private Animator anim;
    private bool walk = true;
    private int health = 2;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (walk)
        {
            transform.position += transform.forward * 20 * Time.deltaTime;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer >= cooldown)
            {
                timer = 0;
                LaunchRocket();
            }
        }
        if (transform.position.x <= 15)
        {
            walk = false;
            anim.SetTrigger("Stop");
        }
    }

    public void LaunchRocket()
    {
        float launchPoint = Random.Range(range.x, range.y);
        Instantiate(rocket, attackSpawnerPoint.position + new Vector3(0, launchPoint, 0), attackSpawnerPoint.rotation);
    }

    public void LoseHp()
    {
        health -= 1;
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        bossMesh.color = Color.red;
        yield return new WaitForSeconds(1f);
        bossMesh.color = Color.white;

    }
}
