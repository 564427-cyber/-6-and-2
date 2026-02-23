using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class AISpawner : MonoBehaviour
{
    public GameObject aiPrefab;      // AI prefab
    public Transform spawnPoint;     // Where to spawn
    public Transform target;         // Scene object AI should follow
    public float spawnDelay = 5f;
    

    void Start()
    {
        StartCoroutine(SpawnAfterDelay());
    }

    IEnumerator SpawnAfterDelay()
    {
        yield return new WaitForSeconds(spawnDelay);

        // Spawn AI prefab
        GameObject ai = Instantiate(aiPrefab, spawnPoint.position, spawnPoint.rotation);

        // Assign the target at runtime
        AIMovement aiMovement = ai.GetComponent<AIMovement>();
        if (aiMovement != null)
        {
            aiMovement.target = target;
        }

        // Make sure the NavMeshAgent is on the NavMesh
        NavMeshAgent agent = ai.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.Warp(spawnPoint.position);
        }
    }


   
}