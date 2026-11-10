using KomaruDungeons.KomaruDungeons.Game;

namespace KomaruDungeons.KomaruDungeons.System.UI;

// Needed for showing current weapon
public class WeaponSlot : UIElement
{
    private Player player;

    public WeaponSlot(SpriteRectangle slot, WeaponSlotData weapData, Player player, bool enabled = true)
    : base([slot, weapData.GetRect(slot.Rect.Centre)], enabled)
    {
        this.player = player;
    }

    public void UpdateWeapon(WeaponSlotData weapData)
    {
        rects[1] = weapData.GetRect(rects[0].Rect.Centre);
    }
}