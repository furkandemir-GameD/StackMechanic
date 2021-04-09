using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackManager : MonoBehaviour
{
   public Transform stackableObjectTransform;
   public GameObject body;

   [SerializeField]
   private CharachterMovement charachterMovement;

   [SerializeField]
   private LayerMask collisionBeforeMask; 

   [SerializeField]
   private BoxCollider bodyCollider;

   [SerializeField]
   private GameObject stackableObject;

   [SerializeField]
   private Transform stackParent;

   private float stackObjectHeight;
   private int fieldScale;

   void Awake() => stackObjectHeight = stackableObjectTransform.GetChild(0).localScale.y * 2 * stackableObjectTransform.localScale.y;

   public void CollectedObject(GameObject go)
   {
        go.SetActive(false);

        body.transform.position = new Vector3(body.transform.position.x, body.transform.position.y + stackObjectHeight , body.transform.position.z);

        bodyCollider.size = new Vector3(bodyCollider.size.x,bodyCollider.size.y + stackObjectHeight , bodyCollider.size.z); // problemli
        bodyCollider.center = new Vector3(bodyCollider.center.x, bodyCollider.center.y - stackObjectHeight/2, bodyCollider.center.z);

        go.layer = collisionBeforeMask.value;
        body.GetComponent<Rigidbody>().useGravity = false;

        GameObject instantiedObject = Instantiate(stackableObject);
        instantiedObject.transform.parent = stackParent;

        instantiedObject.transform.position = new Vector3(stackParent.transform.position.x,
           + stackParent.GetChild(stackParent.childCount - 1).transform.position.y + stackParent.transform.position.y + stackObjectHeight * stackParent.childCount,
              stackParent.transform.position.z);

        stackParent.transform.position = new Vector3(stackParent.transform.position.x, stackParent.transform.position.y - stackObjectHeight , stackParent.transform.position.z);
   }
   public void RemoveObject(GameObject go)
   {
        float removeTime =  (go.transform.localScale.z / charachterMovement.speed) / 2;

        Run.After(removeTime, async () =>
        {
            fieldScale = go.GetComponent<ObstacleProperties>().fieldScaleY;
            for (int i = 0; i < fieldScale; i++)
            {
                stackParent.GetChild(0).parent = null;
            }
           
        });
       
        float delayTime = go.transform.localScale.z / charachterMovement.speed;
        Debug.Log(delayTime);
        Run.After(delayTime, async () =>
        {
            body.GetComponent<Rigidbody>().useGravity = true;
            bodyCollider.size = new Vector3(bodyCollider.size.x, bodyCollider.size.y - stackObjectHeight * fieldScale * 2 , bodyCollider.size.z);
        });

        go.layer = collisionBeforeMask.value;
    }
}
