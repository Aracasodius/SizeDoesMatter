using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchEvent : MonoBehaviour
{
    public enum EventType { Damage, Trampoline, Moveable }
    public EventType eventType;
    private bool attachState;

    [SerializeField] private float damageAmount;
    [SerializeField] private float jumpMultiplier;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            switch (eventType)
            {
                case EventType.Damage:
                    {

                        collision.gameObject.GetComponent<Health>().Damage(damageAmount);
                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);

                        break;
                    }
                case EventType.Trampoline:
                    {

                        collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);
                        break;
                    }
                case EventType.Moveable:
                    {
                        attachState = false;
                        break;
                    }
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        switch(eventType)
        {
            case EventType.Moveable:
                {
                    if (Input.GetButtonDown("Attach"))
                    {
                        attachState = !attachState;
                        Attach(attachState, collision.gameObject);
                    } 
                    break;
                }
        }
    }

    void Attach(bool state, GameObject player)
    {
        if (state)
        {
            player.GetComponent<NewMovement>().enabled = false;
            player.transform.parent = transform;
        }
        else
        {
            player.transform.parent = null;
            player.GetComponent<NewMovement>().enabled = true;
        }
    }

    private void Update()
    {
        if (attachState)
        {
            transform.position += new Vector3(Input.GetAxis("Player2Horizontal") / 8f, 0, 0);
        }
        else { }
    }
}
