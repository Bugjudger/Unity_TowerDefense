using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretDate
{
    public GameObject turretPrefab;
    public int cost;
    public GameObject turretPlusPrefab;
    public int costPlus;
    public TurretType type;
}
public enum TurretType
{
    LaserTurret,
    MissileTurret,
    StandardTurret
}
