using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Serializable]
    public class ObjectTime
    {
        public float time;
        public Vector3 direct;
        public List<GameObject> sleeping;
    }

    public GameObject spawnObj;
    public Ship spamTarget;
    public float delay;

    public void Start()
    {
        StartSpawn();
    }

    public void OnDisable()
    {
        StopSpawn();
    }


    public void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    public void StopSpawn()
    {
        StopCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        if (delay == 0) yield break;

        while (true)
        {
            Vector3 spamPos;
            GetRandomPosition(out spamPos);
            GameObject obj = Instantiate(spawnObj, spamPos, Quaternion.identity);
            //UnitManager.instance.AddUnit(obj);
            yield return new WaitForSeconds(delay);
        }
    }


    private void GetRandomPosition(out Vector3 randomPos)
    {
        float offset = 20f;
        float offsetLenght = 60f;
        Vector3 directPoint = spamTarget.transform.position 
            + spamTarget.transform.forward * offsetLenght
            + new Vector3(UnityEngine.Random.Range(-offset, offset), UnityEngine.Random.Range(-offset, offset), UnityEngine.Random.Range(-offset, offset));


        randomPos = spamTarget.transform.position + (directPoint - spamTarget.transform.position).normalized * offsetLenght;
    }
}
