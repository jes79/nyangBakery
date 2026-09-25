using System;
using System.Collections.Generic;
using UnityEngine;

namespace NyangBakery.Data
{
    // 표 설계: docs/03_tables/data_bread.md
    // 칸 이름은 표 설계와 똑같이 쓴다.
    [Serializable]
    public class BreadRow
    {
        public string bread_id;
        public string name;
        public float bake_time;
        public float perfect_window;
        public int price;
        public int perfect_bonus;
        public int unlock_level;
    }

    [CreateAssetMenu(fileName = "data_bread", menuName = "NyangBakery/Data/data_bread")]
    public class BreadTable : ScriptableObject
    {
        [SerializeField] private List<BreadRow> rows = new List<BreadRow>();

        public IReadOnlyList<BreadRow> Rows => rows;

        public bool TryGet(string breadId, out BreadRow row)
        {
            row = rows.Find(r => r.bread_id == breadId);
            return row != null;
        }
    }
}
