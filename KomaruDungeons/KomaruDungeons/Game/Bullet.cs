using System;
using KomaruDungeons.KomaruDungeons.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.Game;

public class Bullet : SpriteRectangle
{
    private readonly float speed;
    private readonly float lifeTime;
    private float lifeTimeNow;
    private Vector2 direction;
    private bool instance = false;

    public Bullet(Texture2D sprite, Vector2 position, Vector2 size, float speed, float lifeTime) : base(sprite, position, size)
    {
        this.speed = speed;
        this.lifeTime = lifeTime;
        lifeTimeNow = this.lifeTime;
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

    private void Move(float delta)
    {
        Console.WriteLine($"Speed: {speed}, Direction: {direction}, Position: {position}");
        var totalMove = direction * speed;
        position += totalMove;
    }

    public void Instantiate(Vector2 position, Vector2 direction, float rotation)
    {
        if (instance)
        {
            return;
        }
        
        var clone = new Bullet(sprite, position, size, speed, lifeTime)
        {
            direction = direction,
            rotation = rotation,
            instance = true
        };

        SceneManager.InstantiateRect(clone);
    }
}