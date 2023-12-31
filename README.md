### 개인 과제 제출

스파르타 코딩 클럽 유니티 2기 수강생 이규성입니다.

개인과제 프로젝트입니다.

텍스트 RPG를 콘솔창에서 구현한 프로그램입니다.

1. 게임 시작 화면
게임 시작시 간단한 소개 말과 마을에서 할 수 있는 행동을 알려줍니다.
원하는 행동의 숫자를 타이핑하면 실행합니다. 
1 ~ 2 이외 입력시 - 잘못된 입력입니다 출력
```cs
스파르타 마을에 오신 여러분 환영합니다.
이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.

1. 상태 보기
2. 인벤토리

원하시는 행동을 입력해주세요.
>>
```
2. 상태보기
캐릭터의 정보를 표시합니다.
7개의 속성을 가지고 있습니다.
레벨 / 이름 / 직업 / 공격력 / 방어력 / 체력 / Gold
처음 기본값은 이름을 제외하고는 아래와 동일하게 만들어주세요
이후 장착한 아이템에 따라 수치가 변경 될 수 있습니다.
```cs
상태 보기
캐릭터의 정보가 표시됩니다.

Lv. 01      
Chad ( 전사 )
공격력 : 10
방어력 : 5
체 력 : 100
Gold : 1500 G

0. 나가기

원하시는 행동을 입력해주세요.
>>
```
3. 인벤토리
보유 중인 아이템을 전부 보여줍니다.
이때 장착중인 아이템 앞에는 [E] 표시를 붙여 줍니다.
처음 시작시에는 2가지 아이템이 있습니다.
```cs
인벤토리
보유 중인 아이템을 관리할 수 있습니다.

[아이템 목록]
- [E]무쇠갑옷      | 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다.
- 낡은 검         | 공격력 +2 | 쉽게 볼 수 있는 낡은 검 입니다.

1. 장착 관리
0. 나가기

원하시는 행동을 입력해주세요.
>>
```
3 - 1. 장착 관리 
장착관리가 시작되면 아이템 목록 앞에 숫자가 표시됩니다.
일치하는 아이템을 선택했다면 (예제에서 1~2선택시)
* 장착중이지 않다면 → 장착
[E] 표시 추가
* 이미 장착중이라면 → 장착 해제
[E] 표시 없애기

일치하는 아이템을 선택했지 않았다면 (예제에서 1~3이외 선택시)
잘못된 입력입니다 출력

아이템의 중복 장착을 허용합니다.
창과 검을 동시에 장착가능
갑옷도 동시에 착용가능
장착 갯수 제한 X
```cs
인벤토리 - 장착 관리
보유 중인 아이템을 관리할 수 있습니다.

[아이템 목록]
- 1 [E]무쇠갑옷      | 방어력 +5 | 무쇠로 만들어져 튼튼한 갑옷입니다.
- 2 낡은 검         | 공격력 +2 | 쉽게 볼 수 있는 낡은 검입니다.

0. 나가기

원하시는 행동을 입력해주세요.
>>
```


아이템이 장착되었다면 1. 상태보기 에 정보가 반영되어야 합니다.
정보 반영 예제
```cs
상태 보기
캐릭터의 정보가 표시됩니다.

Lv. 01      
Chad ( 전사 )
공격력 : 12 (+2)
방어력 : 10 (+5)
체 력 : 100
Gold : 1500 G

0. 나가기

원하시는 행동을 입력해주세요.
>>
```
#### 작동 예시
![2023-11-13 14-48-42](https://github.com/ssungyeee/Personal-Assignment/assets/149459020/3ad8bc95-c7a7-42c9-8705-6ccc5e93a354)


번호 입력 시 해당 메뉴로 이동

![2023-11-13 14-47-45](https://github.com/ssungyeee/Personal-Assignment/assets/149459020/6fa57337-f7cd-481b-94ae-574a1b17b73c)

![2023-11-13 14-47-27](https://github.com/ssungyeee/Personal-Assignment/assets/149459020/ae138c2f-0a01-423c-ba03-e9c318edf032)

![2023-11-13 14-47-16](https://github.com/ssungyeee/Personal-Assignment/assets/149459020/a90cc9c0-297e-403f-8c10-e70fbff4e8b9)

아이템 장착 시 [E] 추가, 해제 시 삭제
캐릭터 상태창에 아이템의 스테이터스 반영

### 🤸🏻‍♀️Feedback
11/13 작동 구현은 문제와 똑같이 되었지만 코드 작성에 있어서 억지를 좀 부렸다.. 작동엔 문제가 없지만 내용 수정이나 기타 보수에는 분명 불편할 것이다. 튜터님의 해설을 보며 수정하거나 새로 만들어볼 예정이다.

11/14 튜터님의 강의를 보며 지저분하고 억지를 부린 코드를 깔끔하게 정리하였다. 클래스, 메서드, bool, 3항연산자 등의 기본적인 개념 이해도가 높아졌다.
