using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.System;

// Class for scenes managing
// Can load, update or draw a scene
public static class SceneManager
{
    private static Scene[] scenes;
    private static int currentScene = 0;
    private static bool loadedScenes = false;

    public static void LoadScenes(Scene[] scenes)
    {
        if (!loadedScenes)
        {
            SceneManager.scenes = scenes;
            loadedScenes = true;
        }
    }

    public static void LoadScene(int index, ContentManager contentManager)
    {
        currentScene = index;
        scenes[currentScene].Load(contentManager);
    }

    public static void UpdateScene(GameTime gameTime)
    {
        scenes[currentScene].Update(gameTime);
    }

    public static void DrawScene(SpriteBatch spriteBatch)
    {
        scenes[currentScene].Draw(spriteBatch);
    }
}