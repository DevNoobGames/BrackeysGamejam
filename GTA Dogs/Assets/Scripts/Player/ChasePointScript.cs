using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePointScript : MonoBehaviour
{
    public GameObject target;

    private void Start()
    {
        target = transform.parent.gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 targetPostition = new Vector3(target.transform.position.x,
                                this.transform.position.y,
                                target.transform.position.z);
        this.transform.LookAt(targetPostition);
    }
}
