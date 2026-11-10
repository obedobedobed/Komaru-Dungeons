using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KomaruDungeons.KomaruDungeons.Game;

public class Gun : Weapon
{
    private Bullet bullet;
    public int Ammo { get; protected set; }
    public int AmmoSets { get; protected set; }
    public int AmmoSetAmmo { get; protected set; }
    private Vector2 shootPoint = Vector2.Zero;

    public Gun(Texture2D sprite, Vector2 size, float fireCooldown, Bullet bullet, Vector2 shootPoint, int ammoSets, int ammoSetAmmo) : base(sprite, Vector2.Zero, size, fireCooldown)
    {
        this.bullet = bullet;
        this.shootPoint = shootPoint;

        AmmoSets = ammoSets;
        AmmoSetAmmo = ammoSetAmmo;
        Ammo = ammoSetAmmo;
    }

    protected override void GetInput()
    {
        var mouse = Mouse.GetState();

        if (mouse.RightButton == ButtonState.Pressed && lastMouse.RightButton != ButtonState.Pressed)
        {
            Recharge();
        }

        base.GetInput();
    }

    protected override void Fire()
    {
        if (Ammo <= 0)
        {
            return;
        }

        base.Fire();

        // Getting direction
        var mouse = Mouse.GetState();
        var mousePos = new Vector2(mouse.X, mouse.Y);
        var direction = mousePos - position;
        direction.Normalize();

        // Getting shootpoint offset
        var offset = shootPoint - size / 2;
        offset = Vector2.Transform(offset, Matrix.CreateRotationZ(rotation));

        // Instantiating bullet
        bullet.Instantiate(position + offset, direction, rotation);

        // Taking ammo
        Ammo--;
    }

    protected virtual void Recharge()
    {
        if (AmmoSets > 1 && Ammo < AmmoSetAmmo)
        {
            Ammo = AmmoSetAmmo;
            AmmoSets--;
        }
    }
}