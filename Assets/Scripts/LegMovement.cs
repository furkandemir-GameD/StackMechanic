using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class LegMovement : MonoBehaviour
{
    [SerializeField]
    private Transform legLeftTransform;

    [SerializeField]
    private Transform legRightTransform;

    [SerializeField]
    private bool legLeft;

    [SerializeField]
    private bool legRight;

    [SerializeField]
    private StackManager stackManager;

  //  void Start() =>   transform.DOMoveZ(stackManager.body.transform.position.z + 0.2f, 0.2f).onComplete += () => transform.DOMoveZ(stackManager.body.transform.position.z - 0.2f , 0.2f).SetLoops(-1);

    private void Update()
    {
        if (legLeft)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, legLeftTransform.position.z);
            legRight = false;
        }
        if (legRight)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, legRightTransform.position.z);
            legLeft = false;
        }
    }
}
