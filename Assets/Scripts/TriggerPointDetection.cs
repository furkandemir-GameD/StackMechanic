using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPointDetection : MonoBehaviour
{
    [SerializeField]
    private StackManager stackManager;

    [SerializeField]
    private CharachterMovement charachterMovement;

    [SerializeField]
    private float ofsset;

    [SerializeField]
    private LayerMask triggerMask;


    [SerializeField]
    private Vector3 castDirection;

    [SerializeField]
    private float radius;

    private bool hasTrigger;

    private void Update()
    {
        RaycastHit hit;
        hasTrigger = Physics.SphereCast(transform.position, radius, castDirection, out hit, ofsset * charachterMovement.speed, triggerMask);
        if (hasTrigger)
        {
            if (hit.collider.gameObject.layer == 8)
            {
                stackManager.CollectedObject(hit.transform.gameObject);
                Debug.Log("Collision With Collactable Object");
            };
            if (hit.collider.gameObject.layer == 9)
            {
                stackManager.RemoveObject(hit.transform.gameObject);
                Debug.Log("Collision With Obstacle");
            }
        }
    }
    void OnDrawGizmos() => Gizmos.DrawSphere(transform.position, radius);
}
