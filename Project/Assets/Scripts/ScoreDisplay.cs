using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{
    // Start is called before the first frame update
    public Text score;
    public int initNumItem = 13;
    public GameObject winText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (initNumItem == 0)
        {
            winText.SetActive(true);
            StartCoroutine(LoadMainMenu());
        }   
    }

    private IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
        yield return new WaitForSeconds(2f);
    }

    public void decreaseNumItem() {
        initNumItem--;
        score.text = initNumItem.ToString();
    }
}
