using KomaruDungeons.KomaruDungeons.System;

namespace KomaruDungeons.KomaruDungeons.Interfaces;

public interface ICheckingCollisions
{
    void CheckCollisions(SpriteRectangle[] rects);
}