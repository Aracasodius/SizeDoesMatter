using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    float currentHealth;
    [SerializeField] [Range(1,2)] int PlayerIndex;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (currentHealth == 0 || currentHealth < 0)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        if (PlayerIndex == 1)
        {
            transform.position = new Vector2(Camera.main.rect.width / 2, 4);
            GetComponent<NewMovement>().enabled = false;
        }
    }
}
