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


namespace JamesLevelThreat.Cards
{
    public class EffectTemplate : CustomEffectCard<ExampleEffect>
    {
        public override CardDetails Details => new CardDetails
        {
            Title = "CardName",
            Description = "CardDescription",
            Rarity = CardInfo.Rarity.Rare,
            //or use RarityUtils.GetRarity("insert") if custom rarity
            Theme = CardThemeColor.CardThemeColorType.MagicPink,
        };
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {

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

    public class ExampleEffect : CardEffect
    {
        public override void OnBlock(BlockTrigger.BlockTriggerType trigger)
        {
            Debug.Log("[ExampleEffect] Player blocked!");
        }

        public override void OnShoot(GameObject projectile)
        {
            Debug.Log("[ExampleEffect] Player fired a shot!");
        }

    }

}
