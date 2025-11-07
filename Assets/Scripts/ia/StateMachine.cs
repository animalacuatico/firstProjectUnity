using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State startingState;
    State current;
    private void Awake()
    {
        current = startingState;
    }
    private void Update()
    {
        if (current == null)
        {
            return;
        }
        State next = current.Run(gameObject);
        if (next != current)
        {
            current = next;
        }
    }
}

