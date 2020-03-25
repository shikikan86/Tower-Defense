using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 0.01f;

    private Transform target;

    private int waypointIndex;

    public float health;

    public bool death;

    //Raycast
    public float length = 300f;
    public LayerMask mask;

    public Text dp_text;

    //public GameObject SpawnManager;

    void Start()
    {
        
        death = false;
        health = 3.0f;
        speed = 1f;
        waypointIndex = 0;
        target = Waypoints.points[0];  
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            NextWaypoint();
        } 


        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(health);
            RaycastHit hit;
            UnityEngine.Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, length, mask))
            {
                
                if (hit.collider.tag == "enemy1")
                {
                    health -= 1;
                    if(health <= 0)
                    {
                        SpawnPointManager.deploymentPoints++;
                        //int points = SpawnPointManager.deploymentPoints;
                        Destroy(hit.collider.gameObject);
                    }
                }
                //Debug.Log(hit.collider.name);
            }
        }
    }

    //switching to the next Transform in the array
    void NextWaypoint()
    {
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
}
