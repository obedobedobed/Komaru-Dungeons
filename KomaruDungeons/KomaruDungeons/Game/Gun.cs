using System;
using KomaruDungeons.KomaruDungeons.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KomaruDungeons.KomaruDungeons.Game;

public class Gun : Weapon, IHasAmmo
{
    private BulletsGenerator bulletGenerator;
    public int ammo;
    public int Ammo { get => ammo; }
    public int ammoSets;
    public int AmmoSets { get => ammoSets; }
    public int ammoSetAmmo;
    public int AmmoSetAmmo { get => ammoSetAmmo; }
    private Vector2 shootPoint = Vector2.Zero;

    public Gun(Texture2D sprite, Vector2 size, float fireCooldown, BulletsGenerator bulletGenerator, Vector2 shootPoint, int ammoSets, int ammoSetAmmo)
    : base(sprite, Vector2.Zero, size, fireCooldown)
    {
        this.bulletGenerator = bulletGenerator;
        this.shootPoint = shootPoint;

        this.ammoSets = ammoSets;
        this.ammoSetAmmo = ammoSetAmmo;
        ammo = ammoSetAmmo;
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
        if (ammo <= 0)
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
        bulletGenerator.Instantiate(position + offset, direction, rotation);

        // Taking ammo
        ammo--;
    }

    protected virtual void Recharge()
    {
        if (ammoSets > 1 && ammo < ammoSetAmmo)
        {
            ammo = ammoSetAmmo;
            ammoSets--;
        }
    }
}