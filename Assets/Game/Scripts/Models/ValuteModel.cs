using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable] public class ValuteModel
{
   [Header("Valute Settings")]
   
   public String ValuteName;
   public Text TextOfValute;
   
   [Space] 
   [Header("Values")] 
   
   public List<ValueModel> ValueModels = new List<ValueModel>();

   [Space] 
   [Header("Value Settings")] 
   
   [SerializeField] public List<string> SybvolsOfValue;
   [Space]
   public int _NumberOfValue;
   [Space]
   public int NumberOfMulti;
}
