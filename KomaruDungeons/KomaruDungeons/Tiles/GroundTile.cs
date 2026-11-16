using System;
using KomaruDungeons.KomaruDungeons.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.Tiles;

// Abstract description of ground tile
public static class GroundTile
{
    private static Game1 gameInstance;
    private static Atlas atlas;
    private static readonly Vector2 size = new Vector2(64, 64);

    public static void Setup(Atlas atlas, Game1 gameInstance)
    {
        GroundTile.atlas = atlas;
        GroundTile.gameInstance = gameInstance;
    }

    public static RectangleData Data
    {
        get
        {
            // Getting cropped texture from atlas
            var targetRect = atlas.SpriteRects[Random.Shared.Next(0, atlas.SpriteRects.Length)];
            Color[] spriteData = new Color[targetRect.Width * targetRect.Height];
            atlas.Sprite.GetData(0, targetRect, spriteData, 0, spriteData.Length);
            var texture = new Texture2D(gameInstance.GraphicsDevice, targetRect.Width, targetRect.Height);
            texture.SetData(spriteData);

            return new RectangleData(texture, size, RectangleTag.GroundTile);
        }
    }
}