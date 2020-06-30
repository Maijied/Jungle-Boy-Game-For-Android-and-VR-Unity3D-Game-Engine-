using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Worldinteractioncamera : MonoBehaviour
{

    private bool walking = false;
    private Vector3 spawnPoint;
    public GameObject Ground;


    NavMeshAgent playerAgent;
    // Use this for initialization
    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        spawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
            //autoRunning();
        }
    }

    void autoRunning()
    {
        if (walking)
        {
            transform.position = transform.position + Camera.main.transform.forward * .5f * Time.deltaTime;
        }

        if (transform.position.y < -10f)
        {
            transform.position = spawnPoint;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.name.Contains("Ground"))
            {
                walking = false;
            }
            else
            {
                walking = true;
            }
        }
    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            playerAgent.destination = interactionInfo.point;
            playerAgent.stoppingDistance = 5f;
        }
    }
}
