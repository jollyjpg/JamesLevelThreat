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
    public class SyphilisPrime : CustomEffectCard<Syphilis>
    {
        public override CardDetails Details => new CardDetails
        {
            Title = "syphilis prime",
            Description = "you obtain syphilis, and can spread it to others",
            ModName = "JLT",
            Art = null,
            Rarity = CardInfo.Rarity.Rare,
            Theme = CardThemeColor.CardThemeColorType.EvilPurple,
            Stats = new CardInfoStat[] {
            new CardInfoStat()
                {
                    positive = false,
                    stat = "max hp",
                    amount = "-50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
            new CardInfoStat()
                {
                    positive = false,
                    stat = "",
                    amount = "contagious",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
        }
        };
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            statModifiers.health = 0.5f;
            gun.slow = 5;
        }

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            
            var toxicCloud = Resources.Load<GameObject>("0 cards/Toxic Cloud").GetComponent<Gun>().objectsToSpawn[0];
            gun.objectsToSpawn = new ObjectsToSpawn[] { toxicCloud };
        }

        protected override void Removed(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            
        }
    }

    public class Syphilis : CardEffect
    {
        public override void OnBlock(BlockTrigger.BlockTriggerType trigger)
        {
            
        }

        public override void OnShoot(GameObject projectile)
        {
            
        }

    }

}
