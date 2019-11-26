using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGizmo : MonoBehaviour
{
    public Transform corner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        foreach(Transform child in corner)
        {
            Gizmos.DrawSphere(child.position, 0.1f);
        }

    }
}
