using KomaruDungeons.KomaruDungeons.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.Game;

public class Bullet : SpriteRectangle
{
    private readonly int damage;
    private readonly float speed;
    private readonly float lifeTime;
    private float lifeTimeNow;
    private Vector2 direction;
    private bool instance = false;

    public Bullet(Texture2D sprite, Vector2 position, Vector2 size, int damage, float speed, float lifeTime) : base(sprite, position, size)
    {
        this.damage = damage;
        this.speed = speed;
        this.lifeTime = lifeTime;
        lifeTimeNow = this.lifeTime;
        Tag = RectangleTag.Bullet;
    }

    public override void Update(GameTime gameTime)
    {
        if (!instance)
        {
            return;
        }

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
            if (rect.Tag == RectangleTag.Enemy && Rect.ToRectangle.Intersects(rect.Rect.ToRectangle))
            {
                (rect as Enemy).TakeDamage(damage);
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

    public void Instantiate(Vector2 position, Vector2 direction, float rotation)
    {
        if (instance)
        {
            return;
        }
        
        var clone = new Bullet(sprite, position, size, damage, speed, lifeTime)
        {
            direction = direction,
            rotation = rotation,
            instance = true
        };

        SceneManager.InstantiateRect(clone);
    }
}