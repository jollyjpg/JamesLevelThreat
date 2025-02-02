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


namespace JamesLevelThreat.Cards
{
    class HollowPurple : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            UnityEngine.Debug.Log($"[{JamesLevelThreat.ModInitials}][Card] {GetTitle()} has been setup.");
            gun.damage = 100f;
            gun.recoil = 5;
            cardInfo.allowMultiple = false;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            UnityEngine.Debug.Log($"[{JamesLevelThreat.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
            gun.projectileColor = Color.magenta;
            gunAmmo.maxAmmo = 1;
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            UnityEngine.Debug.Log($"[{JamesLevelThreat.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }


        protected override string GetTitle()
        {
            return "hollow purple";
        }
        protected override string GetDescription()
        {
            return "throughout heaven and earth, you alone are the honored one";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity() 
        {
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "damage",
                    amount = "a lot",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "ammo",
                    amount = "one",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.EvilPurple;
        }
        public override string GetModName()
        {
            return JamesLevelThreat.ModInitials;
        }
    }
}
