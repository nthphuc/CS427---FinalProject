using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KillGhost : MonoBehaviour
{
    public bool KillerStatus;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "FPSController")
        {
            gameObject.SetActive(false);
            KillerStatus = true;
        }
    }
}
