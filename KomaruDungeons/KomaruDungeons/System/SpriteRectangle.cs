using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.System;

// Object
// Using sprite or atlas
// Main class for all object
public class SpriteRectangle
{
    protected Texture2D sprite;
    protected Atlas atlas;
    protected int frame;
    protected Vector2 position;
    protected Vector2 size;
    protected SpriteRectangleMode mode;
    protected bool flipX = false;
    protected bool flipY = false;
    protected float rotation = 0f;
    protected Vector2 rotationOrigin = Vector2.Zero;
    public float DrawLayer { get; protected set; }
    public RectangleTag Tag { get; protected set; } = RectangleTag.Default;

    public RectangleF Rect
    {
        get
        {
            return new RectangleF(position, size);
        }
    }

    public Vector2 Center
    {
        get
        {
            return new Vector2(position.X + size.X / 2, position.Y + size.Y / 2);
        }
    }

    public SpriteRectangle(Texture2D sprite, Vector2 position, Vector2 size, float layer = 0f, RectangleTag tag = RectangleTag.Default)
    {
        this.sprite = sprite;
        this.position = position;
        this.size = size;
        DrawLayer = layer;
        Tag = tag;
        mode = SpriteRectangleMode.Solo;
    }

    public SpriteRectangle(Atlas atlas, Vector2 position, Vector2 size, float layer = 0f, RectangleTag tag = RectangleTag.Default)
    {
        this.atlas = atlas;
        this.position = position;
        this.size = size;
        DrawLayer = layer;
        Tag = tag;
        mode = SpriteRectangleMode.Atlas;
    }

    public virtual void Update(GameTime gameTime)
    {
        
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        var flipXEffect = flipX ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
        var flipYEffect = flipY ? SpriteEffects.FlipVertically : SpriteEffects.None;

        switch (mode)
        {
            case SpriteRectangleMode.Solo:
                spriteBatch.Draw(sprite, Rect.ToRectangle, null, Color.White, rotation, rotationOrigin, flipXEffect | flipYEffect, 0f);
            break;
            case SpriteRectangleMode.Atlas:
                spriteBatch.Draw(atlas.Sprite, Rect.ToRectangle, atlas.SpriteRects[frame], Color.White, rotation, rotationOrigin, flipXEffect | flipYEffect, 0f);
            break;
        }
    }

    public virtual void Follow(SpriteRectangle rect, Vector2 relativePos = new Vector2())
    {
        position = rect.Rect.position + relativePos;
    }
}