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
        Title = "Jumpy Joker",
        Description = "If you do not have a double jump then you get touched",
        ModName = "JLT",
        Art = null,
        Rarity = CardInfo.Rarity.Uncommon,
        //RarityUtils.GetRarity("Honored")
        Theme = CardThemeColor.CardThemeColorType.EvilPurple,
        Stats = new CardInfoStat[] {
            new CardInfoStat()
                {
                    positive = false,
                    stat = "touch level",
                    amount = "100000",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
            new CardInfoStat()
                {
                    positive = false,
                    stat = "health if you don't have a double jump",
                    amount = "x0.1",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
            new CardInfoStat()
                {
                    positive = true,
                    stat = "health if you have a double jump",
                    amount = "x2",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
        }
    };
    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        if(data.jumps == 1) { characterStats.health = .1f; } else { characterStats.health = 2f; }
    }

    protected override void Removed(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        
    }
}