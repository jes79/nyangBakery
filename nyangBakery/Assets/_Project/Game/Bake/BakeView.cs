using UnityEngine;
using UnityEngine.UI;

namespace NyangBakery.Bake
{
    // 화면 표시만 한다. 판정은 BakeOven / BakeJudge가 한다.
    public class BakeView : MonoBehaviour
    {
        [SerializeField] private BakeOven oven;

        [Header("진행 막대")]
        [SerializeField] private Image barFill;             // Image Type: Filled, Horizontal
        [SerializeField] private RectTransform perfectZone;  // 막대 안의 딱 좋은 구간 띠

        [Header("결과")]
        [SerializeField] private Text resultText;
        [SerializeField] private Text priceText;

        [Header("색 (임시)")]
        [SerializeField] private Color perfectColor = Color.green;
        [SerializeField] private Color undercookedColor = Color.white;
        [SerializeField] private Color burntColor = Color.gray;

        private void OnEnable()
        {
            oven.Started += OnStarted;
            oven.Judged += OnJudged;
        }

        private void OnDisable()
        {
            oven.Started -= OnStarted;
            oven.Judged -= OnJudged;
        }

        private void Update()
        {
            if (!oven.IsBaking) return;
            barFill.fillAmount = oven.Elapsed / BakeJudge.BurnTime(oven.Bread);
        }

        private void OnStarted()
        {
            // 막대 전체 = 0초 ~ 탐이 되는 시간. 딱 좋은 구간은 bake_time부터 막대 끝까지.
            float burnTime = BakeJudge.BurnTime(oven.Bread);
            perfectZone.anchorMin = new Vector2(oven.Bread.bake_time / burnTime, 0f);
            perfectZone.anchorMax = Vector2.one;
            perfectZone.offsetMin = Vector2.zero;
            perfectZone.offsetMax = Vector2.zero;

            barFill.fillAmount = 0f;
            resultText.text = "굽는 중";
            resultText.color = undercookedColor;
            priceText.text = "";
        }

        private void OnJudged(BakeResult result, int price)
        {
            switch (result)
            {
                case BakeResult.Perfect:
                    resultText.text = "딱 좋음";
                    resultText.color = perfectColor;
                    break;
                case BakeResult.Undercooked:
                    resultText.text = "덜 익음";
                    resultText.color = undercookedColor;
                    break;
                default:
                    resultText.text = "탐";
                    resultText.color = burntColor;
                    break;
            }
            priceText.text = $"가격 {price}\n탭해서 다시 굽기";
            priceText.color = resultText.color;
        }
    }
}
