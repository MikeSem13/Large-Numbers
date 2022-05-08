using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class ValueModel
{
   [Header("Value Settings")]
   
   public string ValueName;
   public float Valute;

   [Space] 
   [Header("Multi Of Value")] 
   
   public float Multi;
}
