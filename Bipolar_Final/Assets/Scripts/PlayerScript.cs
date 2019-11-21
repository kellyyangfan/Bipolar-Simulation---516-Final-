using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Transform[] corners;
    public float distBetween;

    public Transform closestCorner;
    public GameObject closestCornerPrefab;

    Color lineColor;

    // Start is called before the first frame update
    void Start()
    {
        closestCorner = null;
        lineColor = new Color(50, 30, 25);
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Transform cornerPos in corners)
        {
            closestCorner = GetClosestEdge(corners);
        }
        closestCornerPrefab = closestCorner.gameObject;
        Debug.DrawLine(transform.position, closestCorner.transform.position, Color.red);

        
    }

    Transform GetClosestEdge(Transform[] edges)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
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
