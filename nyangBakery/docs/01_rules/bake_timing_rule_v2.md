# 결정 카드: bake_timing_rule_v2
- 상태: 확정
- 날짜: 2026-09-25
- 이전 판: bake_timing_rule_v1 (보관)

## 왜
자동으로 돌아가는 게임이지만, 핵심 손맛인 딱 맞게 꺼내는 재미를 주기 위해.
너무 일찍 꺼내도 기본 가격을 받으면 기다릴 이유가 없어지므로, 덜 익음에도 손해를 준다.

## 결정
- 판정 구간 (bake_time, perfect_window는 data_bread에서 읽는다)
  - 덜 익음: bake_time 전에 꺼냄
  - 딱 좋음: bake_time부터 bake_time + perfect_window 전까지 꺼냄
  - 탐: bake_time + perfect_window가 지남. 그때까지 누르지 않으면 자동으로 탐
- 판매 가격
  - 딱 좋음: price에 perfect_bonus(%)를 더한다
  - 덜 익음: price의 undercooked_price_percent(%) (bake_rules에서 읽는다)
  - 탐: price의 burnt_price_percent(%) (bake_rules에서 읽는다)
  - 소수는 버린다
- 판정이 끝난 뒤 오븐을 다시 탭하면 처음부터 다시 굽는다

## 어디에 쓰나
- 굽기 화면의 판정
- 판매 가격 계산

## 예외
- (없음)

## 연결
- 이게 바뀌면 영향받는 것: sell_coin_rule_v1 (아직 없음)
- 먼저 있어야 하는 것: data_bread 표의 bake_time, perfect_window, price, perfect_bonus 칸 / bake_rules 표의 undercooked_price_percent, burnt_price_percent 칸
- 부딪히는 것: 없음

## v1에서 바뀐 것
- 딱 좋은 구간의 시작점을 bake_time으로 정함
- 구간이 끝날 때까지 안 누르면 자동으로 탐
- 덜 익음 가격을 새로 정함 (절반)
- 탐 가격 비율을 bake_rules 표로 옮김
- 소수 버림, 다시 굽기 추가
