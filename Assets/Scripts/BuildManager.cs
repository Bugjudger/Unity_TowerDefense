using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    public TurretDate laserTurretDate;
    public TurretDate missileTurretDate;
    public TurretDate standardTurretDate;
    public Text moneyText;
    public Animator moneyAnimator;

    private TurretDate selectedTurretDate;

    private MapCube selectedMapCube;

    private int money = 1000;

    public GameObject upgradeCanvas;

    public Button buttonUpgrade;
    void ShowUpgradeUI(Vector3 pos, bool isDisableUpgrade = false)
    {
        upgradeCanvas.SetActive(true);
        upgradeCanvas.transform.position = pos;
        buttonUpgrade.interactable = !isDisableUpgrade;
    }

    void HideUpgradeUI()
    {
        upgradeCanvas.SetActive(false);
    }

    public void OnUpgradeButtonDown()
    {
        selectedMapCube.UpgradeTurret();
        //HideUpgradeUI();
    }
    public void OnDestroyButtonDown()
    {
        selectedMapCube.DestroyTurret();
        //HideUpgradeUI();
    }

    void ChangeMoney(int change = 0)
    {
        money += change;
        moneyText.text = "￥" + money;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject() == false)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                bool isCollider = Physics.Raycast(ray, out hit, 1000, LayerMask.GetMask("MapCube"));
                if (isCollider)
                {
                    MapCube mapCube = hit.collider.GetComponent<MapCube>();
                    if (selectedTurretDate != null && mapCube.turretGo == null)
                    {
                        if (money >= selectedTurretDate.cost)
                        {
                            ChangeMoney(-selectedTurretDate.cost);
                            mapCube.BuildTurret(selectedTurretDate);
                        }
                        else
                        {
                            moneyAnimator.SetTrigger("Filcker");
                        }
                    }
                    else if (mapCube.turretGo != null)
                    {
                        if(mapCube == selectedMapCube && upgradeCanvas.activeInHierarchy)
                        {
                            HideUpgradeUI();
                        }
                        else
                        {
                            ShowUpgradeUI(mapCube.transform.position, mapCube.isUpgrade);
                        }
                        selectedMapCube = mapCube;
                    }
                    
                }
            }
        }
    }

    public void OnLaserSelected(bool isOn)
    {
        if (isOn) selectedTurretDate = laserTurretDate;
    }
    public void OnMissileSelected(bool isOn)
    {
        if (isOn) selectedTurretDate = missileTurretDate;
    }
    public void OnStandardSelected(bool isOn)
    {
        if (isOn) selectedTurretDate = standardTurretDate;
    }
}
