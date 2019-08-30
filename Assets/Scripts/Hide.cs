using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Hide : MonoBehaviour
{
    public Camera mainCamera;
    public Camera hidingCamera;
    public Camera hidingCamera1;
    public Camera hidingCamera2;
    public Camera hidingCamera3;

    public int rayLength = 10;

    private bool guiShow = false;
    private bool isHiding = false;

    // Start is called before the first frame update
    private void Start()
    {
        mainCamera.enabled = true;
        hidingCamera.enabled = false;
        hidingCamera1.enabled = false;
        hidingCamera2.enabled = false;
        hidingCamera3.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
	    string tagName = "";

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {
            tagName = hit.collider.gameObject.tag;	
            if ((tagName == "Hide" || tagName == "Hide1" || tagName == "Hide2" || tagName == "Hide3") && (isHiding == false))
            {
                guiShow = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    mainCamera.enabled = false;

                    if(tagName == "Hide") {
                        hidingCamera.enabled = true;

                        hidingCamera1.enabled = false;
                        hidingCamera2.enabled = false;
                        hidingCamera3.enabled = false;
                    }
                    else if(tagName == "Hide1") {
                        hidingCamera1.enabled = true;

                        hidingCamera.enabled = false;
                        hidingCamera2.enabled = false;
                        hidingCamera3.enabled = false;
                    }
                    else if(tagName == "Hide2") {
                        hidingCamera2.enabled = true;

                        hidingCamera.enabled = false;
                        hidingCamera1.enabled = false;
                        hidingCamera3.enabled = false;
                    }
                    else if(tagName == "Hide3") {
                        hidingCamera3.enabled = true;

                        hidingCamera.enabled = false;
                        hidingCamera1.enabled = false;
                        hidingCamera2.enabled = false;
                    }

                    StartCoroutine(Wait());
                }
            }
        }
        else
        {
            guiShow = false;
        }

        if (isHiding == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                mainCamera.enabled = true;
                if(tagName == "Hide") {
			        hidingCamera.enabled = false;
                }
                else if(tagName == "Hide1") {
                    hidingCamera1.enabled = false;
                }
                else if(tagName == "Hide2") {
                    hidingCamera2.enabled = false;
                }
                else if(tagName == "Hide3") {
                    hidingCamera3.enabled = false;
                }

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
