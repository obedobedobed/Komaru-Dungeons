using System;
using KomaruDungeons.KomaruDungeons.System;
using KomaruDungeons.KomaruDungeons.System.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KomaruDungeons.KomaruDungeons.Game;

public abstract class Weapon : SpriteRectangle
{
    protected float fireCooldown;
    protected float fireCooldownNow;
    protected Player player = null;
    public bool FlippedY { get { return flipY; } }

    public WeaponSlotData SlotData
    {
        get
        {
            return new WeaponSlotData(sprite, size);
        }
    }

    protected MouseState lastMouse;

    public Weapon(Texture2D sprite, Vector2 position, Vector2 size, float fireCooldown) : base(sprite, position, size)
    {
        this.fireCooldown = fireCooldown;
        fireCooldownNow = this.fireCooldown;
        rotationOrigin = new Vector2(sprite.Width / 2, sprite.Height / 2);
        Tag = RectangleTag.Weapon;
    }

    public void SetPlayer(Player player)
    {
        if (this.player == null)
        {
            this.player = player;
        }
    }

    public override void Update(GameTime gameTime)
    {
        float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
        fireCooldownNow -= delta;

        position = new Vector2(player.Center.X, player.Center.Y + 12);

        Rotate();
        GetInput();
    }

    protected virtual void Rotate()
    {
        var mouse = Mouse.GetState();
        var mousePos = new Vector2(mouse.X, mouse.Y);
        var dir = mousePos - position;
        rotation = MathF.Atan2(dir.Y, dir.X);

        if (rotation < -MathF.PI / 2 || rotation > MathF.PI / 2) // 90 degrees = PI / 2 radians
        {
            flipY = true;
        }
        else
        {
            flipY = false;
        }
    }

    protected virtual void GetInput()
    {
        var mouse = Mouse.GetState();

        // Fire
        if (mouse.LeftButton == ButtonState.Pressed && fireCooldownNow <= 0)
        {
            Fire();
        }

        lastMouse = mouse;
    }

    protected virtual void Fire()
    {
        fireCooldownNow = fireCooldown;
    }
}