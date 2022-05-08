using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ValuteManager : MonoBehaviour, IValuteManager
{
   public List<ValuteModel> Valutes = new List<ValuteModel>();
   
   private void Update()
   {
      ControllValuesOfValute("Coins");
   }

   public void ControllValuesOfValute(string _valuteName)
   {
      ValuteModel valuteModel = Valutes.FirstOrDefault(model => model.ValuteName == _valuteName);

      ValuesControll(valuteModel);
      
      ConvertValuteToText(valuteModel);
   }
   
   
   public void ConvertValuteToText(ValuteModel valuteModel)
   {
      if (valuteModel.ValueModels[valuteModel._NumberOfValue].Valute >= 0 && valuteModel._NumberOfValue == 0)
      {
         valuteModel.TextOfValute.text = valuteModel.ValueModels[valuteModel._NumberOfValue].Valute + valuteModel.SybvolsOfValue[valuteModel._NumberOfValue];  
      }
      
      if (valuteModel.ValueModels[valuteModel._NumberOfValue].Valute >= 0 && valuteModel._NumberOfValue > 0 && valuteModel.ValueModels[valuteModel._NumberOfValue - 1].Valute / 100 >= 1)
      {
         valuteModel.TextOfValute.text = valuteModel.ValueModels[valuteModel._NumberOfValue].Valute + "." + (valuteModel.ValueModels[valuteModel._NumberOfValue - 1].Valute / 100).ToString("0") + valuteModel.SybvolsOfValue[valuteModel._NumberOfValue];
      }
      
      if (valuteModel.ValueModels[valuteModel._NumberOfValue].Valute >= 0 && valuteModel._NumberOfValue > 0 && valuteModel.ValueModels[valuteModel._NumberOfValue - 1].Valute / 100 < 1)
      {
         valuteModel.TextOfValute.text = valuteModel.ValueModels[valuteModel._NumberOfValue].Valute + valuteModel.SybvolsOfValue[valuteModel._NumberOfValue];
      }
      
      if (valuteModel.ValueModels[valuteModel._NumberOfValue].Valute >= 10)
      {
         valuteModel.TextOfValute.text = valuteModel.ValueModels[valuteModel._NumberOfValue].Valute + valuteModel.SybvolsOfValue[valuteModel._NumberOfValue];  
      }
   }

   public void ValuesControll(ValuteModel valuteModel)
   {
      for (int i = 0; i < valuteModel.ValueModels.Count - 1; i++)
      {
         if (valuteModel.ValueModels[i].Valute >= 1000)
         {
            valuteModel.ValueModels[i].Valute -= 1000;
            valuteModel.ValueModels[i + 1].Valute++;
            
            if (i == valuteModel._NumberOfValue) valuteModel._NumberOfValue++;
         }
      }

      if (valuteModel.ValueModels[valuteModel._NumberOfValue].Valute <= 0 && valuteModel._NumberOfValue > 0)
      {
         valuteModel._NumberOfValue--;
      }
   }
}
