using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class OreController : MonoBehaviour
{
    public static event Action<Ore> onOreBreaked;
    public static OreController instance;
    public Ore orePrefab;
    public ParticleSystem oreBreaking;
    public Transform spawnStart;
    public int scaleX, scaleZ;
    private void Start()
    {
        if (!instance) instance = this;
        Create();
    }
    void Create()
    {
        LevelData level = Resources.Load("Levels/"+PlayerPrefs.GetInt("Level").ToString()) as LevelData;
        Vector3 spawnPos;
        for (int x = -scaleX; x <= scaleX; x++)
        {
            for (int z = 0; z <= scaleZ; z++)
            {
                int oreIndex = SelectOre(level);
                spawnPos = spawnStart.position + Vector3.right * x + Vector3.forward * z;
                Ore spawnedOre = LeanPool.Spawn(orePrefab, spawnPos, Quaternion.identity);
                spawnedOre.Init(level.oresInLevel[oreIndex]);
            }
        }
    }
    public void BreakOre(Ore ore)
    {
        if(ore.Break())
        {
            onOreBreaked?.Invoke(ore);
            LeanPool.Despawn(ore);
        }
        ParticleSystem spawnedParticle = LeanPool.Spawn(oreBreaking, ore.transform.position, quaternion.identity);
        var particleMain = spawnedParticle.main;
        particleMain.startColor = ore.data.color;
        LeanPool.Despawn(spawnedParticle,3);
    }
    int SelectOre(LevelData level)
    {
        int selectedOre;
        float chance = Random.Range(0f, 1f);
        if (chance < level.valuableChance)
        {
            selectedOre = Random.Range(0, level.oresInLevel.Length);
        }
        else
        {
            selectedOre = 0;
        }
        return selectedOre;
    }

    
}
