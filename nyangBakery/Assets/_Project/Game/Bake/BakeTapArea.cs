using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NyangBakery.Bake
{
    // 오븐 이미지에 붙인다. 손가락을 뗄 때가 아니라 닿는 순간에 탭으로 친다.
    public class BakeTapArea : MonoBehaviour, IPointerDownHandler
    {
        public event Action Tapped;

        public void OnPointerDown(PointerEventData eventData)
        {
            Tapped?.Invoke();
        }
    }
}
