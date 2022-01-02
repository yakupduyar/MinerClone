using System;
using UnityEngine;

public class Ore : MonoBehaviour
{
   public Renderer[] renderers;
   public OreData data;
   private int _hp;

   public void Init(OreData _data)
   {
      data = _data;
      _hp = data.hitPoint;
      foreach (Renderer _renderer in renderers)
      {
         _renderer.material.color = data.color;
      }
   }

   public bool Break()
   {
      for (int i = 0; i < Mathf.FloorToInt(renderers.Length / _hp); i++)
      {
         renderers[i].gameObject.SetActive(false);
      }
      _hp -= Stats.hitPoint;
      return (_hp <= 0);
   }
}
