using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyChaser : MonoBehaviour
{
    private NavMeshAgent agent;
    public GameObject Target;
    public GameObject PlayerPart1;
    public GameObject LineOfSight;

    public bool CanLosePlayer;
    public Vector3 StartPos;

    public float speed;//NORMALLY = 5!!
    public float StandardSpeed;
    public NavMeshObstacle obstacle;
    public float stoppingDistance;
    public float lostPlayerDistance;
    public bool isAttacking;

    public Animation Anim;

    void Start()
    {
        StartPos = transform.position;
        Target = GameObject.FindGameObjectWithTag("SnakeHead");

        stoppingDistance = Random.Range(2.2f, 2.5f);
        agent = GetComponent<NavMeshAgent>();
        agent.avoidancePriority = Random.Range(0, 100);
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Target)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) > stoppingDistance) //Stopping distance was 2 before
            {
                Anim.Play("Scene");
                agent.speed = speed;
                obstacle.enabled = false;
                agent.enabled = true;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                if (isAttacking)
                {
                    StopAllCoroutines();
                    isAttacking = false;
                }
            }
            else
            {
                Anim.Stop("Scene");
                agent.speed = 0;
                obstacle.enabled = true;
                agent.enabled = false;
                GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;

                if (!isAttacking)
                {
                    isAttacking = true;
                    StartCoroutine(AttackPlayer());
                }
            }
            if (agent.isActiveAndEnabled)
            {
                agent.SetDestination(Target.transform.position);
            }
            Vector3 targetPostition = new Vector3(Target.transform.position.x,
                                    this.transform.position.y,
                                    Target.transform.position.z);
            this.transform.LookAt(targetPostition);

            if (CanLosePlayer && Vector3.Distance(transform.position, Target.transform.position) > lostPlayerDistance)
            {
                LineOfSight.SetActive(true);
                agent.SetDestination(StartPos);
                this.enabled = false;
            }
        }
    }

    IEnumerator AttackPlayer()
    {
        Anim.Play("Hit");
        yield return new WaitForSeconds(0.3f);
        if (Target)
        {
            if (Vector3.Distance(transform.position, Target.transform.position) <= stoppingDistance)
            {
                if (Target.CompareTag("SnakeHead"))
                {
                    if (PlayerPart1.GetComponent<PlayerStats>().Attackable == true)
                    {
                        PlayerPart1.GetComponent<PlayerStats>().Attackable = false;
                        PlayerPart1.GetComponent<PlayerStats>().Health -= 1;
                        PlayerPart1.GetComponent<PlayerStats>().UpdateHearts();
                        StartCoroutine(PlayerPart1.GetComponent<PlayerStats>().Injured());
                        Debug.Log("attacked");
                    }
                }
            }
        }
        isAttacking = false;
    }
}
