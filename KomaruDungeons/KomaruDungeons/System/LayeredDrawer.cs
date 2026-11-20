using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.System;

public static class LayeredDrawer
{
    public static void Draw(SpriteBatch spriteBatch, List<SpriteRectangle> rects)
    {
        var remaining = new List<SpriteRectangle>(rects);
        var sorted = new SpriteRectangle[rects.Count];

        for (int i = 0; i < sorted.Length; i++)
        {
            SpriteRectangle current = remaining[0];

            foreach (var rect in remaining)
            {
                float rectLayer = GetLayer(rect);
                float currentRectLayer = GetLayer(current);

                if (rectLayer < currentRectLayer)
                {
                    current = rect;
                }
            }
            
            remaining.Remove(current);
            sorted[i] = current;
        }

        foreach (var rect in sorted)
        {
            rect?.Draw(spriteBatch);
        }
    }

    private static float GetLayer(SpriteRectangle rect)
    {
        if (rect.DrawLayer == Layers.Y_DEPENDED)
        {
            return 10f + rect.Rect.position.Y / 1000f;
        }

        return rect.DrawLayer;
    }
}