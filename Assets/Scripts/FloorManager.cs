using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FloorManager : MonoBehaviour
{
    public GameObject Enemies;
    public NavMeshSurface nm;
    // Start is called before the first frame update
    void Start()
    {
        nm.BuildNavMesh();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        yield return new WaitForSeconds(2f);
        Enemies.SetActive(true);
    }
}
