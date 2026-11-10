using KomaruDungeons.KomaruDungeons.Enemies;
using KomaruDungeons.KomaruDungeons.Game;
using KomaruDungeons.KomaruDungeons.System;
using KomaruDungeons.KomaruDungeons.System.UI;
using KomaruDungeons.KomaruDungeons.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.Scenes;

public class GameScene : Scene
{
    private Player player;

    private Bar healthBar;
    private Bar ammoBar;

    public override void Load(ContentManager Content)
    {
        // Rects
        var startWeapon = new Glock(Content.Load<Texture2D>("Sprites/Weapon/Glock"), new Vector2(32, 32), Content.Load<Texture2D>("Sprites/Projectiles/GlockBullet"));
        player = new Player(new Atlas(Content.Load<Texture2D>("Sprites/Player"), new Point(16, 16)), new Vector2(40, 100), new Vector2(64, 64), startWeapon, 25);
        rectangles.Add(player);

        rectangles.Add
        (
            new Pug
            (
                new Atlas(Content.Load<Texture2D>("Sprites/Enemies/Pug"), new Point(16, 16)), new Vector2(400, 200),
                new Vector2(64, 64), player, Content.Load<Texture2D>("Sprites/Weapon/Bite")
            )
        );

        // UI
        // Player Health Bar
        var healthBarBackground = new ColorRectangle(new Color(0, 100, 0), new Vector2(20, 20), new Vector2(200, 40));
        var healthBarLine = new ColorRectangle(new Color(60, 255, 60), new Vector2(20, 20), new Vector2(200, 40));
        healthBar = new Bar(healthBarBackground, healthBarLine);
        uiElements.Add(healthBar);
    }

    public override void Update(GameTime gameTime)
    {
        // Updating rects
        foreach (var rect in rectangles)
        {
            rect.Update(gameTime);
            if (rect.Tag == RectangleTag.Bullet)
            {
                (rect as Bullet).CheckCollisions(rectangles.ToArray());
            }
        }

        // Updating UI
        foreach (var elem in uiElements)
        {
            elem.Update(gameTime);
        }

        // Adding instantiated rects to rects array
        foreach (var rect in instRects)
        {
            rectangles.Add(rect);
        }

        instRects.Clear();

        // Removing removed rects from rects array
        foreach (var rect in rmRects)
        {
            rectangles.Remove(rect);
        }

        rmRects.Clear();

        // Updating specific
        healthBar.UpdateAmount(player.HealthBarAmount);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        // Drawing rects
        spriteBatch.Begin(samplerState: SamplerState.PointClamp, blendState: BlendState.NonPremultiplied);

        // Drawing rects
        foreach (var rect in rectangles)
        {
            rect.Draw(spriteBatch);
        }

        spriteBatch.End();

        // Drawing UI
        spriteBatch.Begin(samplerState: SamplerState.PointClamp, blendState: BlendState.NonPremultiplied);

        // Drawing ui rects
        foreach (var elem in uiElements)
        {
            elem.Draw(spriteBatch);
        }

        spriteBatch.End();
    }
}