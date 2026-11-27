using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.System;

// Needed for safety
public class RectangleData
{
    protected readonly Texture2D sprite;
    protected readonly Atlas atlas;
    private readonly Vector2 size;
    private readonly SpriteRectangleMode mode;
    private readonly float layer;
    private readonly RectangleTag tag;

    public RectangleData(Texture2D sprite, Vector2 size, float layer = 0f, RectangleTag tag = RectangleTag.Default)
    {
        this.sprite = sprite;
        this.size = size;
        this.layer = layer;
        this.tag = tag;
        mode = SpriteRectangleMode.Solo;
    }

    public RectangleData(Atlas atlas, Vector2 size, float layer = 0f, RectangleTag tag = RectangleTag.Default)
    {
        this.atlas = atlas;
        this.size = size;
        this.layer = layer;
        this.tag = tag;
        mode = SpriteRectangleMode.Atlas;
    }

    public virtual SpriteRectangle GetRect(Vector2 pos)
    {
        return mode switch
        {
            SpriteRectangleMode.Solo  => new SpriteRectangle(sprite, pos, size, layer, tag),
            SpriteRectangleMode.Atlas => new SpriteRectangle(atlas, pos, size, layer, tag),
            _                         => null
        };
    }

    public virtual SpriteRectangle GetRectCenterized(Vector2 pos)
    {
        var centerizedPos = pos - size / 2;

        return mode switch
        {
            SpriteRectangleMode.Solo  => new SpriteRectangle(sprite, centerizedPos, size, layer, tag),
            SpriteRectangleMode.Atlas => new SpriteRectangle(atlas, centerizedPos, size, layer, tag),
            _                         => null
        };
    }
}