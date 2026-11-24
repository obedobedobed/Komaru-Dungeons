namespace KomaruDungeons.KomaruDungeons.Game.Generator;

public static class LevelLayouts
{
    public const int EMPTY_INDEX = 0;
    public const int START_INDEX = 1;
    public const int ENEMIES_INDEX = 2;
    public const int SHOP_INDEX = 3;
    public const int BOSS_INDEX = 4;

    public readonly static int[][,] Layouts =
    [
        new int[,]
        {
            {0, 0, 0, 0, 0},
            {0, 0, 2, 0, 0},
            {0, 2, 1, 2, 0},
            {0, 0, 2, 0, 0},
            {0, 0, 0, 0, 0},
        }
    ];
}