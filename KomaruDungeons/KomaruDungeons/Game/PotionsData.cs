using KomaruDungeons.KomaruDungeons.System;

namespace KomaruDungeons.KomaruDungeons.Game;

public static class PotionsData
{
    private static bool setuped = false;
    private static RectangleData[] potionsData;

    public const int HEAL_POTION_INDEX = 0;
    public const int POTIONS_COUNT = 1;

    public static void Setup(RectangleData[] data)
    {
        if (!setuped)
        {
            potionsData = data;
            setuped = true;
        }
    }

    public static RectangleData Get(PotionType type)
    {
        return type switch
        {
            PotionType.Heal => potionsData[HEAL_POTION_INDEX],
            _ => EmptyRectangle.Data,
        };
    }
}