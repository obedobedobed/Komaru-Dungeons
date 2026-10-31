using KomaruDungeons.KomaruDungeons.Game;
using KomaruDungeons.KomaruDungeons.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.Scenes;

public class GameScene : Scene
{
    public override void Load(ContentManager Content)
    {
        rectangles.Add(new Player(new Atlas(Content.Load<Texture2D>("Sprites/Player"), new Point(16, 16)), new Vector2(0, 0), new Vector2(64, 64)));
    }

    public override void Update(GameTime gameTime)
    {
        foreach (var rect in rectangles)
        {
            rect.Update(gameTime);
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        foreach (var rect in rectangles)
        {
            rect.Draw(spriteBatch);
        }

        spriteBatch.End();
    }
}