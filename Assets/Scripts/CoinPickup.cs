using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Triggered");
        if (other.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<ScoreSystem>().PickupAdd(1);
            Destroy(gameObject);
        }
    }

}
