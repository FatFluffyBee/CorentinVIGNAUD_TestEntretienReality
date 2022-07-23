using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    static public SpawnerBehavior instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject ennemiPrefab;
    public float timeToSpawnMin, timeToSpawnMax;

    private float timeToSpawn, count;

    private List<GameObject> ennemies = new List<GameObject>();
    private List<Transform> spawn = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            spawn.Add(transform.GetChild(i));
        for(int i = 0; i < 20; i++)
        {
            GameObject instance = Instantiate(ennemiPrefab, transform.position, Quaternion.identity);
            ennemies.Add(instance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;

        if(timeToSpawn < count)
        {
            SpawnEnnemies();
        }
    }

    public void SpawnEnnemies()
    {
        foreach(Transform e in spawn)
        {
            if(ennemies.Count >= 1)
            {
                ennemies[0].transform.position = e.position;
                ennemies[0].GetComponent<EnnemiBehavior>().active = true;
                ennemies.RemoveAt(0);
            }

            timeToSpawn = Random.Range(timeToSpawnMin, timeToSpawnMax);
            count = 0;
        }
    }

    public void DeleteEnnemy(GameObject e)
    {
        ennemies.Add(e);
        e.transform.position = transform.position;
        e.GetComponent<EnnemiBehavior>().active = false;
    }
}
