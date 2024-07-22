using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject spawningObject;
    bool canSpawn = true;
    [SerializeField] int spawnCd;
    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            Instantiate(spawningObject, gameObject.transform);
            canSpawn = false;
            StartCoroutine(StartSpawning());
        }
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(spawnCd);
        canSpawn = true;
    }
}
