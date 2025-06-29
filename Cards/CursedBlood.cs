using System;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using RarityLib;
using RarityLib.Utils;
using ModsPlus;

namespace JamesLevelThreat.Cards
{
    public class CursedBlood : CustomEffectCard<BloodEffect>
    {
        public override CardDetails Details => new CardDetails
        {
            Title = "Cursed Blood",
            Description = "Your bullets are powered by your life. Take damage every time you shoot.",
            ModName = "JLT",
            Rarity = CardInfo.Rarity.Rare, // or CardInfo.Rarity.Rare
            Theme = CardThemeColor.CardThemeColorType.DestructiveRed,
            Stats = new CardInfoStat[]
            {
                new CardInfoStat
                {
                    positive = true,
                    stat = "bullet power",
                    amount = "more",
                    simepleAmount = CardInfoStat.SimpleAmount.Some
                },
                new CardInfoStat
                {
                    positive = false,
                    stat = "blood loss",
                    amount = "each shot",
                    simepleAmount = CardInfoStat.SimpleAmount.Some
                }
            }
        };

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            gun.damage *= 2;
        }

        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            gun.projectileColor = Color.red;
        }

        protected override void Removed(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            // No cleanup needed
        }
    }

    public class BloodEffect : CardEffect
    {
        public override void OnShoot(GameObject projectile)
        {
            var health = player.GetComponent<HealthHandler>();
            if (health == null) return;

            // Access the current gun from the player object
            var gun = player.GetComponent<WeaponHandler>()?.gun;
            if (gun == null) return;

            float baseDamage = gun.damage;

            // Self-damage is a percentage of gun damage
            float selfDamage = baseDamage * 0.5f + 5f; // 50% of gun.damage

            Vector2 force = Vector2.down * selfDamage; // magnitude = damage
            Vector2 direction = Vector2.down;
            Color damageColor = Color.red;

            health.TakeDamage(
                force,
                direction,
                damageColor,
                projectile,  // optional reference to projectile
                player,
                true,        // lethal allowed
                true         // ignore block
            );
        }

    }
}
