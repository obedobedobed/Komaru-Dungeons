using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.System.UI;

// Needed for safety
public class WeaponSlotData
{
    private readonly Texture2D sprite;
    private readonly Vector2 size;

    public WeaponSlotData(Texture2D sprite, Vector2 size)
    {
        this.sprite = sprite;
        this.size = size;
    }

    public SpriteRectangle GetRect(Vector2 position)
    {
        return new SpriteRectangle(sprite, position - size / 2, size);
    }
}