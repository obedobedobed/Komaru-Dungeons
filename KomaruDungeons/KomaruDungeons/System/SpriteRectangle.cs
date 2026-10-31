using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.System;

public class SpriteRectangle
{
    protected Texture2D sprite;
    protected Atlas atlas;
    protected int frame;
    protected Vector2 position;
    protected Vector2 size;
    protected SpriteRectangleMode mode;

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

    public void Update(GameTime gameTime)
    {
        
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        switch (mode)
        {
            case SpriteRectangleMode.Solo:
                spriteBatch.Draw(sprite, Rect.ToRectangle, Color.White);
            break;
            case SpriteRectangleMode.Atlas:
                spriteBatch.Draw(atlas.Sprite, Rect.ToRectangle, atlas.SpriteRects[frame], Color.White);
            break;
        }
    }
}