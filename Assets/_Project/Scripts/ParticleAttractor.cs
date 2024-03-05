using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAttractor : MonoBehaviour
{

    [SerializeField]
    float attractionForce = 5f;
    [SerializeField]
    Transform centerTransform;
    Spawner spawner;

    private void Start()
    {
        spawner = GetComponent<Spawner>();
    }

    void FixedUpdate()
    {
        ApplyAttraction();
    }

    void ApplyAttraction()
    {
        List<Rigidbody> particleRbs = spawner.GetParticleRigidbodys();

        foreach (Rigidbody particleRb in particleRbs)
        {
            if (particleRb != null)
            {
                Vector3 difference = centerTransform.position - particleRb.transform.position;
                Vector3 attractionDirection = difference.normalized;
                particleRb.AddForce(attractionDirection * attractionForce);
            }
        }
    }

    /*public void AddDelfectionForce(Rigidbody target, Rigidbody center)
    {
        float G = 1f;
        // F = G * ( (m1 * m2) / r^2 )
        // m1 * m2
        float massProduct = center.mass * target.mass * G;

        Vector3 difference = center.position - target.position;

        // r
        float distance = difference.magnitude;

        // G * (m1*m2/r^2)
        float forceMagnitude = G * (massProduct / Mathf.Pow(distance, 2));

        Vector3 forceVector = difference.normalized * forceMagnitude;
        target.AddForce(forceVector);
    }*/
}
