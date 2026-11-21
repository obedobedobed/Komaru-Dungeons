using System.Collections.Generic;
using KomaruDungeons.KomaruDungeons.Game;
using KomaruDungeons.KomaruDungeons.Scenes;
using KomaruDungeons.KomaruDungeons.System;
using KomaruDungeons.KomaruDungeons.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KomaruDungeons;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    // Scenes
    private const int GAME_SCENE_INDEX = 0;
    private const int SCENES_COUNT = 1;

    // Misc
    private static Game1 instance;
    public static Texture2D Pixel { get; private set; }
    public static Texture2D EmptyPixel { get; private set; }
    public static Vector2 RightDownCorner
    {
        get
        {
            return new Vector2(instance.graphics.PreferredBackBufferWidth, instance.graphics.PreferredBackBufferHeight);
        }
    }

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        instance = this;
    }

    protected override void Initialize()
    {
        // Loading scenes
        var scenesList = new List<Scene>();

        for (int i = 0; i < SCENES_COUNT; i++)
        {
            switch (i)
            {
                case GAME_SCENE_INDEX:
                    scenesList.Add(new GameScene());
                break;
            }
        }

        SceneManager.LoadScenes(scenesList.ToArray());

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        Pixel = Content.Load<Texture2D>("Sprites/Pixel");
        EmptyPixel = Content.Load<Texture2D>("Sprites/EmptyPixel");

        GroundTile.Setup(new Atlas(Content.Load<Texture2D>("Sprites/Environment/Level1/GroundAtlas"), new Point(16, 16)), instance);
        WallTile.Setup(Content.Load<Texture2D>("Sprites/Environment/Level1/Wall"));

        var potionsData = new RectangleData[PotionsData.POTIONS_COUNT];
        for (int i = 0; i < potionsData.Length; i++)
        {
            switch (i)
            {
                case PotionsData.HEAL_POTION_INDEX:
                    potionsData[i] = new RectangleData(Content.Load<Texture2D>("Sprites/Potions/HealPotion"), new Vector2(32, 32));
                    break;
            }
        }
        PotionsData.Setup(potionsData);

        SceneManager.LoadScene(GAME_SCENE_INDEX, Content);
    }

    protected override void Update(GameTime gameTime)
    {
        SceneManager.UpdateScene(gameTime);

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        SceneManager.DrawScene(spriteBatch);

        base.Draw(gameTime);
    }
}
