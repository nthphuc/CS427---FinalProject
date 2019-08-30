using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        string colliderTag = collider.gameObject.tag;
        if(colliderTag == "Player") {
            Debug.Log("QUYEYEYEYEY");
            GameObject scoreText = GameObject.FindWithTag("ScoreText");
            scoreText.GetComponent<ScoreDisplay>().decreaseNumItem();
            Destroy(this.gameObject);
        }
    } 
}
