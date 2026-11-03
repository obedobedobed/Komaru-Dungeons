using KomaruDungeons.KomaruDungeons.Game;
using KomaruDungeons.KomaruDungeons.System;
using KomaruDungeons.KomaruDungeons.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.Scenes;

public class GameScene : Scene
{
    public override void Load(ContentManager Content)
    {
        var startWeapon = new Glock(Content.Load<Texture2D>("Sprites/Weapon/Glock"), new Vector2(32, 32), Content.Load<Texture2D>("Sprites/Projectiles/GlockBullet"));
        rectangles.Add(new Player(new Atlas(Content.Load<Texture2D>("Sprites/Player"), new Point(16, 16)), new Vector2(0, 0), new Vector2(64, 64), startWeapon));
    }

    public override void Update(GameTime gameTime)
    {
        // Updating rects
        foreach (var rect in rectangles)
        {
            rect.Update(gameTime);
        }

        // Adding instantiated rects to rects array
        foreach (var rect in instRects)
        {
            rectangles.Add(rect);
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        // Drawing rects
        foreach (var rect in rectangles)
        {
            rect.Draw(spriteBatch);
        }

        spriteBatch.End();
    }
}