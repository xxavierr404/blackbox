namespace WeaponModules
{
    public interface IMovementModule
    {
        void ApplyBuff(PlayerController player);
        void RevertBuff(PlayerController player);
    }
}