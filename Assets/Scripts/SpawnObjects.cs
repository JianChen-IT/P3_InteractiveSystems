using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    public bool canSpawn = true;
    public GameObject gameObject;
    public float timeBetweenSpawns;

    private List<GameObject> objectList = new List<GameObject>();
    private void SpawnObject()
    {
        int spawnPointX = Random.Range(-40, 40);
        int spawnPointZ = Random.Range(-40, 40);

        Vector3 randomPosition = new Vector3(spawnPointX, 0, spawnPointZ);
        GameObject my_object = Instantiate(gameObject, randomPosition, gameObject.transform.rotation);
        objectList.Add(my_object);
    }
    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnObject();
            if (objectList.Count > 20)
            {
                canSpawn = false;
            }
            yield return new WaitForSeconds(timeBetweenSpawns);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

}
