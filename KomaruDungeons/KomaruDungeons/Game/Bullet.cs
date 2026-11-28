using System.Collections.Generic;
using System.Linq;
using KomaruDungeons.KomaruDungeons.Interfaces;
using KomaruDungeons.KomaruDungeons.System;
using KomaruDungeons.KomaruDungeons.System.Collisions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.Game;

public class Bullet : SpriteRectangle, ICheckingCollisions
{
    private readonly int damage;
    private readonly float speed;
    private readonly float lifeTime;
    private float lifeTimeNow;
    private Vector2 direction;

    public Bullet(Texture2D sprite, Vector2 position, Vector2 size, int damage, float speed, float lifeTime, Vector2 direction, float rotation) : base(sprite, position, size)
    {
        this.damage = damage;
        this.speed = speed;
        this.lifeTime = lifeTime;
        lifeTimeNow = this.lifeTime;
        this.direction = direction;
        this.rotation = rotation;
        Tag = RectangleTag.Bullet;
    }

    public override void Update(GameTime gameTime)
    {
        float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
        Move(delta);

        lifeTimeNow -= delta;

        if (lifeTimeNow <= 0)
        {
            SceneManager.RemoveRect(this);
        }
    }

    public void CheckCollisions(SpriteRectangle[] rects)
    {
        foreach (var rect in rects)
        {
            if (CollisionMatrix.MoveMatrix.GetValueOrDefault(Tag).Contains(rect.Tag) && rect.Collideable && Rect.ToRectangle.Intersects(rect.Rect.ToRectangle))
            {
                if (rect is Enemy enemy)
                {
                    enemy.TakeDamage(damage);
                }
                SceneManager.RemoveRect(this);
                break;
            }
        }
    }

    private void Move(float delta)
    {
        var totalMove = direction * speed * delta;
        position += totalMove;
    }
}