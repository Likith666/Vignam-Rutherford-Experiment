using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtomEnergyHandler : MonoBehaviour
{
    ParticleSystemForceField forceField;
    private void Start()
    {
        forceField = GetComponent<ParticleSystemForceField>();
    }

    public void SetEnergy(float force)
    {
        float nforce = (force * 0.1f + 1f) * 0.1f;
        forceField.gravity = -nforce;
    }
}
