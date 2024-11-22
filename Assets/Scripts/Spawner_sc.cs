using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner_sc : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNPC());
    }

    [SerializeField] GameObject npcPrefab;
    IEnumerator SpawnNPC()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            Instantiate(
                npcPrefab,
                new Vector3(Random.Range(-20, 20), 1, Random.Range(-20, 20)),
                Quaternion.identity
            );
        }
    }
}
