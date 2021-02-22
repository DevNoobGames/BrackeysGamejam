using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BodyPartUnlocker : MonoBehaviour
{
    //public GameObject[] Bodyparts;
    public List<GameObject> BodyParts;
    public List<GameObject> Enemies;
    public ArrowScript arrow;
    public AudioSource UnlockedAudio;
    
    private void Start()
    {
        Enemies.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BodyPart"))
        {
            for (int i=0; i < arrow.Targets.Count; i++)
            {
                if (other.gameObject.name == arrow.Targets[i].gameObject.name)
                {
                    arrow.Targets.RemoveAt(i);
                }
            }
            arrow.hintText();
            Destroy(other.gameObject);
            BodyParts[0].SetActive(true);
            BodyParts[0].transform.position = BodyParts[0].GetComponent<Target>().target.transform.position;
            BodyParts.RemoveAt(0);
            GetComponent<SnakeMover>().IncreaseSpeed();
            GetComponent<PlayerStats>().PartsFound += 1;
            GetComponent<PlayerStats>().UpdatePartsText();
            UnlockedAudio.Play();
            
            foreach (GameObject enemy in Enemies)
            {
                enemy.GetComponent<NavMeshAgent>().speed += 0.5f;
                enemy.GetComponent<EnemyChaser>().speed += 0.5f;
            }
        }
    }
}
