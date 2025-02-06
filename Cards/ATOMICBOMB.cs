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
using UnityEngine.Assertions.Must;
using System.Text.RegularExpressions;


namespace JamesLevelThreat.Cards
{
    public class ATOMICBOMB : CustomEffectCard<DestructionEffect>
    {
        public override CardDetails Details => new CardDetails
        {
            Title = "ATOMIC BOMB",
            Description = "Your imminent demise.",
            ModName = "JLT",
            Rarity = RarityUtils.GetRarity("Honored"),
            //or use RarityUtils.GetRarity("insert") if custom rarity
            Theme = CardThemeColor.CardThemeColorType.DestructiveRed,
        };
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            
        }

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            
        }

        protected override void Removed(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            
        }
    }

    public class DestructionEffect : CardEffect
    {
        public override void OnBlock(BlockTrigger.BlockTriggerType trigger)
        {
            

        }
        
        public override void OnShoot(GameObject projectile)
        {
            
        }

    }

}
