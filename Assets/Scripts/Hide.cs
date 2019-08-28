using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Hide : MonoBehaviour
{
    public Camera mainCamera;
    public Camera hidingCamera;

    public int rayLength = 10;

    private bool guiShow = false;
    private bool isHiding = false;

    // Start is called before the first frame update
    private void Start()
    {
        mainCamera.enabled = true;
        hidingCamera.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {
            if ((hit.collider.gameObject.tag == "Hide") && (isHiding == false))
            {
                Debug.Log("aaaa");
                guiShow = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //GameObject.Find("First Person Controller").GetComponent<CharacterController>().enabled = false;
                    //GameObject.Find("Graphics").GetComponent<MeshRenderer>().enabled = false;

                    mainCamera.enabled = false;
                    hidingCamera.enabled = true;

                    StartCoroutine(Wait());
                }
            }
        }
        else
        {
            guiShow = false;
        }

        Debug.Log(isHiding);
        if (isHiding == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //GameObject.Find("First Person Controller").GetComponent<CharacterController>().enabled = true;
                //GameObject.Find("Graphics").GetComponent<MeshRenderer>().enabled = false;

                mainCamera.enabled = true;
                hidingCamera.enabled = false;

                isHiding = false;
            }
        }
    }

    public bool getHidingStatus()
    {
        return isHiding;
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        isHiding = true;
        guiShow = false;
        yield return new WaitForSeconds(0.5f);

    }

    private void OnGUI()
    {
        if (guiShow == true)
        {
            GUI.Box(new Rect(Screen.width / 2, Screen.height / 2, 100, 25), "Hide inside?");
        }
    }
}
