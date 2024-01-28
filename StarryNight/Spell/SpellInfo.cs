

namespace StarryNight.Spell
{
    public class SpellInfo 
    {
        public string Name { get; set; }
        public SpellType SpellType { get; set; }
        public IEnumerable<string> EffectNames { get; set; }
        public string AnimationPath { get; set; }
        public int AnimationWidth { get; set; }
        public int AnimationHeight { get; set; }
        
        public static explicit operator SpellInfo(string lines)
        {
            string[] data = lines.Split(';');
            SpellInfo spellInfos = new SpellInfo
            {
                Name = data[0],
                SpellType = data[1] == "selfcast" ? SpellType.SelfCast : SpellType.Projectile,
                AnimationPath = data[2],
                AnimationWidth = int.Parse(data[3]),
                AnimationHeight = int.Parse(data[4]),
                EffectNames = data[5].Split(',')
            };
            return spellInfos;
        }
    }
}
