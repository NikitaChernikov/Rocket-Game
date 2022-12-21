using UnityEngine;
using System.Collections;

public class ObstacleThree : MonoBehaviour
{
    [SerializeField] private GameObject[] lightnings;
    [SerializeField] private GameObject[] greenLantern;
    [SerializeField] private GameObject[] redLantern;
    [SerializeField] private float cooldown = 2;

    private float timer = 2;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= cooldown)
        {
            timer = 0;
            StartCoroutine(ShootLightning());
        }
    }

    IEnumerator ShootLightning()
    {
        for (int i = 0; i < greenLantern.Length; i++)
        {
            greenLantern[i].SetActive(false);
            redLantern[i].SetActive(true);
        }
        foreach (GameObject lightning in lightnings)
        {
            lightning.SetActive(true);
        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i < greenLantern.Length; i++)
        {
            greenLantern[i].SetActive(true);
            redLantern[i].SetActive(false);
        }
        foreach (GameObject lightning in lightnings)
        {
            lightning.SetActive(false);
        }
    }

}
