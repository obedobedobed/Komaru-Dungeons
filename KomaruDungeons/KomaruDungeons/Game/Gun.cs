using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KomaruDungeons.KomaruDungeons.Game;

public class Gun : Weapon
{
    private Bullet bullet;
    private Vector2 shootPoint = Vector2.Zero;

    public Gun(Texture2D sprite, Vector2 size, float fireCooldown, Bullet bullet, Vector2 shootPoint) : base(sprite, Vector2.Zero, size, fireCooldown)
    {
        this.bullet = bullet;
        this.shootPoint = shootPoint;
    }

    protected override void Fire()
    {
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
    }
}