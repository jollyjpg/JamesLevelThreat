using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using RarityLib;
using ModsPlus;
using UnityEngine.Assertions;
public class TestPoisonCard : CustomEffectCard<TestPoison>
{
    public override CardDetails Details => new CardDetails
    {
        Title = "TestPoison",
        Description = "i love testing",
        Rarity = CardInfo.Rarity.Uncommon,
        Theme = CardThemeColor.CardThemeColorType.PoisonGreen
    };
}

public class TestPoison : CardEffect
{
    public override void OnBlock(BlockTrigger.BlockTriggerType trigger)
    {
        Debug.Log("[ExampleEffect] Player blocked!");
    }

    public override void OnShoot(GameObject projectile)
    {
        Debug.Log("[ExampleEffect] Player fired a shot!");
        projectile.AddComponent<ISPOHPoison>();
    }
}
