using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
   public AccountValutes AccountValutes;
   
   public List<UpgradeModel> Upgrades;

   public void BuyUpgrade(string ValuteName)
   {
      UpgradeModel upgradeModel = Upgrades.FirstOrDefault(model => model.ValuteName == ValuteName);

      if (upgradeModel.CurrentPrice < upgradeModel.MaxPrice)
      {
         AccountValutes.TakeValuteForUpgrades(upgradeModel.ValuteName, upgradeModel.Prices[upgradeModel.CurrentPrice].Price, upgradeModel);
         upgradeModel.Prices[upgradeModel.CurrentPrice].SetNumberOfValuePrice();
      }
   }
}
