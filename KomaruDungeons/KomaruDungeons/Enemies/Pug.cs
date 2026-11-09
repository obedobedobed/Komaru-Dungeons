using System;
using KomaruDungeons.KomaruDungeons.Game;
using KomaruDungeons.KomaruDungeons.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.Enemies;

public class Pug : Enemy
{
    // Animation
    private const int IDLE_ANIM = 0;
    private const int RUN_ANIM = 1;
    private const int DEAD_ANIM = 2;
    private const int ANIMS_COUNT = 3;

    // Attack
    private const float ATTACK_START_RADIUS = 100f;
    private const float ATTACK_BITE_RADIUS = 40f;
    private const float ATTACK_COOLDOWN = 2f;
    private float attackCooldown = ATTACK_COOLDOWN;
    private const float ATTACK_TIME = 0.5f;
    private float attackTime = ATTACK_TIME;
    private bool attacking = false;
    private int damage = 5;
    private Texture2D biteTexture;
    private bool showBite;
    private Vector2 bitePos;
    private const float BITE_WIDTH = 28f;
    private readonly Vector2 biteRelativePos;
    private const float BITE_SHOW_TIME = 0.3f;
    private float biteShowTime = BITE_SHOW_TIME;

    public Pug(Atlas atlas, Vector2 position, Vector2 size, Player player, Texture2D biteTexture) : base(atlas, position, size, 70f, player, 0.2f, 20)
    {
        anims = new int[3][];
        for (int i = 0; i < anims.Length; i++)
        {
            switch (i)
            {
                case IDLE_ANIM:
                    anims[i] = [0, 1, 2, 1];
                    break;
                case RUN_ANIM:
                    anims[i] = [3, 4, 5, 4];
                    break;
                case DEAD_ANIM:
                    anims[i] = [6];
                    break;
            }
        }

        this.biteTexture = biteTexture;
        biteRelativePos = new Vector2(size.X / 2 - BITE_WIDTH / 2, 20f);
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

        attackCooldown -= delta;

        if (attackCooldown <= 0 && (player.Rect.Centre - Rect.Centre).Length() <= ATTACK_START_RADIUS && !attacking)
        {
            attacking = true;
            speedMultiplier = 1.7f;
        }

        if (attacking)
        {
            UpdateAttack(delta);
        }

        if (showBite)
        {
            UpdateBite(delta);
        }
    }

    // Attack
    private void UpdateAttack(float delta)
    {
        attackTime -= delta;

        if (attackTime <= 0)
        {
            StopAttack();
        }
        else if ((player.Rect.position - position).Length() <= ATTACK_BITE_RADIUS)
        {
            player.TakeDamage(damage);
            StartBite();
            StopAttack();
        }
    }

    private void StopAttack()
    {
        attacking = false;
        attackCooldown = ATTACK_COOLDOWN;
        attackTime = ATTACK_TIME;

        speedMultiplier = 1f;
    }

    // Bite
    private void StartBite()
    {
        showBite = true;
        biteShowTime = BITE_SHOW_TIME;
        bitePos = position + biteRelativePos;
    }

    private void UpdateBite(float delta)
    {
        biteShowTime -= delta;

        if (biteShowTime <= 0)
        {
            showBite = false;
        }
    }

    protected override void CalculateDirection(float delta)
    {
        direction = player.Rect.position - position;
        direction.Normalize();
    }

    protected override void Animate(float delta)
    {
        if (player.Rect.position.X >= position.X)
        {
            flipX = false;
        }
        else
        {
            flipX = true;
        }

        base.Animate(delta);
    }

    protected override int SetAnim()
    {
        if (direction != Vector2.Zero && anim != RUN_ANIM)
        {
            animFrame = 0;
            frame = anims[RUN_ANIM][animFrame];
            return RUN_ANIM;
        }
        
        if (direction == Vector2.Zero && anim != IDLE_ANIM)
        {
            animFrame = 0;
            frame = anims[IDLE_ANIM][animFrame];
            return IDLE_ANIM;
        }
        else
        {
            return -1; // None
        }
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        
        if (showBite)
        {
            spriteBatch.Draw(biteTexture, new Rectangle(bitePos.ToPoint(), new Point(28, 28)), new Color(Color.White, biteShowTime / BITE_SHOW_TIME));
        }
    }
}