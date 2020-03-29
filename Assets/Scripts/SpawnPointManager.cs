using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPointManager : MonoBehaviour
{
    public static int deploymentPoints; //static so it can be accessed when an enemy is killed
    public float rate; //the rate at which DP will respawn automatically
    public float timeUntilNextDP;
    public Text dp_text;

    // Start is called before the first frame update
    void Start()
    {
        rate = 1.6f;
        timeUntilNextDP = rate;
        deploymentPoints = 12;
        dp_text.text = "DP: " + deploymentPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeUntilNextDP <= 0)
        {
            deploymentPoints++;
            dp_text.text = "DP: " + deploymentPoints.ToString();
            timeUntilNextDP = rate;
        }
        timeUntilNextDP -= Time.deltaTime;
    }
}
