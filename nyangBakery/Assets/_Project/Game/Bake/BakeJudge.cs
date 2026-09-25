using NyangBakery.Data;

namespace NyangBakery.Bake
{
    public enum BakeResult
    {
        Undercooked, // 덜 익음
        Perfect,     // 딱 좋음
        Burnt,       // 탐
    }

    // 결정 카드: docs/01_rules/bake_timing_rule_v2.md
    // 판정과 가격 계산만 한다. 숫자는 모두 표(BreadRow, BakeRules)에서 읽는다.
    public static class BakeJudge
    {
        // 딱 좋은 구간이 끝나는 시간. 이때까지 안 누르면 자동으로 탐.
        public static float BurnTime(BreadRow bread)
        {
            return bread.bake_time + bread.perfect_window;
        }

        public static BakeResult Judge(float elapsed, BreadRow bread)
        {
            if (elapsed < bread.bake_time) return BakeResult.Undercooked;
            if (elapsed < BurnTime(bread)) return BakeResult.Perfect;
            return BakeResult.Burnt;
        }

        // 가격은 모두 price 대비 비율(%). 정수 나눗셈으로 소수는 버린다.
        public static int Price(BakeResult result, BreadRow bread, BakeRules rules)
        {
            switch (result)
            {
                case BakeResult.Perfect:
                    return bread.price * (100 + bread.perfect_bonus) / 100;
                case BakeResult.Undercooked:
                    return bread.price * rules.undercooked_price_percent / 100;
                default:
                    return bread.price * rules.burnt_price_percent / 100;
            }
        }
    }
}
