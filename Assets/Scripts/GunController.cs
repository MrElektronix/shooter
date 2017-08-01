using UnityEngine;
/// <summary>
/// Controlls what gun is currently being handled and where to put it
/// </summary>
public class GunController : MonoBehaviour
{
    public Transform WeaponHold;
    public Gun StartingGun;
    private Gun _equippedGun;

    private void Start()
    {
        if (StartingGun != null)
        {
            EquipGun(StartingGun);
        }
    }

    public void EquipGun(Gun gunToEquip)
    {
        if (_equippedGun != null)
        {
            Destroy(_equippedGun.gameObject);
        }
        _equippedGun = Instantiate(gunToEquip, WeaponHold.position, WeaponHold.rotation);
        _equippedGun.transform.parent = WeaponHold;
    }

    public void Shoot()
    {
        if (_equippedGun != null)
        {
            _equippedGun.Shoot();
        }
    }

}
