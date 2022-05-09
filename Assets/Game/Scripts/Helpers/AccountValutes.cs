using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AccountValutes : MonoBehaviour
{
   private ValuteManager ValuteManager;

   private void Start()
   {
      ValuteManager = GetComponent<ValuteManager>();
   }

   public void AddValute(string _valuteName)
   {
      ValuteModel valuteModel = ValuteManager.Valutes.FirstOrDefault(model => model.ValuteName == _valuteName);

      if(valuteModel.NumberOfMulti == 0) valuteModel.ValueModels[valuteModel.NumberOfMulti].Valute += valuteModel.ValueModels[valuteModel.NumberOfMulti].Multi;
      else if (valuteModel.NumberOfMulti > 0)
      {
         for (int i = 0; i <= valuteModel.NumberOfMulti; i++)
         {
            valuteModel.ValueModels[i].Valute += valuteModel.ValueModels[i].Multi;
         }
      }
   }

   public void TakeValute(string _valuteName, float price)
   {
      ValuteModel valuteModel = ValuteManager.Valutes.FirstOrDefault(model => model.ValuteName == _valuteName);

      if (valuteModel.ValueModels[valuteModel._NumberOfValue].Valute >= price)
      {
         valuteModel.ValueModels[valuteModel._NumberOfValue].Valute -= price;
      }
      else
      {
         for (int i = valuteModel._NumberOfValue; i < valuteModel.ValueModels.Count; i++)
         {
            if (valuteModel.ValueModels[i].Valute >= 1)
            {
               if (i <= valuteModel._NumberOfValue + 1)
               {
                  valuteModel.ValueModels[i].Valute--;
                  valuteModel.ValueModels[i - 1].Valute += (1000 - price);
                  break;
               }
               if (i > valuteModel._NumberOfValue + 1)
               {
                  for (int j = i; j >= valuteModel._NumberOfValue; j--)
                  {
                     if (j == i) valuteModel.ValueModels[j].Valute--;
                     if (j < i && j != valuteModel._NumberOfValue) valuteModel.ValueModels[j].Valute += 999;
                     if (j == valuteModel._NumberOfValue) valuteModel.ValueModels[j].Valute += price;
                  }
                  break;
               }
            }
         }
      }
   }
   
   public void TakeValuteForUpgrades(string _valuteName, float price, UpgradeModel upgradeModel)
   {
      ValuteModel valuteModel = ValuteManager.Valutes.FirstOrDefault(model => model.ValuteName == _valuteName);

      if (valuteModel.ValueModels[upgradeModel.Prices[upgradeModel.CurrentPrice].NumberOfValuePrice].Valute >= price)
      {
         valuteModel.ValueModels[upgradeModel.Prices[upgradeModel.CurrentPrice].NumberOfValuePrice].Valute -= price;
         upgradeModel.CurrentPrice++;
      }
      else
      {
         for (int i = upgradeModel.Prices[upgradeModel.CurrentPrice].NumberOfValuePrice + 1; i < valuteModel.ValueModels.Count; i++)
         {
            if (valuteModel.ValueModels[i].Valute >= 1)
            {
               if (i <= valuteModel._NumberOfValue + 1)
               {
                  valuteModel.ValueModels[i].Valute--;
                  valuteModel.ValueModels[i - 1].Valute += (1000 - price);
               }
               if (i > valuteModel._NumberOfValue + 1)
               {
                  for (int j = i; j >= upgradeModel.Prices[upgradeModel.CurrentPrice].NumberOfValuePrice; j--)
                  {
                     if (j == i) valuteModel.ValueModels[j].Valute--;
                     if (j < i && j != upgradeModel.Prices[upgradeModel.CurrentPrice].NumberOfValuePrice) valuteModel.ValueModels[j].Valute += 999;
                     if (j == upgradeModel.Prices[upgradeModel.CurrentPrice].NumberOfValuePrice) valuteModel.ValueModels[j].Valute += price;
                  }
               }
               upgradeModel.CurrentPrice++;
            }
         }
      }
   }
}

