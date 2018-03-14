using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    public bool allowRespawning;
    [SerializeField] float maxHealth;
    float currentHealth;
    [Range(1, 2)] public int PlayerIndex;
    [SerializeField] [Range(0, 10)] int RespawnTimer;

    void Start()
    {
        healthBar.maxValue = maxHealth;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth == 0 || currentHealth < 0)
        {
            if (allowRespawning)
            { StartCoroutine(Respawn(RespawnTimer)); }
            else
            { Destroy(gameObject); }
        }
    }

    public void Damage(float amount)
    {
        currentHealth -= amount;
    }

    private IEnumerator Respawn(float time)
    {
        switch (PlayerIndex)
        {
            case 1:
                {
                    transform.position = new Vector2(Camera.main.rect.width / 2 + 1, 4);
                    GetComponent<NewMovement>().enabled = false;

                    yield return new WaitForSeconds(time);

                    GetComponent<NewMovement>().enabled = true;
                    GetComponent<Health>().currentHealth = GetComponent<Health>().maxHealth;
                    break;
                }
            case 2:
                {
                    transform.position = new Vector2(Camera.main.ViewportToWorldPoint(new Vector2(Camera.main.rect.width / 2, 0)).x, 3);
                    GetComponent<NewMovement>().enabled = false;

                    yield return new WaitForSeconds(time);

                    GetComponent<NewMovement>().enabled = true;
                    GetComponent<Health>().currentHealth = GetComponent<Health>().maxHealth;
                    break;
                }
            case 0:
                {
                    Debug.LogError("Object trying to respawn, without player index set, or is not a player at all.");
                    break;
                }

        }
    }
}

