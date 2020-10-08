using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapCube : MonoBehaviour
{
    [HideInInspector]
    public GameObject turretGo;
    private TurretDate turretData;
    [HideInInspector]
    public bool isUpgrade = false;
    public GameObject buildEffect;

    private new Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    public void BuildTurret(TurretDate turretData)
    {
        this.turretData = turretData;
        isUpgrade = false;
        turretGo = GameObject.Instantiate(turretData.turretPrefab, transform.position, Quaternion.identity);
        GameObject effect = GameObject.Instantiate(buildEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1);
    }
    void OnMouseEnter()
    {
        if (turretGo == null && EventSystem.current.IsPointerOverGameObject() == false)
        {
            renderer.material.color = Color.red;
        }
    }
    void OnMouseExit()
    {
        renderer.material.color = Color.white;
    }

    public void UpgradeTurret()
    {

    }
    public void DestroyTurret()
    {

    }
}
