using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private NavMeshAgent navAgent;

    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Creating a ray for the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            //Checking if the  ray hits the NavMeshAgent
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, NavMesh.AllAreas)) 
            {
                //Move the enemy to the clicked position
                navAgent.SetDestination(hit.point);
            }
        }
    }
}
