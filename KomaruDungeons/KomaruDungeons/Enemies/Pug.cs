using KomaruDungeons.KomaruDungeons.Game;
using KomaruDungeons.KomaruDungeons.System;
using Microsoft.Xna.Framework;

namespace KomaruDungeons.KomaruDungeons.Enemies;

public class Pug : Enemy
{
    private const int IDLE_ANIM = 0;
    private const int RUN_ANIM = 1;
    private const int DEAD_ANIM = 2;
    private const int ANIMS_COUNT = 3;

    public Pug(Atlas atlas, Vector2 position, Vector2 size, Player player) : base(atlas, position, size, 70f, player, 0.2f, 20)
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
    }

    public override void Update(GameTime gameTime)
    {
        if (player.Rect.position.X >= position.X)
        {
            flipX = false;
        }
        else
        {
            flipX = true;
        }

        base.Update(gameTime);
    }

    protected override void CalculateDirection(float delta)
    {
        direction = player.Rect.position - position;
        direction.Normalize();
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
}