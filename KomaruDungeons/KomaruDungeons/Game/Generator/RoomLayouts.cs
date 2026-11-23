namespace KomaruDungeons.KomaruDungeons.Game.Generator;

public static class RoomLayouts
{
    public const int GROUND_INDEX = 0;
    public const int WALL_INDEX = 1;
    public const int BOX_INDEX = 2;
    public const int ABYSS_INDEX = 2;

    public readonly static int[][,] Layouts =
    [
        new int[,]
        {
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
        }
    ];
}