using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject particlePrefab;
    [SerializeField]
    int spawnCount = 10;

    float spawnRadius = 2f;
    GameObject clone;
    List<Rigidbody> particleRigidbodys = new List<Rigidbody>();

    private void Start()
    {
        Spawn(spawnCount);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Spawn(5);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            DeSpawn(5);
        }
    }

    private void Spawn(int count)
    {
        for (int i = 0; i < count; i++)
        {
            clone = Instantiate(particlePrefab, RandomSpawnPosition(), transform.rotation);
            clone.transform.SetParent(this.transform);
            particleRigidbodys.Add(clone.GetComponent<Rigidbody>());
        }
    }

    private void DeSpawn(int count)
    {
        if (particleRigidbodys.Count == 0)
        {
            return;
        }
        for (int i = count-1; i >=0; i--)
        {
            Rigidbody cloneRb = particleRigidbodys[i];
            particleRigidbodys.RemoveAt(i);
            Destroy(cloneRb.gameObject);
        }
    }

    private Vector3 RandomSpawnPosition()
    {
        Vector3 randomPos = Random.onUnitSphere * spawnRadius;
        return randomPos;
    }

    public List<Rigidbody> GetParticleRigidbodys()
    {
        return particleRigidbodys;
    }

    public void AtomCount(float fCount)
    {
        int count = (int)fCount;
        if (particleRigidbodys.Count < count)
        {
            Spawn(count - particleRigidbodys.Count);
        }
        else
        {
            DeSpawn(particleRigidbodys.Count - count);
        }
    }
}
