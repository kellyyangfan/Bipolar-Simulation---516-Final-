using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedMovement : MonoBehaviour
{
    public GameObject player;
    public Rigidbody playerRB;
    public Transform playerForward;
    public GameObject pathMesh;

    public Vector3 velocity;

    Vector3 PrevPos;
    Vector3 NewPos;
    Vector3 ObjVelocity;

    // Start is called before the first frame update
    void Start()
    {
        //playerRB = player.GetComponent<Rigidbody>();
        PrevPos = player.transform.position;
        NewPos = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        //transform.forward = playerForward.transform.forward;

        NewPos = player.transform.position;  // each frame track the new position
        ObjVelocity = (NewPos - PrevPos) / Time.fixedDeltaTime;  // velocity = dist/time

        print("NewPos: " + NewPos);
        print("PrevPos: " + PrevPos);

        if (NewPos != PrevPos)
        {
            //pathMesh.transform.position += pathMesh.transform.forward * Time.deltaTime * ((ObjVelocity.sqrMagnitude)/5);
            print("LOCATION CHANGED");
            StartCoroutine(startDelay());

        }

        PrevPos = NewPos;  // update position for next frame calculation
    }

    IEnumerator startDelay()
    {
        yield return new WaitForEndOfFrame();
        pathMesh.transform.RotateAround(player.transform.position, Vector3.up, 30 * Time.deltaTime);
    }

    // Update is called once per frame
    void onTriggerOverlap()
    {
        //velocity = playerRB.velocity;

        //if (ObjVelocity.ToString() != Vector3.zero.ToString())
        //{
        //    transform.RotateAround(Vector3.zero, Vector3.up, 5 * Time.deltaTime);

        //}

    }
}
