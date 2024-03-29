# Dollying (휴대폰 어플리케이션과 연동 가능한 영상 촬영 장비)

## 작품개요
### 개발배경
대한민국 기준, 하루 평균 유튜브 시청 시간은 58.8분으로 다른 프로그램에 비해 사용 시간면에서 월등히 높다. 유튜브 영상 수요의 증가로 유튜브 영상 업로드 시간이 5년 사이에 약 10배 증가하였으며, 업로드 되는 영상 중 42%는 People 카테고리로 Vlog와 같은 개인의 일상에 관련되는 내용을 담고 있다. 이러한 1인 영상 매체가 성장하며 개인 방송장비 매출도 2년 사이에 540% 증가하였다.

 <p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/%EB%A7%A4%EC%B6%9C.png?raw=true" width = 300, height = 300\>  <img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/356167_242543_4944.jpg?raw=true" width = 300, height = 300\></p>

### 전동달리
영화 촬영 시 사용하는 장비를 최근 소형화, 전동화 시켜서 1인 영상 촬영에 사용되고 있다. 현재 시중에 사용되는 제품은 움직임 설정에 정교함이 없기 때문에 휴대폰 어플을 통해서 섬세한 제어와 다양한 움직임을 가능하게 하는 전동달리 제작을 목표로 하였다.

<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/3.jpg" height = 250\></p>

## 작품 설명
### 주요 동작 및 특징
외관
<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/14.JPG" height = 250\></p>
- 앞바퀴는 방향을, 뒷바퀴는 전진과 후진 기능을 수행한다.<br/>
- 윗면의 구멍으로 카메라를 고정한다.<br/>

애플리케이션 설명 : UI 디자인
<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/5.jpg" height = 500\></p>

1. 애플리케이션 시작 화면이다.<br/>
2. 메뉴화면으로 블루투스 연결과 모드선택(직선 촬영, 원형 촬영, 혼합 촬영)이 가능하다.<br/>
3. 직선 촬영 모드 > 이동거리와 이동시간을 입력할 수 있고 기능(순방향, 역방향, 왕복)을 설정이 가능하다<br/>
<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/6.jpg" height = 500\></p>
4. 원형 촬영 모드 > 이동반경, 이동시간, 회전각도를 입력 할 수 있고 기능(순방향, 역방향, 왕복)을 설정 가능, 이동반경은 회전 반지름을, 회전각도는 원형으로 회전하는 각도를 의미한다.<br/>
5. 혼합 촬영 모드 > 직선촬영모드와 원형 촬영 모드를 합친 모드로 직선운동1-원형운동-직선운동2 구조로 구성, 직선운동 1,2구간의 이동거리와 이동시간과 원형운동의 이동반경, 이동시간, 회전 각도를 입력 할 수 있다. 또한 기능(순방향, 역방향, 왕복)을 설정이 가능하다.<br/>
6. 각 모드에서 실행을 눌렀을 때 넘어가는 화면. 기기 작동 시간이 종료되는 시간을 나타내며 입력 값은 수정이 가능하다.<br/>

<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/13.png" height = 200\></p>
③,④,⑤번 상단의 전동 달리 그림은 설정 값에 따라 움직이며 사용자가 기기 실행 전 움직임을 알 수 있도록 도와준다.<br/>
⑥번 상단의 숫자는 기기가 움직이는데 걸리는 시간을 알려주며 시간이 지나면서 감소한다.<br/>

### 전체 시스템 구성
<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/%ED%86%B5%EC%8B%A0%EB%B0%A9%EB%B2%95.png" height = 400\></p>
<> 전송의 시작과 끝을 나타내는 구분자  <br/>
① 촬영 모드(직선 촬영, 원형 촬영, 혼합 촬영)를 결정하는 변수  <br/>
② 직선 촬영 모드 시 이동거리 변수, 혼합 촬영 모드 시 직선운동 1구간의 이동거리 변수 <br/> 
③ 직선 촬영 모드 시 이동시간 변수, 혼합 촬영 모드 시 직선운동 1구간의 이동시간 변수  <br/>
④ 원형 촬영 모드 시 이동반경 변수, 혼합 촬영 모드 시 원형운동의 이동반경 변수  <br/>
⑤ 원형 촬영 모드 시 이동시간 변수, 혼합 촬영 모드 시 원형운동의 이동시간 변수  <br/>
⑥ 원형 촬영 모드 시 회전각도 변수, 혼합촬영모드 시 원형운동의 회전각도 변수  <br/>
⑦ 혼합 촬영 모드 시 직선운동 2구간의 이동거리 변수  <br/>
⑧ 혼합 촬영 모드 시 직선운동 2구간의 이동시간 변수  <br/>
⑨ 기능(순방향, 역방향, 왕복)을 나타내는 변수  <br/>

