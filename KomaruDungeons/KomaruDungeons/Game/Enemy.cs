using KomaruDungeons.KomaruDungeons.System;
using Microsoft.Xna.Framework;

namespace KomaruDungeons.KomaruDungeons.Game;

public abstract class Enemy : SpriteRectangle
{
    protected Vector2 direction = Vector2.Zero;
    protected readonly float speed;
    protected float speedMultiplier = 1f;
    protected Player player;

    protected int anim = 0;
    protected int animFrame = 0;
    protected int[][] anims;

    protected readonly float frameTime;
    protected float frameTimeNow;

    public Enemy(Atlas atlas, Vector2 position, Vector2 size, float speed, Player player, float frameTime) : base(atlas, position, size)
    {
        this.speed = speed;
        this.player = player;
        this.frameTime = frameTime;
        frameTimeNow = this.frameTime;
    }

    public override void Update(GameTime gameTime)
    {
        float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

        CalculateDirection(delta);
        Move(delta);
        Animate(delta);
    }

    protected abstract void CalculateDirection(float delta);

    protected virtual void Move(float delta)
    {
        position += direction * speed * speedMultiplier * delta;
    }

    protected virtual void Animate(float delta)
    {
        int animTmp = SetAnim();
        anim = animTmp >= 0 ? animTmp : anim;

        if ((frameTimeNow -= delta) <= 0)
        {
            animFrame++;

            if (animFrame >= anims[anim].Length)
            {
                animFrame = 0;
                frame = anims[anim][animFrame];
            }

            frame = anims[anim][animFrame];
            frameTimeNow = frameTime;
        }
    }

    protected abstract int SetAnim();
}