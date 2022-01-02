using System;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class OreCollector : MonoBehaviour
{
    public OreForCarry oreFC;
    private List<OreForCarry> carryingOres=new List<OreForCarry>();

    private void Start()
    {
        OreController.onOreBreaked += AddOre;
    }

    void AddOre(Ore ore)
    {
        OreForCarry newOreFC = LeanPool.Spawn(oreFC, ore.transform.position, ore.transform.rotation);
        newOreFC.Init(ore.data);
        newOreFC.StartCoroutine(newOreFC.MoveToPos(NewContainer().transform));
        carryingOres.Add(newOreFC);
    }

    GameObject NewContainer()
    {
        GameObject oreContainer = new GameObject();
        oreContainer.transform.parent = this.transform;
        oreContainer.transform.localPosition = OreCarryPos();
        oreContainer.transform.localEulerAngles = Vector3.zero;
        return oreContainer;
    }

    Vector3 OreCarryPos()
    {
        return new Vector3(-0.25f+(carryingOres.Count%3*0.25f),0.75f+(Mathf.Floor(carryingOres.Count/6)*0.25f),-0.3f-(Mathf.Floor(carryingOres.Count%2)*0.25f));
    }
}
