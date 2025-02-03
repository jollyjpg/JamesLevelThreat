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


public class Femboy : SimpleCard
{
    public override CardDetails Details => new CardDetails
    {
        Title = "Femboy",
        Description = "tee hee",
        ModName = "JLT",
        Art = null,
        Rarity = RarityUtils.GetRarity("femboy"),
        //RarityUtils.GetRarity("Honored")
        Theme = CardThemeColor.CardThemeColorType.MagicPink,
        Stats = new CardInfoStat[] {
            new CardInfoStat()
                {
                    positive = true,
                    stat = "health",
                    amount = "+100%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
            new CardInfoStat()
                {
                    positive = true,
                    stat = "damage",
                    amount = "+100%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
            new CardInfoStat()
                {
                    positive = true,
                    stat = "reload time",
                    amount = "-100%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
            new CardInfoStat()
                {
                    positive = true,
                    stat = "attack speed",
                    amount = "+100%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
        }
    };
    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        statModifiers.health = 2;
        gun.damage = 2;
        gun.reloadTime = .5f;
        gun.attackSpeedMultiplier = .5f;
        statModifiers.sizeMultiplier = 0.8f;
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        gun.projectileColor = Color.magenta;
    }

    protected override void Removed(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        
    }
}