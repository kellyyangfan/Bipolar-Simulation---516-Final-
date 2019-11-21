using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    //public Transform center;
    public GameObject pathParent;
    public GameObject pathMesh;
    //public GameObject trees;
    public GameObject player;
    public Rigidbody playerRigidBody;

    public Vector3 currentPos;
    public Vector3 prevPos;
    public Vector3 delta;

    GameObject closestCornerForPath;
    public float distToNextCorner;

    public bool shouldChangeCorner;
    public float speed;
    public Vector3 distBW;
    // Start is called before the first frame update

    //private void Awake()
    //{
    //    closestCornerForPath = player.GetComponent<PlayerScript>().closestCornerPrefab;
    //}

    void Start()
    {
        shouldChangeCorner = false;
        playerRigidBody = player.GetComponent<Rigidbody>();

        speed = 1.0f;

        prevPos = Vector3.zero;

        //player.transform.position = pathParent.transform.position;
        //player.transform.forward = pathMesh.transform.forward;
    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentPos = player.GetComponent<Rigidbody>().position;

        delta = currentPos - prevPos;
        print(delta);

        prevPos = currentPos;

        //closestCornerForPath = player.GetComponent<PlayerScript>().closestCornerPrefab;
        //distToNextCorner = player.GetComponent<PlayerScript>().distBetween;
        //pathParent.transform.LookAt(center);
        //}

        //private void OnTriggerStay(Collider other)
        //{
        //while(player.transform.forward == pathMesh.transform.forward)
        {
            pathParent.transform.RotateAround(Vector3.zero, Vector3.down, 10 * Time.deltaTime);

            pathMesh.transform.position += pathMesh.transform.forward * Time.deltaTime * speed;
            //trees.transform.position = pathMesh.transform.position;
            //pathMesh.transform.position = new Vector3(pathMesh.transform.position.x, 0, pathMesh.transform.position.z);

            shouldChangeCorner = ChangeCorner();

            if (shouldChangeCorner)
            {
                print("Here");
                //pathParent.transform.position = Vector3.Slerp(pathParent.transform.position, closestCornerForPath.transform.position, Time.deltaTime * speed);
                //pathParent.transform.localRotation = Quaternion.FromToRotation(pathParent.transform.forward, closestCornerForPath.transform.forward);

                //pathParent.transform.RotateAround(Vector3.zero, Vector3.up, 45.0f);

                //pathParent.transform.position = Vector3.Slerp(pathParent.transform.position, closestCornerForPath.transform.position, Time.deltaTime);
            }
        }

        calcAngle();

    }

    private void OnTriggerEnter(Collider other)
    {
        pathParent.transform.forward = player.transform.forward;
    }

    private void OnTriggerExit(Collider other)
    {
        pathParent.transform.forward = player.transform.forward;

    }

    public bool ChangeCorner()
    {
        if(distToNextCorner < 0.3f)
        {
            print("Changing to next corner!");
            return true;
        }
        return false;
    }

    public Vector3 calcAngle()
    {
        //distBW = pathMesh.transform.position - player.transform.position;
        distBW = distBW.normalized;

        //float dot = Vector3.Dot(distBW, transform.forward);
        //float angle = Mathf.Acos(dot) * Mathf.Rad2Deg;

        print(distBW);

        return distBW;


    }

}
