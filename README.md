# 리온 스튜던츠

서아프리카 시에라리온 코노 코이두의 CEM primary school(편의상 CEM 초등학교)을 위한 전산화 지원 프로그램입니다.

CEM 초등학교는 한국인 선교사 김경중 이평순 부부가 운영하는 사립 초등학교로, 현재 초등학교와 유치원이 있습니다.

현지 상황은 상당히 열악합니다. 오랜 내전으로(관련 영화로 블러드 다이아몬드가 있습니다) 지식인들은 전부 죽거나 망명한 나라입니다. 현지 교사들은 네 자리수 사칙연산도 틀릴 정도의 실력들이지만, 당당히 교사로 일하면서 겸업으로 과외를 하거나 이중계약 등을 아무렇지 않게 하는 수준입니다. 당연히 교사도 핸드폰 이상의 IT기기를 활용해 본 경험이 없습니다.

저희는 이번에 노트북 두대(리눅스 민트, windows 10)를 가져갈 예정이고, 현지에는 교장님이 사용하시는 Windows 7 노트북이 있습니다. 이 앱의 목적은 현지에 있는 노트북을 대상으로 합니다.

결론은, 이 앱은 아프리카의 레거시 환경을 지원하는 학생별 생활기록부, 성적표, 인적사항 관리를 위한 C# - WPF 앱이며, 가능하다면 리본 인터페이스와 DB를 사용하려 합니다.

## 최소 구현 사항 :

1. 학생별 생활기록부, 성적표, 인적사항표, 상담내역
2. 워드, 엑셀 연동
3. 영어, 한글 변경 가능

### 생활기록부

생활기록부는 인적사항, 성적, 상담내역이 하나로 컴파일된 문서입니다.

아래의 세 서식이 하나의 문서로 컴파일되어 출력할 수 있어야 합니다.

### 성적표
![텍스트](https://github.com/binaryeast/LionStudent/blob/master/stdreport.png)

학생 성적표입니다. 우측 상단 사진을 출력하는 부분은 가능하면 구현할 예정입니다.

### 인적사항표
![텍스트](https://github.com/binaryeast/LionStudent/blob/master/stdreport2.png)

학생의 개인정보를 기록하는 문서입니다. 학생별 신상명세, 시상/특별활동 내역 등이 기록됩니다.

### 상담내역
![텍스트](https://github.com/binaryeast/LionStudent/blob/master/stdreport3.png)

한국으로 치면 교사의견란입니다. 간단히 상담한 내역, 교사의견 등이 기록되는 문서입니다.

## 사용환경
```
Windows 7 Ultimate K SP1 & 10 Home

인터넷 접속 원활치 않음 (90% 불가)

업데이트 어려움

하드웨어 성능 나쁨

1000명 이상의 데이터
```
# Lion's students

simple, powerful program for school

### What is it?
This program is C# WPF open-source student reports&records program for Sierra Leone.

We need your ability.
