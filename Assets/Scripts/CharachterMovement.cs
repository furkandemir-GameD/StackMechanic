using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharachterMovement : MonoBehaviour
{
    public float speed;
    private float deltaX;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            deltaX = Input.mousePosition.x;
        }
        if (Input.GetMouseButton(0))
        {
            deltaX = Input.mousePosition.x - deltaX;
            deltaX /= 10;
            transform.position = new Vector3(transform.position.x + deltaX*Time.deltaTime, transform.position.y, transform.position.z + speed * Time.deltaTime);
        }
    }
}
