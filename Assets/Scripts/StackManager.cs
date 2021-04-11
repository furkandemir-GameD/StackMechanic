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

   [SerializeField]
   private Transform stackParentLeft;

   [SerializeField]
   private Transform stackParentRight;

   [SerializeField]
   private CameraFollow cameraFollow;

   private float stackObjectHeight;
   private int fieldScale;

   void Awake() => stackObjectHeight = stackableObjectTransform.GetChild(0).localScale.y * 2 * stackableObjectTransform.localScale.y;

   public void CollectedObject(GameObject go)
   {
        go.SetActive(false);
        cameraFollow.OffsetCalculator(cameraFollow.cameraDistance,cameraFollow.axisDampingZ, cameraFollow.axisRotateY);

        body.transform.position = new Vector3(body.transform.position.x, body.transform.position.y + stackObjectHeight , body.transform.position.z);

        bodyCollider.size = new Vector3(bodyCollider.size.x,bodyCollider.size.y + stackObjectHeight , bodyCollider.size.z); // problemli
        bodyCollider.center = new Vector3(bodyCollider.center.x, bodyCollider.center.y - stackObjectHeight/2, bodyCollider.center.z);

        go.layer = collisionBeforeMask.value;
        body.GetComponent<Rigidbody>().useGravity = false;

        GameObject instantiedObject = Instantiate(stackableObject);
        /*instantiedObject.transform.parent = stackParent;

        instantiedObject.transform.position = new Vector3(stackParent.transform.position.x,
           + stackParent.GetChild(stackParent.childCount - 1).transform.position.y + stackParent.transform.position.y + stackObjectHeight * stackParent.childCount,
              stackParent.transform.position.z);

        stackParent.transform.position = new Vector3(stackParent.transform.position.x, stackParent.transform.position.y - stackObjectHeight , stackParent.transform.position.z);*/
        GameObject leftLeg = instantiedObject.transform.GetChild(0).gameObject;
        GameObject rightLeg = instantiedObject.transform.GetChild(1).gameObject;
        LegCalculate(leftLeg, rightLeg);
       
   }
   public void RemoveObject(GameObject go)
   {
        cameraFollow.OffsetCalculator(-cameraFollow.cameraDistance*fieldScale, -cameraFollow.axisDampingZ * fieldScale, -cameraFollow.axisRotateY * fieldScale);

        float removeTime =  (go.transform.localScale.z / charachterMovement.speed) / 2;

        Run.After(removeTime, () =>
        {
            fieldScale = go.GetComponent<ObstacleProperties>().fieldScaleY;
            for (int i = 0; i < fieldScale; i++)
            {
                stackParentLeft.GetChild(0).parent = null;
                stackParentRight.GetChild(0).parent = null;
            } 
        });
       
        float delayTime = go.transform.localScale.z / charachterMovement.speed;
        Debug.Log(delayTime);
        Run.After(delayTime,  () =>
        {
            body.GetComponent<Rigidbody>().useGravity = true;
            bodyCollider.size = new Vector3(bodyCollider.size.x, bodyCollider.size.y - stackObjectHeight * fieldScale , bodyCollider.size.z);
            bodyCollider.center = new Vector3(bodyCollider.center.x, bodyCollider.center.y + stackObjectHeight , bodyCollider.center.z);
        });

        go.layer = collisionBeforeMask.value;
    }

    private void LegCalculate(GameObject leftLeg,GameObject rightLeg)
    {  
        rightLeg.transform.parent = stackParentRight;
        leftLeg.transform.parent = stackParentLeft;



        leftLeg.transform.position = new Vector3(stackParentLeft.position.x,
         +stackParentRight.GetChild(stackParentLeft.childCount - 1).position.y + stackParentLeft.position.y + stackObjectHeight *
         stackParentLeft.childCount,
            stackParentLeft.position.z);

        rightLeg.transform.position = new Vector3(stackParentRight.position.x,
          +stackParentRight.GetChild(stackParentRight.childCount - 1).position.y + stackParentRight.position.y + stackObjectHeight *
          stackParentRight.childCount,
             stackParentRight.position.z);


        stackParentLeft.position = new Vector3(stackParentLeft.position.x, stackParentLeft.position.y - stackObjectHeight,
          stackParentLeft.position.z);



        stackParentRight.position = new Vector3(stackParentRight.position.x, stackParentRight.position.y - stackObjectHeight,
            stackParentRight.position.z);


        stackParent.position = new Vector3(stackParent.position.x, stackParent.position.y - stackObjectHeight,
            stackParent.position.z);
    }
}
