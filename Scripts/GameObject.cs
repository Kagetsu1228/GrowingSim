using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameObject : MonoBehaviour
{

   public delegate void TreeDied();

   public static event TreeDied OnTreeDeath;
   [SerializeField] private float growRate = 1 - 05;
   [SerializeField] private Vector3 maxSize;
   [SerializeField]private Vector3 startSize;
   
   private void OnEnable()
   {
      GameManger.OnTick += Grow;
   }

   private void Grow()
   {
      transform.localScale *= growRate;
      if (transform.localScale.sqrMagnitude > maxSize.sqrMagnitude)
      {
         ResetTree();
         this.gameObject.SetActive(false);
         OnTreeDeath?.Invoke();
      }
   }

   private void ResetTree()
   {
      transform.localScale = startSize;
   }

   private void OnDisable()
   {
      GameManger.OnTick -= Grow;
   }

   private void Start()
   {
      growRate += Random.Range(-0.05f, 0.05f);
   }
}
