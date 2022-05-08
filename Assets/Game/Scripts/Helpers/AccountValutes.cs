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

   public void TakeValute(string _valuteName)
   {
      ValuteModel valuteModel = ValuteManager.Valutes.FirstOrDefault(model => model.ValuteName == _valuteName);

      if (valuteModel.ValueModels[valuteModel._NumberOfValue].Valute >= 500)
      {
         valuteModel.ValueModels[valuteModel.NumberOfMulti].Valute -= 500;
      }
      else
      {
         for (int i = valuteModel._NumberOfValue; i < valuteModel.ValueModels.Count; i++)
         {
            if (valuteModel.ValueModels[i].Valute >= 1)
            {
               if (i > valuteModel._NumberOfValue + 1)
               {
                  for (int j = i; j > valuteModel._NumberOfValue; j--)
                  {
                     valuteModel.ValueModels[j].Valute--;
                     valuteModel.ValueModels[j - 1].Valute += (1000 - 1);
                  }
                  valuteModel.ValueModels[valuteModel._NumberOfValue].Valute += (1000 - 500);  
               }
               else if(i <= valuteModel._NumberOfValue + 1)
               {
                  valuteModel.ValueModels[i].Valute--;
                  valuteModel.ValueModels[i - 1].Valute += (1000 - 500);  
               }
            }
         }
      }
   }
}
