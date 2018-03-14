using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private int localIndex;

    void Start()
    {
        localIndex = GetComponent<Health>().PlayerIndex;
    }

    void Update()
    {
        if (localIndex == 1)
        {
            if (Input.GetButtonDown("Player1Melee"))
            {
                Debug.Log("Player 1 attacking melee");
            }

            if(Input.GetButtonDown("Player1Ranged"))
            {
                Debug.Log("Player 1 attacking Ranged");
            }
        }

        if (localIndex == 2)
        {
            if (Input.GetButtonDown("Player2Melee"))
            {
                Debug.Log("Player 2 attacking melee");
            }
            if (Input.GetButtonDown("Player2Ranged"))
            {
                Debug.Log("Player 2 attacking Ranged");
            }
        }
    }
}
