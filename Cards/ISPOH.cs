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
    class ISPOH : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //Edits values on card itself, which are then applied to the player in `ApplyCardStats`
            UnityEngine.Debug.Log($"[{JamesLevelThreat.ModInitials}][Card] {GetTitle()} has been setup.");
            cardInfo.allowMultiple = false;
            gun.projectileColor = Color.white;
            gun.ignoreWalls = true;
            gun.damage = 2;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Edits values on player when card is selected
            UnityEngine.Debug.Log($"[{JamesLevelThreat.ModInitials}][Card] {GetTitle()} has been added to player {player.playerID}.");
            gun.unblockable = true;
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
            UnityEngine.Debug.Log($"[{JamesLevelThreat.ModInitials}][Card] {GetTitle()} has been removed from player {player.playerID}.");
        }
        


        protected override string GetTitle()
        {
            return "Inverted Spear of Heaven";
        }
        protected override string GetDescription()
        {
            return "Nullfies any cursed technique";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return RarityUtils.GetRarity("Honored");
            //return RarityUtils.GetRarity("insertrarity"); << use when rarity is defined in jlt.css
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {

                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.TechWhite;
        }
        public override string GetModName()
        {
            return JamesLevelThreat.ModInitials;
        }
    }

    public class SimplePoison : CardEffect
    {
        public override void OnShoot(GameObject projectile)
        {
            
            projectile.AddComponent<RayHitPoison>();
        }

    }
}
