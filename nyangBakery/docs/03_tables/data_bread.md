# 표 설계: data_bread
- 줄을 구분하는 칸: bread_id

## 칸
- bread_id: 글자, bread_001부터, 빵 번호
- name: 글자, 빵 이름
- bake_time: 소수, 1.0~10.0초, 다 구워지는 시간
- perfect_window: 소수, 0.2~1.5초, 딱 좋은 구간 길이
- price: 정수, 1 이상, 기본 판매 가격
- perfect_bonus: 정수, 0~100, 딱 좋을 때 추가 비율(%)
- unlock_level: 정수, 1 이상, 고양이가 이 빵을 배우는 레벨

## 첫 데이터 (테스트용)
- bread_001, 크루아상, bake_time 3.0, perfect_window 0.6, price 10, perfect_bonus 50, unlock_level 1

## 메모
- 빵 종류는 이 표에만 추가한다. 규칙 카드는 고치지 않는다
