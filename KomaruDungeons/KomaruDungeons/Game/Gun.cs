using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KomaruDungeons.KomaruDungeons.Game;

public class Gun : Weapon
{
    private Bullet bullet;
    private Vector2 shootPointNonFlip = Vector2.Zero;
    private Vector2 shootPointFlip = Vector2.Zero;

    public Gun(Texture2D sprite, Vector2 size, float fireCooldown, Bullet bullet, Vector2 shootPointNonFlip, Vector2 shootPointFlip) : base(sprite, Vector2.Zero, size, fireCooldown)
    {
        this.bullet = bullet;
        this.shootPointNonFlip = shootPointNonFlip;
        this.shootPointFlip = shootPointFlip;
    }

    protected override void Fire()
    {
        base.Fire();

        // Getting direction
        var mouse = Mouse.GetState();
        var mousePos = new Vector2(mouse.X, mouse.Y);
        var direction = mousePos - position;
        direction.Normalize();

        // Instantiating bullet
        bullet.Instantiate(position + (flipY ? shootPointFlip : shootPointNonFlip), direction, rotation);
    }
}