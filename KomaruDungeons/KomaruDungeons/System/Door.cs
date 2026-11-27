using Microsoft.Xna.Framework;

namespace KomaruDungeons.KomaruDungeons.System;

public class Door : SpriteRectangle
{
    public bool Opened { get; private set; } = false;

    private const float FRAME_TIME = 0.15f;
    private float frameTimeNow = FRAME_TIME;

    private int animation = NONE_ANIM;

    private const int NONE_ANIM = -1;
    private const int OPEN_ANIM = 1;
    private const int CLOSE_ANIM = 2;

    public Door(Atlas atlas, Vector2 position) : base(atlas, position, new Vector2(64, 64), Layers.WALL_LAYER, RectangleTag.DoorTile)
    {
        
    }

    public override void Update(GameTime gameTime)
    {
        if (animation != NONE_ANIM)
        {
            StepFrame(gameTime);
        }
    }

    public void Toggle()
    {
        if (Opened)
        {
            animation = CLOSE_ANIM;
        }
        else
        {
            animation = OPEN_ANIM;
        }
    }

    private void StepFrame(GameTime gameTime)
    {
        if ((frameTimeNow -= (float)gameTime.ElapsedGameTime.TotalSeconds) <= 0f)
        {
            switch (animation)
            {
                case OPEN_ANIM:
                    frame++;
                    if (frame == 3)
                    {
                        animation = NONE_ANIM;
                        Opened = true;
                        Collideable = false;
                    }
                    break;
                case CLOSE_ANIM:
                    frame--;
                    if (frame == 0)
                    {
                        animation = NONE_ANIM;
                        Opened = false;
                        Collideable = true;
                    }
                    break;
            }

            frameTimeNow = FRAME_TIME;
        }
    }
}