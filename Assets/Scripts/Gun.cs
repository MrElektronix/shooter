using UnityEngine;
/// <summary>
/// function of a gun in general
/// </summary>
public class Gun : MonoBehaviour
{
    public Transform Muzzle;
    public Projectile Projectile;
    public float MsBetweenShots = 100;
    public float MuzzleVelocity = 35;

    private float _nextShotTime;
    public void Shoot()
    {
        if (!(Time.time > _nextShotTime)) return;
        _nextShotTime = Time.deltaTime + MsBetweenShots / 1000;
        var newProjectile = Instantiate(Projectile, Muzzle.position, Muzzle.rotation);
        newProjectile.SetSpeed(MuzzleVelocity);
    }


}
