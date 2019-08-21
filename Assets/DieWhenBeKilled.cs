using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieWhenBeKilled : MonoBehaviour
{
    public KillGhost killGhost;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "FPSController" && killGhost.KillerStatus == true)
        {
            gameObject.SetActive(false);
            Debug.Log("BE KILLED");
        }
    }
}
