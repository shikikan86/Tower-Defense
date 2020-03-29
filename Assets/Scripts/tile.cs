using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    private Renderer rend;
    public GameObject turret;
    public Color hovercolor;
    public Color normalcolor;
    public Color activecolor;
    public bool active;

    void Start()
    {
        active = false;
        rend = GetComponent<Renderer>();
    }

    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("No can do");
            return;
        }

        else
        {
            if (SpawnPointManager.deploymentPoints >= 18)
            {
                rend.material.color = activecolor;
                active = true;
                SpawnPointManager.deploymentPoints -= 18;
            }
            else
            {
                rend.material.color = normalcolor;
            }
        }

    }

    void OnMouseEnter()
    {
        if (!active)
        {
            rend.material.color = hovercolor;
        }
        
    }

    void OnMouseExit()
    {
        if (!active)
        {
            rend.material.color = normalcolor;
        }
        
    }
}
