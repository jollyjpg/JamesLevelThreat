using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using RarityLib;
using RarityLib.Utils;
using ModsPlus;
using UnityEngine.Assertions;
using JamesLevelThreat.Cards;


public class Gambler : SimpleCard
{
    public override CardDetails Details => new CardDetails
    {
        Title = "Gambler",
        Description = "50% chance to get +1 block, 50% chance to lose HALF MAX HP.",
        ModName = "JLT",
        Art = null,
        Rarity = CardInfo.Rarity.Rare,
        //RarityUtils.GetRarity("Honored")
        Theme = CardThemeColor.CardThemeColorType.TechWhite,
        Stats = new CardInfoStat[] {
            new CardInfoStat()
                {
                    positive = true,
                    stat = "block",
                    amount = "+1",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
            new CardInfoStat()
                {
                    positive = false,
                    stat = "max hp",
                    amount = "0.5x",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
        }
    };
    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        var random = new System.Random();
        var randint = random.Next(1,3);
        if (randint == 1) { block.additionalBlocks += 1; } else if (randint == 2){ data.maxHealth *= 0.5f; }
    }

    protected override void Removed(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        
    }
}