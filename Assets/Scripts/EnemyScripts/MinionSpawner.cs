using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] spawnPoints;
    [SerializeField] GameObject _minion;
    DetachChildren _detachChildren;
    // Start is called before the first frame update
    void Start()
    {
        _detachChildren = GameObject.FindAnyObjectByType<DetachChildren>();
        StartCoroutine(SpawnStuff());
    }
    IEnumerator SpawnStuff()
    {
        while (!_detachChildren.isDead)
        {
            yield return new WaitForSeconds(0.8f);
            Instantiate(_minion, spawnPoints[Random.Range(0, 5)].transform);
        }
    }
}
