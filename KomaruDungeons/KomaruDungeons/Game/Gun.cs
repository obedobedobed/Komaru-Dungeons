using System;
using KomaruDungeons.KomaruDungeons.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KomaruDungeons.KomaruDungeons.Game;

public class Gun : Weapon, IHasAmmo
{
    // Bullets
    private readonly BulletsGenerator bulletGenerator;

    // Ammo
    public int ammo;
    public int Ammo { get => ammo; }
    public int ammoTotal;
    public int AmmoTotal { get => ammoTotal; }
    public int defaultAmmoTotal;
    public int DefaultAmmoTotal { get => defaultAmmoTotal; }
    public int ammoInSet;
    public int AmmoInSet { get => ammoInSet; }

    // Recharge
    private readonly float rechargeTime;
    public float RechargeTime { get => rechargeTime; }
    private float rechargeTimeNow;
    public float RechargeTimeNow { get => rechargeTimeNow; }
    private bool rechargingNow = false;
    public bool RechargingNow { get => rechargingNow; }

    // Misc
    private Vector2 shootPoint = Vector2.Zero;

    public Gun(Texture2D sprite, Vector2 size, float fireCooldown, BulletsGenerator bulletGenerator, Vector2 shootPoint, int ammoTotal, int ammoInSet, float rechargeTime)
    : base(sprite, Vector2.Zero, size, fireCooldown)
    {
        this.bulletGenerator = bulletGenerator;
        this.shootPoint = shootPoint;

        this.ammoInSet = ammoInSet;
        this.ammoTotal = ammoTotal;
        defaultAmmoTotal = this.ammoTotal;
        ammo = this.ammoInSet;

        this.rechargeTime = rechargeTime;
        rechargeTimeNow = this.rechargeTime;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

        if (rechargingNow)
        {
            WaitRecharge(delta);
        }
    }

    protected override void GetInput()
    {
        var mouse = Mouse.GetState();

        if (mouse.RightButton == ButtonState.Pressed && lastMouse.RightButton != ButtonState.Pressed)
        {
            StartRecharge();
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
        int neededAmmo = ammoInSet - ammo;
        ammo += neededAmmo;
        ammoTotal -= neededAmmo;
        rechargeTimeNow = rechargeTime;
        rechargingNow = false;
    }

    protected virtual void StartRecharge()
    {
        if (ammoTotal > 0)
        {
            rechargingNow = true;
        }
    }

    protected virtual void WaitRecharge(float delta)
    {
        rechargeTimeNow -= delta;
        Console.WriteLine(rechargeTimeNow);

        if (rechargeTimeNow <= 0)
        {
            Recharge();
        }
    }
}