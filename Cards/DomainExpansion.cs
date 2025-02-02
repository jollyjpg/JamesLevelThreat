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
using Photon.Pun.Simple;


namespace JamesLevelThreat.Cards
{
    public class DomainExpansion : CustomEffectCard<DomainEffect>
    {
        public override CardDetails Details => new CardDetails
        {
            Title = "Domain Expansion",
            Description = "On block, open your domain.",
            ModName = "JLT",
            Rarity = RarityUtils.GetRarity("Honored"),
            //or use RarityUtils.GetRarity("insert") if custom rarity
            Theme = CardThemeColor.CardThemeColorType.EvilPurple,
            Stats = new CardInfoStat[] {
            new CardInfoStat()
                {
                    positive = true,
                    stat = "block cd",
                    amount = "+30s",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
        }
        };
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            block.cdAdd = 30;
            //var explosionToSpawn = Resources.Load<GameObject>("0 cards/Explosive Bullet").GetComponent<Gun>().objectsToSpawn[0];
            //gun.objectsToSpawn = new ObjectsToSpawn[] { explosionToSpawn }; cardInfo.allowMultiple = false;
            var fieldToSpawn = Resources.Load<GameObject>("0 cards/Static Field").GetComponent<CharacterStatModifiers>().AddObjectToPlayer;
            fieldToSpawn.transform.localScale = new Vector3(5, 5, 5);
            var explosionStaticField = fieldToSpawn.GetComponent<SpawnObjects>().objectToSpawn[0];
            explosionStaticField.GetComponent<Explosion>().damage = 5;
            explosionStaticField.GetComponent<RemoveAfterSeconds>().seconds = 15;
            statModifiers.AddObjectToPlayer = fieldToSpawn;
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

    public class DomainEffect : CardEffect
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
