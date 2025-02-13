﻿using System;
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


namespace JamesLevelThreat.Cards
{
    public class ISPOH : CustomEffectCard<TestPoison>
    {
        public override CardDetails Details => new CardDetails
        {
            Title = "Inverted Spear of Heaven",
            Description = "Nullfies any cursed technique (including walls)",
            ModName = "JLT",
            Rarity = RarityUtils.GetRarity("Honored"),
            Theme = CardThemeColor.CardThemeColorType.MagicPink,
        };
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            gun.ignoreWalls = true;
            gun.damage = 2;
        }

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            
            gun.unblockable = true;
        }

        protected override void Removed(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            
        }
    }

    public class TestPoison : CardEffect
    {
        public override void OnBlock(BlockTrigger.BlockTriggerType trigger)
        {
            
        }

        public override void OnShoot(GameObject projectile)
        {
            
            projectile.AddComponent<ISPOHPoison>();
        }

    }

}
