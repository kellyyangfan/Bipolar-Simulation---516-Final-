using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptForest : MonoBehaviour
{
    public Transform[] corners;
    public float distBetween;

    public Transform closestCorner;
    public GameObject closestCornerPrefab;

    public Transform pathParent;

    public GameObject nextCorner;

    public float rotSpeed;

    Color lineColor;

    // Start is called before the first frame update
    void Start()
    {
        closestCorner = null;
        closestCornerPrefab = null;
        lineColor = new Color(50, 30, 25);

        rotSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Transform cornerPos in corners)
        {
            closestCorner = GetClosestEdge(corners);
        }
        closestCornerPrefab = closestCorner.gameObject;
        Debug.DrawLine(transform.position, closestCorner.transform.position, Color.red);

        if (closestCornerPrefab.transform.name == "1")
        {
            nextCorner = GameObject.Find("2");
            pathParent.transform.rotation = Quaternion.Lerp(pathParent.transform.rotation, nextCorner.transform.rotation, rotSpeed * Time.deltaTime);
            pathParent.transform.position = Vector3.Lerp(pathParent.transform.position, closestCornerPrefab.transform.position, Time.deltaTime);
        }
        else if (closestCornerPrefab.transform.name == "2")
        {
            nextCorner = GameObject.Find("3");
            pathParent.transform.rotation = Quaternion.Lerp(pathParent.transform.rotation, nextCorner.transform.rotation, rotSpeed * Time.deltaTime);
            pathParent.transform.position = Vector3.Lerp(pathParent.transform.position, closestCornerPrefab.transform.position, Time.deltaTime);
        }
        else if (closestCornerPrefab.transform.name == "3")
        {
            nextCorner = GameObject.Find("4");
            pathParent.transform.rotation = Quaternion.Lerp(pathParent.transform.rotation, nextCorner.transform.rotation, rotSpeed * Time.deltaTime);
            pathParent.transform.position = Vector3.Lerp(pathParent.transform.position, closestCornerPrefab.transform.position, Time.deltaTime);
        }
        else if (closestCornerPrefab.transform.name == "4")
        {
            nextCorner = GameObject.Find("1");
            pathParent.transform.rotation = Quaternion.Lerp(pathParent.transform.rotation, nextCorner.transform.rotation, rotSpeed * Time.deltaTime);
            pathParent.transform.position = Vector3.Lerp(pathParent.transform.position, closestCornerPrefab.transform.position, Time.deltaTime);
        }


    }

    Transform GetClosestEdge(Transform[] edges)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = 0.5f;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in edges)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                //print(closestDistanceSqr);
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }
}
