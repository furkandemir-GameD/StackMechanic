using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharachterMovement : MonoBehaviour
{
    public float speed;

    [SerializeField]
    private float rotateSpeed;
    private float deltaX;

    private bool touchFlag;
    private void Update()
    {
        if (touchFlag==false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameManager.Instance.CurrentState = GameManager.GameStates.GamePlay;
                touchFlag = true;
            }
        }
        if (GameManager.GameStates.GamePlay == GameManager.Instance.CurrentState)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;
                deltaX = Camera.main.WorldToScreenPoint(mousePos).x;
            }
            if (Input.GetMouseButton(0))
            {
                Vector3 mousePos = Input.mousePosition;
                float buffDelta = Camera.main.WorldToScreenPoint(mousePos).x;
                float delta = deltaX - buffDelta;
                transform.position = new Vector3(transform.position.x + rotateSpeed * Time.deltaTime * delta, transform.position.y, transform.position.z);
            }
        }
    }
}
