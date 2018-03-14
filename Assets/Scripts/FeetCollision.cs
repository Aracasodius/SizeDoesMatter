using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FeetCollision : MonoBehaviour
{
    private BoxCollider2D feet;

    private void Start()
    {
        feet = gameObject.GetComponent<BoxCollider2D>();

        feet.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Player")
        {
            StartCoroutine(ResetJump());
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Player")
        {
            StartCoroutine(ResetJump());
        }
    }

    private IEnumerator ResetJump()
    {
        yield return new WaitForSeconds(0.025f);
        gameObject.GetComponentInParent<NewMovement>().Jumping = false;

    }
}