using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class UpgradeModel
{
   [Header("Upgrade Settings")]
   public String ValuteName;
   public List<PriceModel> Prices;
   public int CurrentPrice;
   public int MaxPrice;
}
