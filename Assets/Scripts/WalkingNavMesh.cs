﻿using UnityEngine;
using UnityEngine.AI;

public class WalkingNavMesh : MonoBehaviour
{
    public NavMeshAgent nav;
    public Camera cam;
    public Vector3 set;

    // Start is called before the first frame update
    void Start()
    {
        set = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f))
            {
                set = hit.point;
            }
        }
        nav.SetDestination(set);
        if (nav.autoTraverseOffMeshLink)
        {
            nav.CompleteOffMeshLink();
        }
    }
}
