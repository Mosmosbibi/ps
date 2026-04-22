using UnityEngine;

public class IceballAttack : Attack
{
    [SerializeField] private SimpleProjectile projectile;
    private IceballData.LevelData levelData;
    private float lastCastTime;
    protected override void OnInitialize()
    {
        IceballData iceballData = (IceballData)data;
        levelData = iceballData.GetLevelData(level);
    }
    public override void Tick()
    {
        if (lastCastTime + levelData.cooldown > Time.time)
        {
            return;
        }
        lastCastTime = Time.time;

        for (int i = 0; i < levelData.projectileCount; i++)
        {
            var direction = Random.insideUnitSphere;
            direction.y = 0;
            direction.Normalize();
            SimpleProjectile projectile = Instantiate(this.projectile, transform.position + Vector3.up * 0.5f, Quaternion.LookRotation(direction));
            projectile.Initialize(levelData.damage, levelData.speed);
        }
    }
}