### 개발 환경(개발 언어, Tool, 사용 시스템 등)
전동 달리 코딩 : C,C++, Arduiono<br/>
애플리케이션 개발 : C#, Unity<br/>
전동 달리 모델링 : SOLIDWORKS<br/>
어플, 로고 디자인 : Adobe Photoshop,Adobe Illustrator<br/>

## 단계별 제작 과정
·  0 단계: 아이디어 선정<br/>
·  1 단계: UI디자인 구성, 전동달리 구조 확정, 사용 부품 선정<br/>
·  2 단계: 전동달리 코딩 개발, 애플리케이션 개발, 전동달리 모델링 및 3D프린터 출력<br/>
·  3 단계: 3D프린터 파트 조립, 기기 시험 작동 후 코드 수정<br/>

### 0단계 : 아이디어 선정
<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/12.jpg" height = 300\></p>


### 1단계 : 어플 디자인 및 부품 구성
<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/%EB%94%94%EC%9E%90%EC%9D%B8.jpg" height = 400\></p>

사용부품 선정
· 아두이노 우노 x 1ea
· 아두이노 우노 쉴드 x 1ea
· 스텝모터, 모터 드라이버 x 2ea
· 서보모터 x 1ea
· 배터리 x 1ea
· 배터리 충전 모듈 x 1ea
· 바퀴 x 2ea

### 2단계 : 전동달리 모델링 및 3D프린터 출력
<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/14.JPG" height = 400\></p>

전동달리 코드 개발 : github 참고
어플리케이션 개발 : github 참고

### 3단계 : 3D프린터 파트 조립
<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/15.jpg" height = 400\></p>


기기 시험 작동 후 코드 수정
<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/13.jpg" height = 400\></p>

## 기타

### 회로도
<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/20.jpg" height = 400\></p>

### 플레이스토어 등록
<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/%ED%94%8C%EB%A0%88%EC%9D%B4%EC%8A%A4%ED%86%A0%EC%96%B4.png" height = 400\></p>

### 계산 과정
스텝 모터가 움직이는 데 필요한 값 계산
계산을 시작하기 전에 알아야 하는 값

1. 스텝모터가 1회전이 몇 개의 스텝으로 이루어져 있는지 여부
<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/%EB%8D%B0%EC%9D%B4%ED%84%B0%EC%8B%9C%ED%8A%B8.png" height = 300\></p>

2. 바퀴 반지름.
· 왼쪽 모터의 1회전에 필요한 스텝은 8이다.
· 디바이스마트에 나와있는 스텝모터 (SZH-EK060) 사양

Step angle이 5.425。이고 감속비는 1/64이므로 1스텝 0.084765625。당 회전한다. 360÷0.084765625 ≒4247이지만 모터드라이버의 full step모드에서는 1/2한 근사치인 2048을 이용한다.

애플리케이션에서 전송받는 값
1. 기기의 이동거리, 2. 기기 이동에 걸리는 시간

구해야 하는 값
1. 스텝모터의 회전속도는 rpm단위이기 때문에 위의 값들을 활용하여 rpm값을 구해야 한다.
2. 해당 거리만큼 이동하는 데 필요한 스텝 수를 알아야 한다.

회전에 필요한 스텝 수 구하기
1. 바퀴의 원주를 알아야 하므로 2πr(r은 반지름)을 통해서 원주를 알아낸다.
2. 이동 거리를 원주로 나누어 바퀴의 회전수를 구한다.
3. 회전수에 스텝 모터 한바퀴 스텝을 곱하여(이번 프로젝트에 사용한 스텝모터의 1회전에 필요한 스텝은 2048) 이동에 필요한 스텝을 알 수 있다.

회전속도 구하기
<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/18.jpg" height = 400\></p>

1. rpm = 회전수 * 이동시간 / 60.

2. 회전 반지름에 따른 회전 각도 구하기
r= 회전 반지름
L= 기기 길이
α=  arctan(r/L)

빨간 삼각형과 주황 삼각형은 합동이므로 θ=180-2α이다.
<p align="center"><img src="https://github.com/tuuktuc86/dollying/blob/master/%EC%82%AC%EC%9A%A9%20%EC%9D%B4%EB%AF%B8%EC%A7%80/13.jpg" height = 700\></p>


http://www.ntrexgo.com/archives/39953
