using KomaruDungeons.KomaruDungeons.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.Game;

public class BulletsGenerator
{
    private readonly Texture2D bulletSprite;
    private readonly Vector2 bulletSize;
    private readonly int bulletDamage;
    private readonly float bulletSpeed;
    private readonly float bulletLifeTime;

    public BulletsGenerator(Texture2D sprite, Vector2 size, int damage, float speed, float lifeTime)
    {
        bulletSprite = sprite;
        bulletSize = size;
        bulletDamage = damage;
        bulletSpeed = speed;
        bulletLifeTime = lifeTime;
    }

    public void Instantiate(Vector2 position, Vector2 direction, float rotation)
    {
        var instance = new Bullet(bulletSprite, position, bulletSize, bulletDamage, bulletSpeed, bulletLifeTime, direction, rotation);
        SceneManager.InstantiateRect(instance);
    }
}