using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IceballData", menuName = "Attacks/Iceball")]
public class IceballData : AttackData
{
    [System.Serializable]
    public struct LevelData
    {
        public int projectileCount;
        public int damage;
        public float cooldown;
        public float speed;
    }

    [SerializeField] private List<LevelData> levels = new();
    public LevelData GetLevelData(int level) => levels[Mathf.Clamp(level, 0, levels.Count - 1)];
}
