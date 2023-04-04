using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FloorManager : MonoBehaviour
{
    public GameObject Enemies;
    public NavMeshSurface nm;
    Helicopter helicopter;
    bool workOnce = false;
    // Start is called before the first frame update
    private void Awake()
    {
        helicopter = FindObjectOfType<Helicopter>();
    }
    void Start()
    {
        nm.BuildNavMesh();
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies() {
        yield return new WaitForSeconds(2f);
        Enemies.SetActive(true);
    }
    private void Update()
    {
        CheckStepDown();
    }
    public void CheckStepDown()
    {
        if (workOnce)
            return;
      
        if (Enemies.transform.childCount==0)
        {
            workOnce = true;
            helicopter.StepDown();
        }
    }
}
