using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KomaruDungeons.KomaruDungeons.Game;

public class Gun : Weapon
{
    private Bullet bullet;

    public Gun(Texture2D sprite, Vector2 size, float fireCooldown, Bullet bullet) : base(sprite, Vector2.Zero, size, fireCooldown)
    {
        this.bullet = bullet;
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
        bullet.Instantiate(position, direction, rotation);
    }
}