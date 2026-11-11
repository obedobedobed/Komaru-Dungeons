namespace KomaruDungeons.KomaruDungeons.Interfaces;

public interface IHasAmmo
{
    int Ammo { get; }
    int AmmoTotal { get; }
    int DefaultAmmoTotal { get; }
    int AmmoInSet { get; }
    float RechargeTime { get; }
    float RechargeTimeNow { get; }
    bool RechargingNow { get; }
}