using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace KomaruDungeons.KomaruDungeons.System.UI;

public class Bar : UIElement
{
    private float amount;

    public Bar(ColorRectangle backgroundRect, ColorRectangle lineRect, float amount = 1f, bool enabled = true) : base([backgroundRect, lineRect], enabled)
    {
        this.amount = amount;
    }

    public void UpdateAmount(float amount)
    {
        this.amount = amount;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        rects[0].Draw(spriteBatch);
        (rects[1] as ColorRectangle).DrawMod(spriteBatch, widthMod: amount);
    }
}