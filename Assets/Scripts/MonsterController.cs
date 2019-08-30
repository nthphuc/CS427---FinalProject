using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class MonsterController : MonoBehaviour
{
    public Camera cam;

    public GameObject player;

    public NavMeshAgent agent;

    public GameObject lossNoti;

    private float _x, _y, _z;

    private bool killedPlayer = false;
    // Update is called once per frame
    private void Start()
    {
        _x = gameObject.transform.position.x;
        _y = gameObject.transform.position.y;
        _z = gameObject.transform.position.z;
    }

    private void Update()
    {
        
        if ((Vector3.Distance(player.transform.position,gameObject.transform.position)<20) && (player.GetComponent<Hide>().getHidingStatus() == false))
        {
            agent.SetDestination(player.transform.position);
            GetComponent<Animator>().SetBool("run", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("run", false);
            RandomMove();
        }
    }

    public void RandomMove()
    {
        _y = gameObject.transform.position.y;
        agent.SetDestination(new Vector3(_x, _y, _z));
        if (Vector3.Distance(new Vector3(_x, _y, _z), gameObject.transform.position) <= 1.2f)
        {
            _y = -0.44f;
            _x = UnityEngine.Random.Range(-8.0f, 88.0f);
            _z = UnityEngine.Random.Range(-10.0f, 86.0f);
            agent.SetDestination(new Vector3(_x, _y, _z));
        }
    }
    
    public bool getKilledPlayer()
    {
        return killedPlayer;
    }

    private void OnCollisionEnter(Collision collision) {
        Debug.Log("TOUCHCHCHC");
        string colliderTag = collision.gameObject.tag;
        if(colliderTag == "Player") {
            Debug.Log("YOU DIED");
            killedPlayer = true;
            lossNoti.SetActive(true);

            StartCoroutine(LoadMainMenu());
            //Destroy(collision.gameObject);
            //GameObject lossNotiBoard = GameObject.FindWithTag("LossNoti");
            //Debug.Log(lossNotiBoard);
            //lossNotiBoard.GetComponent<LossNotiControl>().notiLosedGame();
        }
    }

    private IEnumerator LoadMainMenu()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
        yield return new WaitForSeconds(2f);
    }
}
