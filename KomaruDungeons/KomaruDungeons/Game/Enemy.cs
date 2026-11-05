using KomaruDungeons.KomaruDungeons.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.Game;

public abstract class Enemy : SpriteRectangle
{
    // Health
    protected readonly int maxHealth;
    protected int health;

    protected Color healthBarColor = new Color(255, 0, 0);
    protected Color healthBarColorBG = new Color(100, 0, 0);
    protected int healthBarXSpacing = 8;
    protected int healthBarYSpacing = 8;
    protected int healthBarHeight = 12;

    // Movement
    protected Vector2 direction = Vector2.Zero;
    protected readonly float speed;
    protected float speedMultiplier = 1f;

    // Animation
    protected int anim = 0;
    protected int animFrame = 0;
    protected int[][] anims;

    protected readonly float frameTime;
    protected float frameTimeNow;

    // Misc
    protected Player player;

    public Enemy(Atlas atlas, Vector2 position, Vector2 size, float speed, Player player, float frameTime, int health) : base(atlas, position, size)
    {
        this.speed = speed;
        this.player = player;
        this.frameTime = frameTime;
        frameTimeNow = this.frameTime;
        maxHealth = health;
        this.health = maxHealth;
        Tag = RectangleTag.Enemy;
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

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        DrawHealthBar(spriteBatch);
    }

    protected virtual void DrawHealthBar(SpriteBatch spriteBatch)
    {
        var rect = new Rectangle
        (
            (int)position.X + healthBarXSpacing,
            (int)position.Y - healthBarYSpacing - healthBarHeight,
            (int)size.X - healthBarXSpacing * 2,
            healthBarHeight
        );

        spriteBatch.Draw(Game1.Pixel, rect, healthBarColorBG); // Background

        float healthWidth = rect.Width * (float)health / maxHealth;
        rect.Width = (int)healthWidth;
        spriteBatch.Draw(Game1.Pixel, rect, healthBarColor); // Health
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        SceneManager.RemoveRect(this);
    }
}