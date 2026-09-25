# 표 설계: bake_rules
- 줄을 구분하는 칸: 없음 (한 줄짜리 설정표)
- 관련 결정 카드: bake_timing_rule_v2

## 칸
- undercooked_price_percent: 정수, 0~100, 덜 익음일 때 기본 판매 가격(price) 대비 비율(%)
- burnt_price_percent: 정수, 0~100, 탐일 때 기본 판매 가격(price) 대비 비율(%)

## 첫 데이터
- undercooked_price_percent 50, burnt_price_percent 50

## 메모
- 빵마다 달라지지 않는 굽기 규칙 숫자만 여기에 둔다. 빵마다 다른 숫자는 data_bread에 둔다
