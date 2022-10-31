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
    public Color notEnoughMoneyColor;

    private Renderer rend;
    private Color startColor;

    [Header("Optional")]
    public GameObject turret;

    public Vector3 positionOffset;

    BuildManager buildManager;
    void onMouseDown()
    {
        UnityEngine.Debug.Log("Inside onMouseDown &&&&&&&&&&&&&&&&&&&&&&&&&");
        if (turret != null)
        {
            UnityEngine.Debug.Log("Impossible to Build!");
            return;
        }


    }

    void Start ()
    {

        addPhysicsRaycaster();
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseEnter ()
    {

        if (!buildManager.CanBuild)
        {
            return;
        }

        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }

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


        if (!buildManager.CanBuild)
        {
            return;
        }

        if(turret != null)
        {
            UnityEngine.Debug.Log("Turret cannot be build here");
            return;
        }

        buildManager.BuildTurretOn(this);
    }
}
