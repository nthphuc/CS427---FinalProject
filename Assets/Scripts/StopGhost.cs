using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StopGhost : MonoBehaviour
{
    public NavMeshAgent agent;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "FPSController")
        {
            gameObject.SetActive(false);
            agent.isStopped = true;
        }
    }
}
