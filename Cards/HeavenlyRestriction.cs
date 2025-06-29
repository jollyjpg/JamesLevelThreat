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


public class HeavenlyRestriction : SimpleCard
{
    public override CardDetails Details => new CardDetails
    {
        Title = "Heavenly Restriction",
        Description = "a binding vow limits your cursed energy, granting you physical prowess",
        ModName = "JLT",
        Art = null,
        Rarity = RarityUtils.GetRarity("BindingVow"),
        Theme = CardThemeColor.CardThemeColorType.ColdBlue,
    };
    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        cardInfo.allowMultiple = false;
        block.cdMultiplier = 1.2f;
        statModifiers.movementSpeed = 2.5f;
        statModifiers.health = 2;
        statModifiers.numberOfJumps = 2;
        statModifiers.attackSpeedMultiplier = 0.5f;
        statModifiers.regen = 5;
        statModifiers.tasteOfBloodSpeed = 2;
        statModifiers.sizeMultiplier = 1;
        block.healing = 10;
        block.autoBlock = true;
        gun.damage = 0.7f;
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {

    }

    protected override void Removed(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {

    }
}