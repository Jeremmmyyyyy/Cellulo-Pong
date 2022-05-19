using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rBody : MonoBehaviour
{
    private Rigidbody rigidBody;
    private GameObject ball;
    private bool isWallCollided;
    // Start is called before the first frame update
    void Start()
    {
        isWallCollided = false;
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWallCollided)
        {
            rigidBody.detectCollisions = false;
        }

    }
    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("In OnTriggerEnter");
        if (col.transform.parent.gameObject.CompareTag("LWall") || col.transform.parent.gameObject.CompareTag("RWall"))
        {
            Debug.Log("Touched wall");
            isWallCollided = true;
        }
    }
}
