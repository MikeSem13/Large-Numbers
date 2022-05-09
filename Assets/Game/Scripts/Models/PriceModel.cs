using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable] public class PriceModel
{
   [Header("Price Settings")]
   public float Price;
   public ValuesForPrices Value;
   [Space]
   [Header("Price stats")]
   public int NumberOfValuePrice;
   [Space]
   [Header("For other goals")]
   public ValuesForPrices [] ValuesForPrices;

   public void SetNumberOfValuePrice()
   {
      NumberOfValuePrice = (int)ValuesForPrices.FirstOrDefault(prices => prices == Value);
   }
}

public enum ValuesForPrices
{
   BasicValue,
   ThousandValue, 
   MillionValue,
   BillionValue,
}
