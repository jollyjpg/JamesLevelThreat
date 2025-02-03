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


public class JumpyJoker : SimpleCard
{
    public override CardDetails Details => new CardDetails
    {
        Title = "JumpyJoker",
        Description = "+50% health if you have atleast a double jump",
        ModName = "JLT",
        Art = null,
        Rarity = CardInfo.Rarity.Uncommon,
        //RarityUtils.GetRarity("Honored")
        Theme = CardThemeColor.CardThemeColorType.TechWhite,
        Stats = new CardInfoStat[] {
            new CardInfoStat()
                {
                    positive = true,
                    stat = "health",
                    amount = "+50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
        }
    };
    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        if (statModifiers.numberOfJumps > 0) { statModifiers.health = 1.5f; }
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        Debug.Log("Card added to the player!");
    }

    protected override void Removed(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        Debug.Log("Card removed from the player!");
    }
}