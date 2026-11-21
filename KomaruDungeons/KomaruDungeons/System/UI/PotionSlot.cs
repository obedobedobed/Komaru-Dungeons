using KomaruDungeons.KomaruDungeons.Game;

namespace KomaruDungeons.KomaruDungeons.System.UI;

// Needed for showing current weapon
public class PotionSlot : UIElement
{
    private Player player;

    public PotionSlot(SpriteRectangle slot, RectangleData data, Player player, bool enabled = true)
    : base([slot, data.GetRectCenterized(slot.Rect.Centre)], enabled)
    {
        this.player = player;
    }

    public void UpdatePotion(RectangleData data)
    {
        rects[1] = data.GetRectCenterized(rects[0].Rect.Centre);
    }

    public void RemovePotion()
    {
        rects[1] = EmptyRectangle.Get;
    }
}