using System;
using NyangBakery.Data;
using UnityEngine;

namespace NyangBakery.Bake
{
    // 오븐 하나의 진행. 굽는 중에 탭하면 판정하고, 판정 뒤에 탭하면 다시 굽는다.
    public class BakeOven : MonoBehaviour
    {
        [SerializeField] private BreadTable breadTable;
        [SerializeField] private BakeRules bakeRules;
        [SerializeField] private string breadId;
        [SerializeField] private BakeTapArea tapArea;

        private float startTime;

        public BreadRow Bread { get; private set; }
        public bool IsBaking { get; private set; }
        public float Elapsed => IsBaking ? Time.time - startTime : 0f;

        public event Action Started;
        public event Action<BakeResult, int> Judged;

        private void Awake()
        {
            if (breadTable == null || !breadTable.TryGet(breadId, out BreadRow bread))
            {
                Debug.LogError($"[BakeOven] data_bread에서 '{breadId}'를 찾을 수 없습니다.", this);
                enabled = false;
                return;
            }
            if (bakeRules == null)
            {
                Debug.LogError("[BakeOven] bake_rules가 연결되지 않았습니다.", this);
                enabled = false;
                return;
            }
            Bread = bread;
        }

        private void OnEnable()
        {
            if (tapArea != null) tapArea.Tapped += OnTapped;
        }

        private void OnDisable()
        {
            if (tapArea != null) tapArea.Tapped -= OnTapped;
        }

        private void Start()
        {
            StartBake();
        }

        private void Update()
        {
            if (IsBaking && Elapsed >= BakeJudge.BurnTime(Bread))
            {
                Finish(BakeResult.Burnt);
            }
        }

        private void OnTapped()
        {
            if (IsBaking) Finish(BakeJudge.Judge(Elapsed, Bread));
            else StartBake();
        }

        private void StartBake()
        {
            startTime = Time.time;
            IsBaking = true;
            Started?.Invoke();
        }

        private void Finish(BakeResult result)
        {
            IsBaking = false;
            Judged?.Invoke(result, BakeJudge.Price(result, Bread, bakeRules));
        }
    }
}
