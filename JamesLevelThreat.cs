using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using JamesLevelThreat.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;
using RarityLib;
using RarityLib.Utils;
using UnityEngine;


namespace JamesLevelThreat
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("root.rarity.lib")]
    // Declares our mod to Bepin
    [BepInPlugin(ModId, ModName, Version)]
    // The game our mod is associated with
    [BepInProcess("Rounds.exe")]
    public class JamesLevelThreat : BaseUnityPlugin
    {
        private const string ModId = "com.zachbulb.JamesLevelThreat";
        private const string ModName = "JamesLevelThreat";
        public const string Version = "1.0.0"; // What version are we on (major.minor.patch)?
        public const string ModInitials = "JLT";

        public static JamesLevelThreat instance { get; private set; }
        void Awake()
        {
            // Use this to call any harmony patch files your mod may have
            var harmony = new Harmony(ModId);
            harmony.PatchAll();

            // rarities
            RarityUtils.AddRarity("BindingVow", 0.25f, new Color(0.443f, 0, 0.651f), new Color(0.267f, 0, 0.388f));
            RarityUtils.AddRarity("Honored", 0.05f, new Color(1, 0.847f, 0.514f), new Color(0.75f, 0.597f, 0.264f));
            RarityUtils.AddRarity("James", 0.01f, new Color(0, 1, 0.957f), new Color(0, 0.729f, 0.694f));
            RarityUtils.AddRarity("femboy", 0.05f, new Color(0.984f, 0.694f, 1), new Color(0.718f, 0.502f, 0.729f));
        }
        void Start()
        {
            instance = this;
            CustomCard.BuildCard<HollowPurple>();
            CustomCard.BuildCard<Infinity>();
            CustomCard.BuildCard<ISPOH>();
            CustomCard.BuildCard<HivelordsHubris>();
            CustomCard.BuildCard<DomainExpansion>();
            CustomCard.BuildCard<SyphilisPrime>();
            CustomCard.BuildCard<FreeDog2025>();
            CustomCard.BuildCard<HeavenlyRestriction>();
            CustomCard.BuildCard<Joker>();
            CustomCard.BuildCard<Femboy>();
        }
    }
}
