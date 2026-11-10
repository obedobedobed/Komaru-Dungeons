using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.System.UI;

// UI Object
// Can contain multiply Sprite Rectangles
// Main class for all UI Objects
public class UIElement
{
    protected SpriteRectangle[] rects;
    protected bool enabled = true;

    public UIElement(SpriteRectangle[] rects, bool enabled = true)
    {
        this.rects = rects;
        this.enabled = enabled;
    }

    public virtual void Update(GameTime gameTime)
    {
        if (!enabled)
        {
            return;
        }

        foreach (var rect in rects)
        {
            rect.Update(gameTime);
        }
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        if (!enabled)
        {
            return;
        }

        foreach (var rect in rects)
        {
            rect.Draw(spriteBatch);
        }
    }
}