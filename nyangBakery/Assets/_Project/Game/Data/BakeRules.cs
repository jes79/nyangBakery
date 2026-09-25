using UnityEngine;

namespace NyangBakery.Data
{
    // 표 설계: docs/03_tables/bake_rules.md (한 줄짜리 설정표)
    // 칸 이름은 표 설계와 똑같이 쓴다.
    [CreateAssetMenu(fileName = "bake_rules", menuName = "NyangBakery/Data/bake_rules")]
    public class BakeRules : ScriptableObject
    {
        public int undercooked_price_percent;
        public int burnt_price_percent;
    }
}
