using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public GameObject target;
    public bool View3D;
    public GameObject HintText;

    public List<GameObject> Targets;

    private void Start()
    {
        //target = FindClosestEnemy();
        //InvokeRepeating("FindNewClosest", 2, 2);
    }

    void Update()
    {
        /*if (target)
        {
            if (View3D)
            {
                transform.LookAt(target.transform.position);
            }
            else
            {
                Vector3 targetPostition = new Vector3(target.transform.position.x,
                                        this.transform.position.y,
                                        target.transform.position.z);
                this.transform.LookAt(targetPostition);
            }
        }
        else
        {
            target = FindClosestEnemy();
            if (!target)
            {
                Destroy(gameObject);
            }
        }*/

        if (Targets.Count > 0)
        {
            transform.LookAt(Targets[0].transform.position);
        }
    }

    public void hintText()
    {
        if (Targets.Count > 0)
        {
            if (Targets[0].name == "CentiPart9")
            {
                HintText.SetActive(true);
            }
            else
            {
                HintText.SetActive(false);
            }
        }
    }

    public void FindNewClosest()
    {
        target = FindClosestEnemy();
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("BodyPart");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }

}
