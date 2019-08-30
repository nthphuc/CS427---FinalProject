using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LossNotiControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject lossNotiBoard;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void notiLosedGame() {
        lossNotiBoard.SetActive(true);
    }
}
