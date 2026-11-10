using KomaruDungeons.KomaruDungeons.Interfaces;
using KomaruDungeons.KomaruDungeons.System;
using KomaruDungeons.KomaruDungeons.System.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KomaruDungeons.KomaruDungeons.Game;

public class Player : SpriteRectangle
{
    // Health
    protected readonly int maxHealth;
    protected int health;
    public float HealthBarAmount
    {
        get
        {
            return maxHealth > 0 ? (float)health / maxHealth : 0f;
        }
    }

    // Movement
    private const float SPEED = 100;
    private VerticalDirection vDirection = VerticalDirection.None;
    private HorizontalDirection hDirection = HorizontalDirection.None;

    // Weapon
    private Weapon[] weapons = new Weapon[2];
    private int currentWeapon = 0;

    public float AmmoBarAmount
    {
        get
        {
            if (weapons[currentWeapon] is IHasAmmo hasAmmo)
            {
                return hasAmmo.Ammo > 0 ? (float)hasAmmo.Ammo / hasAmmo.AmmoSetAmmo : 0f;
            }

            return 0f;
        }
    }

    public bool AmmoWeapon
    {
        get
        {
            return weapons[currentWeapon] is IHasAmmo;
        }
    }

    public WeaponSlotData WeapSlotData
    {
        get
        {
            return weapons[currentWeapon].SlotData;
        }
    }

    // Animation
    private const float FRAME_TIME = 0.2f;
    private float frameTime = FRAME_TIME;
    private Animation animation = Animation.Idle;

    // Animation Frames
    private const int FRAME_IDLE_0 = 0;
    private const int FRAME_IDLE_1 = 1;
    private const int FRAME_IDLE_2 = 2;
    private const int FRAME_RUN_0  = 3;
    private const int FRAME_RUN_1  = 4;
    private const int FRAME_RUN_2  = 5;
    private const int FRAME_DEAD   = 6;

    // Animations
    private int frameIndex = 0;
    private int[] AnimIdle = [FRAME_IDLE_0, FRAME_IDLE_1, FRAME_IDLE_2, FRAME_IDLE_1];
    private int[] AnimRun = [FRAME_RUN_0, FRAME_RUN_1, FRAME_RUN_2, FRAME_RUN_1];
    private int[] AnimDead = [FRAME_DEAD];

    // Misc
    private Vector2 lastPos;

    public Player(Atlas atlas, Vector2 position, Vector2 size, Weapon startWeapon, int health) : base(atlas, position, size)
    {
        maxHealth = health;
        this.health = maxHealth;
        weapons[currentWeapon] = startWeapon;
        weapons[currentWeapon].SetPlayer(this);
        Tag = RectangleTag.Player;
    }

    public override void Update(GameTime gameTime)
    {
        float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
        lastPos = position;

        GetInput();
        Move(delta);
        Animate(delta);
        weapons[currentWeapon].Update(gameTime);
    }
    
    private void GetInput()
    {
        var keyboard = Keyboard.GetState();

        // Movement

        // Horizontal
        if (keyboard.IsKeyDown(Keys.A) && keyboard.IsKeyUp(Keys.D))
            hDirection = HorizontalDirection.Left;
        else if (keyboard.IsKeyDown(Keys.D) && keyboard.IsKeyUp(Keys.A))
            hDirection = HorizontalDirection.Right;
        else
            hDirection = HorizontalDirection.None;

        // Vertical
        if (keyboard.IsKeyDown(Keys.W) && keyboard.IsKeyUp(Keys.S))
            vDirection = VerticalDirection.Top;
        else if (keyboard.IsKeyDown(Keys.S) && keyboard.IsKeyUp(Keys.W))
            vDirection = VerticalDirection.Down;
        else
            vDirection = VerticalDirection.None;
    }

    private void Move(float delta)
    {
        var dir = Vector2.Zero;

        // Horizontal
        dir.X = hDirection switch
        {
            HorizontalDirection.Right =>  1,
            HorizontalDirection.Left  => -1,
            _                         =>  0
        };

        // Vertical
        dir.Y = vDirection switch
        {
            VerticalDirection.Top   => -1,
            VerticalDirection.Down  =>  1,
            _                       =>  0
        };

        if (dir != Vector2.Zero)
        {
            dir.Normalize();
        }

        var totalMovement = dir * SPEED * delta;
        position += totalMovement;
    }

    private void Animate(float delta)
    {
        // Animation
        if (position == lastPos && animation != Animation.Idle)
        {
            animation = Animation.Idle;
            frameTime = FRAME_TIME;
            frame = FRAME_IDLE_0;
        }
        else if (position != lastPos && animation != Animation.Run)
        {
            animation = Animation.Run;
            frameTime = FRAME_TIME;
            frame = FRAME_RUN_0;
        }

        // Frame
        if ((frameTime -= delta) <= 0)
        {
            frameIndex++;

            switch (animation)
            {
                case Animation.Idle:
                    if (frameIndex >= AnimIdle.Length)
                    {
                        frameIndex = 0;
                    }
                    frame = AnimIdle[frameIndex];
                break;
                case Animation.Run:
                    if (frameIndex >= AnimRun.Length)
                    {
                        frameIndex = 0;
                    }
                    frame = AnimRun[frameIndex];
                break;
                case Animation.Dead:
                    frameIndex = 0; // Because single frame animation
                    frame = AnimIdle[frameIndex];
                break;
            }

            frameTime = FRAME_TIME;
        }

        // Flip
        if (weapons[currentWeapon].FlippedY)
        {
            flipX = true;
        }
        else
        {
            flipX = false;
        }
    }

    private enum Animation
    {
        Idle,
        Run,
        Dead
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
        weapons[currentWeapon].Draw(spriteBatch);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            
        }
    }
}