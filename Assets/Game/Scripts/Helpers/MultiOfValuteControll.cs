using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MultiOfValuteControll : MonoBehaviour, IValuteManager
{
   private ValuteManager ValuteManager;

   private void Start()
   {
      ValuteManager = GetComponent<ValuteManager>();
   }

   private void Update()
   {
      ControllMultiOfValues("Coins");
   }

   public void ControllMultiOfValues(string _valuteName)
   {
      ValuteModel valuteModel = ValuteManager.Valutes.FirstOrDefault(model => model.ValuteName == _valuteName);
      
      ValuesControll(valuteModel);
      
   }

   public void ValuesControll(ValuteModel valuteModel)
   {
      for (int i = 0; i < valuteModel.ValueModels.Count - 1; i++)
      {
         if (valuteModel.ValueModels[i].Multi >= 1000)
         {
            valuteModel.ValueModels[i].Multi -= 1000;
            valuteModel.ValueModels[i + 1].Multi++;
            
            if (i == valuteModel.NumberOfMulti) valuteModel.NumberOfMulti++;
         }
      }

      if (valuteModel.ValueModels[valuteModel.NumberOfMulti].Multi <= 0 && valuteModel.NumberOfMulti > 0)
      {
         valuteModel.NumberOfMulti--;
      }
   }
}
