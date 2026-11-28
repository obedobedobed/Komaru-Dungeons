using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace KomaruDungeons.KomaruDungeons.System.Collisions;

public static class CollisionChecker
{
    public static CollisionInfo GetInfo(SpriteRectangle mainRect, SpriteRectangle secondaryRect)
    {
        bool collided = false;
        CollisionDirection dir = CollisionDirection.None;

        var rect1 = mainRect.Rect.ToRectangle;
        var rect2 = secondaryRect.Rect.ToRectangle;

        if (CollisionMatrix.MoveMatrix.GetValueOrDefault(mainRect.Tag).Contains(secondaryRect.Tag) 
            && secondaryRect.Collideable && rect1.Intersects(rect2))
        {
            collided = true;

            var overlap = Rectangle.Intersect(rect1, rect2);

            if (overlap.Width < overlap.Height)
            {
                dir = rect1.Center.X < rect2.Center.X ? CollisionDirection.Right : CollisionDirection.Left;
            }
            else
            {
                dir = rect1.Center.Y < rect2.Center.Y ? CollisionDirection.Bottom : CollisionDirection.Top;
            }
        }

        return new CollisionInfo(collided, dir);
    }
}