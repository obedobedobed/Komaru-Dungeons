using System;
using KomaruDungeons.KomaruDungeons.Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.Weapons;

public class Glock : Gun
{
    public Glock(Texture2D sprite, Vector2 size, Texture2D bulletSprite)
    : base(sprite, size, 0.5f, new Bullet(bulletSprite, Vector2.Zero, new Vector2(24, 24), 4, 350f, 8f), new Vector2(16, 2.5f), 5, 10)
    {
        
    }
}