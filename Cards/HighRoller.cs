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

public class HighRoller : SimpleCard
{
    public override CardDetails Details => new CardDetails
    {
        Title = "High Roller",
        Description = "randomizes ur damage; could be extremely good or extremely bad",
        ModName = "JLT",
        Art = null,
        Rarity = CardInfo.Rarity.Uncommon,
        //RarityUtils.GetRarity("Honored")
        Theme = CardThemeColor.CardThemeColorType.FirepowerYellow,
        Stats = new CardInfoStat[] {
            new CardInfoStat()
                {
                    positive = false,
                    stat = "bullet damage",
                    amount = "random",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
        }
    };
    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        var random = new System.Random();
        var rand = (random.NextDouble() * 3);
        gun.damage = (float)rand;
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {

    }

    protected override void Removed(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {

    }
}