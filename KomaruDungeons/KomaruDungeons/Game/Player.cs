using KomaruDungeons.KomaruDungeons.System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace KomaruDungeons.KomaruDungeons.Game;

public class Player : SpriteRectangle
{
    // Values
    private const float SPEED = 100;

    // Movement
    private VerticalDirection verticalDirection = VerticalDirection.None;
    private HorizontalDirection horizontalDirection = HorizontalDirection.None;

    public Player(Atlas atlas, Vector2 position, Vector2 size) : base(atlas, position, size)
    {
        // Nothing here yet
    }

    public override void Update(GameTime gameTime)
    {
        float delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

        GetInput();
        Move(delta);
    }
    
    private void GetInput()
    {
        var keyboard = Keyboard.GetState();

        // Movement

        // Horizontal
        if (keyboard.IsKeyDown(Keys.A) && keyboard.IsKeyUp(Keys.D))
            horizontalDirection = HorizontalDirection.Left;
        else if (keyboard.IsKeyDown(Keys.D) && keyboard.IsKeyUp(Keys.A))
            horizontalDirection = HorizontalDirection.Right;
        else
            horizontalDirection = HorizontalDirection.None;

        // Vertical
        if (keyboard.IsKeyDown(Keys.W) && keyboard.IsKeyUp(Keys.S))
            verticalDirection = VerticalDirection.Top;
        else if (keyboard.IsKeyDown(Keys.S) && keyboard.IsKeyUp(Keys.W))
            verticalDirection = VerticalDirection.Down;
        else
            verticalDirection = VerticalDirection.None;
    }

    private void Move(float delta)
    {
        var totalMovement = new Vector2(SPEED * delta);

        // Horizontal
        totalMovement.X *= horizontalDirection switch
        {
            HorizontalDirection.Right =>  1,
            HorizontalDirection.Left  => -1,
            _                         =>  0
        };

        // Vertical
        totalMovement.Y *= verticalDirection switch
        {
            VerticalDirection.Top   => -1,
            VerticalDirection.Down  =>  1,
            _                       =>  0
        };

        position += totalMovement;
    }
}