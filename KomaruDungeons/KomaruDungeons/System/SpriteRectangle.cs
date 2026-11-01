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

    public RectangleF Rect
    {
        get
        {
            return new RectangleF(position, size);
        }
    }

    public SpriteRectangle(Texture2D sprite, Vector2 position, Vector2 size)
    {
        this.sprite = sprite;
        this.position = position;
        this.size = size;
        mode = SpriteRectangleMode.Solo;
    }

    public SpriteRectangle(Atlas atlas, Vector2 position, Vector2 size)
    {
        this.atlas = atlas;
        this.position = position;
        this.size = size;
        mode = SpriteRectangleMode.Atlas;
    }

    public virtual void Update(GameTime gameTime)
    {
        
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        var flipXEffect = flipX ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

        switch (mode)
        {
            case SpriteRectangleMode.Solo:
                spriteBatch.Draw(sprite, Rect.ToRectangle, null, Color.White, 0f, Vector2.Zero, flipXEffect, 0f);
            break;
            case SpriteRectangleMode.Atlas:
                spriteBatch.Draw(atlas.Sprite, Rect.ToRectangle, atlas.SpriteRects[frame], Color.White, 0f, Vector2.Zero, flipXEffect, 0f);
            break;
        }
    }
}