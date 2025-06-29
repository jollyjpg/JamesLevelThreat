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
using System.Collections;

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
            Theme = CardThemeColor.CardThemeColorType.DestructiveRed,
        };

        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            // Load the existing "Supernova" card effect prefab
            var supernovaCard = Resources.Load<GameObject>("0 cards/Supernova");
            if (supernovaCard == null)
            {
                Debug.LogError("ATOMICBOMB: Supernova card prefab not found!");
                return;
            }

            var charStats = supernovaCard.GetComponent<CharacterStatModifiers>();
            var spawnHolder = charStats.AddObjectToPlayer?.GetComponent<SpawnObjects>();
            var effectPrefab = spawnHolder?.objectToSpawn?[0];

            if (effectPrefab == null)
            {
                Debug.LogError("ATOMICBOMB: Could not extract supernova effect prefab.");
                return;
            }

            DestructionEffect.effectPrefab = effectPrefab;

            block.cdAdd += 30;
        }
    }

    public class DestructionEffect : CardEffect
    {
        public static GameObject? effectPrefab;

        public override void OnBlock(BlockTrigger.BlockTriggerType trigger)
        {
            if (effectPrefab == null) return;

            Vector3 pos = player.transform.position;

            var clone = GameObject.Instantiate(effectPrefab, pos, Quaternion.identity);
            if (clone != null)
            {
                clone.transform.localScale = new Vector3(6f, 6f, 6f);
                clone.SetActive(true);

                var explosion = clone.GetComponent<Explosion>();
                var followPlayer = clone.GetComponent<FollowPlayer>();

                if (followPlayer != null)
                {
                    followPlayer.enabled = false;
                }

                if (explosion != null)
                {
                    explosion.ignoreTeam = false;
                    explosion.range = 6f;    // Set explosion range
                    explosion.force = 20f;   // Set explosion force
                    explosion.damage = 2.5f;  // Set explosion damage
                    explosion.auto = false;   // Don't trigger explosion automatically on Start

                    // SpawnedAttack must be assigned so explosion logic works properly
                    var spawned = clone.GetComponent<SpawnedAttack>();
                    if (spawned == null)
                    {
                        spawned = clone.AddComponent<SpawnedAttack>();
                    }
                    spawned.spawner = player;
                }
            }
        }
    }
}
