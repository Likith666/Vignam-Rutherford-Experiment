using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaHandler : MonoBehaviour
{
    [SerializeField]
    ParticleSystem pSystem;
    ParticleSystem.TrailModule trails;

    private void Start()
    {
        trails = pSystem.trails;
    }

    public void TraceToggle(bool toggle)
    {
        trails.enabled = toggle;
    }

    public void AlphaEnergy(float speed)
    {
        var main = pSystem.main;
        main.simulationSpeed = speed;
    }
}
