using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.System;

public abstract class Scene
{
    protected List<SpriteRectangle> rectangles = new List<SpriteRectangle>();
    protected List<SpriteRectangle> uiRectangles = new List<SpriteRectangle>();
    protected List<SpriteRectangle> instRects = new List<SpriteRectangle>();
    protected List<SpriteRectangle> rmRects = new List<SpriteRectangle>();

    public abstract void Load(ContentManager content);
    public abstract void Update(GameTime gameTime);
    public abstract void Draw(SpriteBatch spriteBatch);

    public virtual void InstantiateRect(SpriteRectangle rect)
    {
        instRects.Add(rect);
    }

    public virtual void RemoveRect(SpriteRectangle rect)
    {
        rmRects.Add(rect);
    }
}