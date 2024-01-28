using Newtonsoft.Json;


namespace StarryNight.Spell
{
    public class SpellDataProvider : ISpellDataProvider
    {
        private Dictionary<string, SpellInfo> spellInfos;
        private Dictionary<string, int> spellEffects;
        
        private SpellDataProvider()
        {
        }
        
        public Dictionary<string, int> GetSpellEffects()
        {
            if (this.spellEffects == null)
            {
                this.LoadSpellEffects();
            }
            return this.spellEffects;
        }

        public Dictionary<string, SpellInfo> GetSpellInfo()
        {
            if (this.spellInfos == null)
            {
                this.LoadSpellInfo();
            }
            return this.spellInfos;
        }
        private void LoadSpellEffects()
        {
            this.spellEffects = new Dictionary<string, int>();
            string js = File.ReadAllText("resources/effects.json");
            List<SpellEffectInfo> effects = JsonConvert.DeserializeObject<List<SpellEffectInfo>>(js);
            foreach (SpellEffectInfo info in effects)
            {
                this.spellEffects.Add(info.Name, info.Cost);
            }

        }

        private void LoadSpellInfo()
        {
            this.spellInfos = new Dictionary<string, SpellInfo>();
            string[] lines = File.ReadAllLines("resources/spells.csv");
            
            for(int i = 1; i < lines.Length; i++)
            {
                SpellInfo spellInfo = (SpellInfo)lines[i];
                spellInfos.Add(spellInfo.Name, spellInfo);
            }

        }
        private class SpellEffectInfo
        {
            [JsonProperty("name")]
            public string Name { get; set; }
            [JsonProperty("cost")]
            public int Cost { get; set; }
        }

        public static SpellDataProvider GetInstance()
        {
            return new SpellDataProvider();
        }
    }
}
