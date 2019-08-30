using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;
    public int initNumItem = 13;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseNumItem() {
        initNumItem--;
        score.text = initNumItem.ToString();
    }
}
