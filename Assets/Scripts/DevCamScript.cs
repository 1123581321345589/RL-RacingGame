using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCamScript : MonoBehaviour
{
    public Vector3 camDist = new Vector3(0f, 23f, -22f);
    private Transform agentInfo;


    // Start is called before the first frame update
    void Start()
    {
        agentInfo = GameObject.Find("Agent").transform;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.transform.position = agentInfo.TransformPoint(camDist);
        this.transform.LookAt(agentInfo);

    }
}
