public static class Rarities
{
    public static CardInfo.Rarity GetRarity(string name)
    {
        return RarityLib.Utils.RarityUtils.GetRarity(name);
    }
    public static CardInfo.Rarity Common => CardInfo.Rarity.Common;
    public static CardInfo.Rarity Uncommon => CardInfo.Rarity.Uncommon;
    public static CardInfo.Rarity Rare => CardInfo.Rarity.Rare;
    public static CardInfo.Rarity James => RarityLib.Utils.RarityUtils.GetRarity("James");
}