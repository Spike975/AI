using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkingNavMesh : MonoBehaviour
{
    public NavMeshAgent mesh;
    public Camera cam;
    public Vector3 set;

    // Start is called before the first frame update
    void Start()
    {
        set = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Physics.Raycast(cam.ScreenPointToRay(Input.mousePosition));
            //set = ;
            set = cam.ScreenPointToRay(Input.mousePosition).direction + cam.ScreenPointToRay(Input.mousePosition).origin;
        }
        mesh.SetDestination(set);
    }
}
