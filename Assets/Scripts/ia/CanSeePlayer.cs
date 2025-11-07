using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CanSeePlayer", menuName = "ScriptableObjects/Actions/CanSeePlayer")] // sirve para crear un objeto en scripts que es una transformación del script a objeto ??
public class CanSeePlayer : Action
{
    public float viewAngle = 60f, viewDistance = 25f;
    public LayerMask obstacleMask;
    public override bool Check(GameObject owner)
    {
        var pref = owner.GetComponent<PlayerRef>();
        if (pref == null || pref.player == null)
        //my name is walter hartwell white i live in 308 negra arroyo lane albuquerque new mexico 87104
        {
            return false;
        }
        Transform eyes = owner.transform;
        Vector3 toTarget = pref.player.transform.position - eyes.position;
        if (toTarget.sqrMagnitude > viewDistance * viewDistance) // Estás dentro de la distancia de visión?
        {
            return false;
        }
        float angle = Vector3.Angle(eyes.forward, toTarget.normalized);
        if (angle > viewAngle * 0.5f) // Estás dentro del ángulo de visión
        {
            return false;
        }
        if (Physics.Raycast(eyes.position, toTarget.normalized, out RaycastHit hit, viewDistance, ~0, QueryTriggerInteraction.Ignore))
        {
            if (hit.collider.transform.IsChildOf(pref.player.transform))
            {
                return true;
            }
            if ((obstacleMask.value & (1 << hit.collider.gameObject.layer)) != 0)
            {
                return false;
            }
            return false;
        }
        return false;
    }
}
