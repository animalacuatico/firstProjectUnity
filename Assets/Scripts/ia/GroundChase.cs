using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GroundChase", menuName = "ScriptableObjects/States/GroundChase")]
public class GroundChase : State
{
    public float repathInterval = 0.1f;
    public float loseSightDelay = 2.0f;
    float repathTimer, lostTimer;
    bool sawThisFrame;
    public override State Run(GameObject owner)
    {
        var agent = owner.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent == null) return this;

        var pref = owner.GetComponent<PlayerRef>();
        if (pref == null || pref.player == null) return this;

        sawThisFrame = false;

        if (action != null && action.Length > 0 && action[0] != null && action[0].Check(owner))
        {
            sawThisFrame = true;
            lostTimer = 0f;
        }
        else
            lostTimer += Time.deltaTime;

        repathTimer += Time.deltaTime;
        if (repathTimer >= repathInterval)
        {
            agent.SetDestination(pref.player.transform.position);
            repathTimer = 0f;
        }

        if (!sawThisFrame && lostTimer >= loseSightDelay)
            return nextState != null && nextState.Length > 0 ? nextState[0] : this;

        return this;
    }
}
