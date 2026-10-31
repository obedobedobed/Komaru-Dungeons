using System.Collections.Generic;
using KomaruDungeons.KomaruDungeons.Scenes;
using KomaruDungeons.KomaruDungeons.System;
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

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
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
