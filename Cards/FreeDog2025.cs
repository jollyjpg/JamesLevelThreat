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


public class FreeDog2025 : SimpleCard
{
    public override CardDetails Details => new CardDetails
    {
        Title = "Free Dog 2025",
        Description = "Turns your bullet into a free dog",
        ModName = "JLT",
        Art = null,
        Rarity = CardInfo.Rarity.Uncommon,
        Theme = CardThemeColor.CardThemeColorType.FirepowerYellow,
    };
    public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
    {
        gun.attackSpeed = 5;
        gun.projectileSpeed = 0.5f;
        gun.gravity = 0;
        gun.damage = 1.5f;
        var bomb = Resources.Load<GameObject>("0 cards/Timed Detonation").GetComponent<Gun>().objectsToSpawn[0];
        gun.objectsToSpawn = new ObjectsToSpawn[] { bomb };
    }

    protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        Debug.Log("Card added to the player!");
        gunAmmo.maxAmmo = 1;
    }

    protected override void Removed(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
    {
        Debug.Log("Card removed from the player!");
    }
}