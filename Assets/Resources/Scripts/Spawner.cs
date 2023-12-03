using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timer;
    [SerializeField] private float controlTime;
    public List<Transform> spawnPoints = new List<Transform>();
    private List<Transform> allowedSpawnPoints;

    public List<GameObject> enemysPrefab = new List<GameObject>();
    public List<GameObject> enemyInstace = new List<GameObject>();
    private float elapsedTime = 0.0f;
    private int count;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.canSpawn)
        {
            timer += Time.fixedDeltaTime;
            if (timer > controlTime && count <= 20 + GameManager.instance.currentLevel)
            {
                Spawn();
            }
        }


        if (!GameManager.instance.canSpawn && enemyInstace.Count > 0)
        {
            for (var i = 0; i < enemyInstace.Count; i++)
            {
                Destroy(enemyInstace[i]);
            }
            enemyInstace.Clear();
            count = 0;
        }
        if (enemyInstace.Count <= 0)
        {
            count = 0;
        }
    }

    public void Spawn()
    {
        allowedSpawnPoints = new List<Transform>(spawnPoints);
        elapsedTime += Time.deltaTime;
        int randomPos = 0;
        int randomEnemy = 0;
        if (elapsedTime >= 2)
        {
            randomPos = Random.Range(0, allowedSpawnPoints.Count);
            randomEnemy = Random.Range(0, enemysPrefab.Count);
            Vector2 pos = new Vector2(allowedSpawnPoints[randomPos].position.x, allowedSpawnPoints[randomPos].position.y);
            GameObject instanceEnemy = Instantiate(enemysPrefab[randomEnemy], pos, Quaternion.identity);
            instanceEnemy.GetComponent<Enemy>().listEnemy = enemyInstace;
            enemyInstace.Add(instanceEnemy);
            count++;
            elapsedTime = 0;
        }
        else
        {
            allowedSpawnPoints.Clear();
            allowedSpawnPoints = null;
        }

    }
}