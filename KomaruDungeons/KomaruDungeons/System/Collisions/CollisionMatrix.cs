using System.Collections.Generic;

namespace KomaruDungeons.KomaruDungeons.System.Collisions;

public static class CollisionMatrix
{
    public static Dictionary<RectangleTag, RectangleTag[]> MoveMatrix = new Dictionary<RectangleTag, RectangleTag[]>()
    {
        // Example
        // {
        //     RectangleTag.Default,
        //     [
        //         RectangleTag.Default, RectangleTag.Player, RectangleTag.Enemy,
        //         RectangleTag.Weapon, RectangleTag.Bullet, RectangleTag.UI,
        //         RectangleTag.GroundTile, RectangleTag.WallTile
        //     ]
        // },
        {
            RectangleTag.Player,
            [
                RectangleTag.WallTile, RectangleTag.BoxTile, RectangleTag.DoorTile
            ]
        },
        {
            RectangleTag.Bullet,
            [
                RectangleTag.Enemy, RectangleTag.WallTile, RectangleTag.BoxTile, RectangleTag.DoorTile
            ]
        }
    };
}