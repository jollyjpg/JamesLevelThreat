using System;
using System.Collections;
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
            block.cdAdd += 30;

            cardInfo.allowMultiple = false;

            if (DomainEffect.effectPrefab != null) return; // already loaded

            var staticFieldCard = Resources.Load<GameObject>("0 cards/Static Field");
            var staticMods = staticFieldCard.GetComponent<CharacterStatModifiers>();
            var effect = staticMods.AddObjectToPlayer.GetComponent<SpawnObjects>()?.objectToSpawn?[0];

            if (effect == null)
            {
                Debug.LogError("Could not find effect prefab in Static Field.");
                return;
            }

            DomainEffect.effectPrefab = effect;
        }




        protected override void Added(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
        }

        protected override void Removed(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
        }
    }

    public class DomainEffect : CardEffect
    {
        // Shared prefab for all DomainEffect instances
        public static GameObject? effectPrefab;

        public override void OnBlock(BlockTrigger.BlockTriggerType trigger)
        {
            player.StartCoroutine(SpawnAfterDelay());
        }

        private IEnumerator SpawnAfterDelay()
        {
            yield return new WaitForSeconds(1f); // ~1 second startup delay

            if (effectPrefab == null)
            {
                Debug.LogWarning("DomainEffect: effectPrefab is null.");
                yield break;
            }

            var clone = GameObject.Instantiate(effectPrefab, player.transform.position, Quaternion.identity);
            clone.transform.localScale = new Vector3(3f, 3f, 3f);
            clone.SetActive(true);

            var explosion = clone.GetComponent<Explosion>();
            if (explosion != null)
            {
                explosion.damage = 0.5f;
            }

            var remover = clone.GetComponent<RemoveAfterSeconds>();
            if (remover != null)
            {
                remover.seconds = 10f;
            }
        }
        public override void OnShoot(GameObject projectile)
        {
        }
    }



    public class DelayedSpawn : MonoBehaviour
    {
        public GameObject? objectToSpawn;
        public float delay = 1f;
        public Vector3 spawnPosition;
        public Quaternion spawnRotation = Quaternion.identity;

        private void Start()
        {
            StartCoroutine(SpawnAfterDelay());
        }

        private IEnumerator SpawnAfterDelay()
        {
            yield return new WaitForSeconds(delay);
            if (objectToSpawn != null)
            {
                Instantiate(objectToSpawn, spawnPosition, spawnRotation);
            }
            Destroy(gameObject);
        }
    }
}
