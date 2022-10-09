using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using System.Collections.Specialized;

public class Node : MonoBehaviour, IPointerDownHandler
{
    [Header("Color Info")]
    public Color hoverColor;

    private Renderer rend;
    private Color startColor;

    private GameObject turret;

    public Vector3 turretOffset;

    void onMouseDown()
    {
        UnityEngine.Debug.Log("Inside onMouseDown &&&&&&&&&&&&&&&&&&&&&&&&&");
        if (turret != null)
        {
            UnityEngine.Debug.Log("Impossible to Build!");
            return;
        }

        //Building a turrent on an empty node
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);

    }

    void Start ()
    {
        addPhysicsRaycaster();
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void OnMouseEnter ()
    {
        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    void addPhysicsRaycaster()
    {
        PhysicsRaycaster physicsRaycaster = GameObject.FindObjectOfType<PhysicsRaycaster>();
        if (physicsRaycaster == null)
        {
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(turret != null)
        {
            UnityEngine.Debug.Log("Turret cannot be build here");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild(); 
        turret = (GameObject)Instantiate(turretToBuild, transform.position + turretOffset, transform.rotation);
    }
}
