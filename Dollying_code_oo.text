//헤더파일
#include <Servo.h>
#include <SoftwareSerial.h>
#include <Stepper.h>

//스테핑모터 정보. 모터 스펙에 맞게 설정
const int stepsPerRevolution = 2048; //28BYJ-48는 1회전당 2048스텝

//핀번호
#define BT_RXD 2
#define BT_TXD 3
Stepper rightStepper(stepsPerRevolution, 11, 9, 10, 8);  //오른쪽 바퀴를 돌릴 모터
Stepper leftStepper(stepsPerRevolution, 7, 12, 6, 4);    //왼쪽 바퀴를 돌릴 모터
int servoPin = 5;                                        // PWM 핀인 ~표시가 있는 핀에 연결


//블루투스 설정
SoftwareSerial BTSerial(BT_RXD, BT_TXD); // change this to fit the number of steps per revolution

//data 읽기 시작, 종료 상태 변수
bool isStart = false;   // 읽기 시작
bool isEnd = false;     // 읽기 종료
String resultStr = "";  // 최종 Data를 저장할 문자열

//불루투스에서 받은 값을 나눠서 넣을 값.
int sep = 0;            //직선, 원형, 혼합 운동을 결정하는 변수
int dis1 = 0;           //직선 운동의 거리 변수, 혼합 운동의 1번 직선 구간 거리 변수
int tim1 = 0;           //직선 운동의 시간 변수, 혼합 운동의 1번 직선 구간 시간 변수
int rad2 = 0;           //원형 운동의 반지름 변수, 혼합 운동의 회전 구간의 반지름 변수
int tim2 = 0;           //원형 운동의 시간 변수, 혼합 운동의 회전 구간의 시간 변수
int ang2 = 0;           //원형 운동의 각도 변수, 혼합 운동의 회전 구간의 각도 변수
int dis3 = 0;           //혼합 운동의 2번 직선 구간 거리 변수
int tim3 = 0;           //혼합 운동의 2번 직선 구간 시간 변수
int mod = 0;            //직진, 후진, 왕복 기능을 결정하는 변수

//서브모터 설정
Servo servo;           // Servo 클래스로 servo 객체 생성
int angle = 0;         // Servo 모터의 각도 (0~180)
int stAngle = 82;      //Servo 모터 직진용 각도, 82도가 직진, 사용하기 전에 기기마다 맞는 설정값을 입력해줘야 함
double ccAngle = 0;    // 원형 운동시 서브모터 각도, 어플에서 넘어온 값으로 변경됨
int tnAngle = 0;       // 혼합 운동시 서브모터 각도, 어플에서 넘어온 값으로 변경됨

//바퀴 데이터
int wheelRadius = 3;                            //바퀴 반지름
float wheelCircum = wheelRadius * 2 * 3.141592; // 바퀴 원주


//직선 운동시 필요 데이터를 계산하기 위한 변수
float stTurnNum = 0;              //회전수
float stStepPerRevolution = 0;    //step per revolution
float stSpeedNeed = 0;            //회전속도(rpm)을 구하기 위해 필요한 변수
float stStepSpeed = 0;            //회전속도(rpm)

//원형 운동시 필요 데이터를 계산하기 위한 변수
float ccTurnNum = 0;            //회전수
float ccDis = 0;                //회전 이동거리
float ccStepPerRevolution = 0;  //step per revolution
float ccSpeedNeed = 0;          //회전속도(rpm)을 구하기 위해 필요한 변수
float ccStepSpeed = 0;          //회전속도(rpm)

//직선 운동3에 필요한 데이터를 계산하기 위한 변수
int stTurnNum3 = 0;             //회전수
int stStepPerRevolution3 = 0;   //step per revolution
int stSpeedNeed3 = 0;           //회전속도(rpm)을 구하기 위해 필요한 변수
int stStepSpeed3 = 0;           //회전속도(rpm)

//몸체 데이터
float bodylength = 10; // 몸체 세로 길이. 회전각을 구할 때에 필요

//,를 찾아내기 위한 변수
int first = 0;
int second = 0;
int third = 0;
int fourth = 0;
int fifth = 0;
int sixth = 0;
int seventh = 0;
int eighth = 0;

//회전에 필요한 데이터
int turnAngle = 0;
float turnData = 0;

void setup() {
  //통신 설정
  Serial.begin(9600);     //컴퓨터와의 통신속도 설정
  BTSerial.begin(9600);   //블루투스와의 통신속도 설정

  //Servo 모터 핀 설정
  servo.attach(servoPin); //servoPin 데이터는 위에 표기
}

void loop() {

  if (BTSerial.available()) {
    while (1) {
      char val = BTSerial.read();   //블루투스 데이터를 받아와 val변수에 삽입

      //데이터 읽기 시작
      if (val == '<') {
        Serial.println("start");
        resultStr = ""; // 최종 Data 문자열 초기화
        isStart = true;
        isEnd = false;
        continue;   // while문으로 바로 이동
      }
      // 데이터 읽기 종료
      else if (val == '>') {
        Serial.println("end");
        isEnd = true;
        break;
      }
      // 중간 데이터값을 최종 Data 문자열에 추가
      else {
        resultStr = String(resultStr + val);
      }
    }

    //시작 부호와 종료 부호가 들어왔다면
    if (isStart == true && isEnd == true) {
      Serial.print("전송된 데이터 : ");
      Serial.println(resultStr);

      //컴마 기호 파악
      first = resultStr.indexOf(",");
      second = resultStr.indexOf(",", first + 1);
      third = resultStr.indexOf(",", second + 1);
      fourth = resultStr.indexOf(",", third + 1);
      fifth = resultStr.indexOf(",", fourth + 1);
      sixth = resultStr.indexOf(",", fifth + 1);
      seventh = resultStr.indexOf(",", sixth + 1);
      eighth = resultStr.indexOf(",", seventh + 1);
    }

    //컴마 위치를 파악하고 싶을 때 아래 주석을 해제하세요
    /*
      Serial.print("first : ");
      Serial.println(first);
      Serial.print("second : ");
      Serial.println(second);
      Serial.print("third : ");
      Serial.println(third);
      Serial.print("fourth : ");
      Serial.println(fourth);
      Serial.print("fifth : ");
      Serial.println(fifth);
      Serial.print("sixth : ");
      Serial.println(sixth);
      Serial.print("seventh : ");
      Serial.println(seventh);
      Serial.print("eighth : ");
      Serial.println(eighth);
      Serial.print("length : ");
      Serial.println(strlength);
    */

    //문자열 나누기
    String sepS = resultStr.substring(0, first);              //직선, 원형, 회전 중 어떤 것인지 알려주는 데이터
    String dis1S = resultStr.substring(first + 1, second);    //직선 운동에 필요한 거리 값
    String tim1S = resultStr.substring(second + 1, third);    //직선 운동에 필요한 시간 값
    String rad2S = resultStr.substring(third + 1, fourth);    //원형 운동에 필요한 반지름 값
    String tim2S = resultStr.substring(fourth + 1, fifth);    //원형 운동에 필요한 시간 값
    String ang2S = resultStr.substring(fifth + 1, sixth);      //원형 운동에 필요한 각도 값
    String dis3S = resultStr.substring(sixth + 1, seventh);    //회전 운동에 필요한 2번째 직선운동 거리 값
    String tim3S = resultStr.substring(seventh + 1, eighth);    //회전 운동에 필요한 2번째 직선운동 시간 값
    String modS = resultStr.substring(eighth + 1);              //직진, 후진, 왕복 중 어떤 것인지 알려주는 데이터

    //문자열을 int형 인자로 변환
    sep = sepS.toInt();
    dis1 = dis1S.toInt();
    tim1 = tim1S.toInt();
    rad2 = rad2S.toInt();
    tim2 = tim2S.toInt();
    ang2 = ang2S.toInt();
    dis3 = dis3S.toInt();
    tim3 = tim3S.toInt();
    mod = modS.toInt();

    //잘라낸 값들이 잘 들어갔나 확인하려면 주석을 해제하세요
    /*
      Serial.print("seperate : ");
      Serial.println(sep);
      Serial.print("distance1 : ");
      Serial.println(dis1);
      Serial.print("time1 : ");
      Serial.println(tim1);
      Serial.print("radius2 : ");
      Serial.println(rad2);
      Serial.print("time2 : ");
      Serial.println(tim2);
      Serial.print("angle2 : ");
      Serial.println(ang2);
      Serial.print("distance3 : ");
      Serial.println(dis3);
      Serial.print("time3 : ");
      Serial.println(tim3);
      Serial.print("mode : ");
      Serial.println(mod);
    */

    //다음 불루투스 값을 받아들이기 위한 변수 초기화
    isStart = false;
    isEnd = false;

    //직선 운동
    if (sep == 2) {
      //Serial.println("직선 운동 모드로 설정되었습니다.");

      //직선운동에서 서브모터 각도 수정
      servo.write(stAngle);    //변수 값으로 고정했습니다. 장치 개발 후 수정이 필요합니다.
      delay(500);              //서브모터가 돌고 바로 스텝모터가 도는 것을 방지하기 위해 잠깐의 텀을 둡니다.

      //직선운동 스텝모터 작동에 필요한 값 계산
      stTurnNum = (float)dis1 / wheelCircum;           //회전수
      stSpeedNeed = stTurnNum * 60;                    //계산과정 추후에 정리
      stStepPerRevolution = (float)stTurnNum * stepsPerRevolution;    //모터 한바퀴가 2048step이기 때문에 stepsPerRevolution을 곱함
      stStepSpeed = (float)stSpeedNeed / tim1;         //회전속도(rpm)

      //회전수, step per revolution, 회전속도(rpm)을 확인하려면 주석을 해제하세요
      /*
        Serial.print("직진 운동에서의 회전수 : ");
        Serial.println(stTurnNum);
        Serial.print("직진 운동에서의 step per revolution : ");
        Serial.println(stStepPerRevolution);
        Serial.print("직진 운동에서의 회전속도(rpm) : ");
        Serial.println(stStepSpeed);
      */

      //직진모드
      if (mod == 0) {
        //Serial.println("직선운동의 직진모드가 시작되었습니다.");
        goForward(stStepSpeed, stStepPerRevolution);
      }

      //후진모드
      else if (mod == 1) {
        //Serial.println("직선운동의 후진모드가 시작되었습니다.")
        goBackward(stStepSpeed, stStepPerRevolution);
      }

      //왕복모드
      else if (mod == 2) {
        //Serial.println("직선운동의 왕복모드가 시작되었습니다.");
        goForward(stStepSpeed, stStepPerRevolution);
        goBackward(stStepSpeed, stStepPerRevolution);
      }
    }

    //원형 운동
    else if (sep == 3) {

      //Serial.println("원형 운동 모드로 설정되었습니다.");

      // 서보모터 회전각도 계산
      // 계산과정은 나중에 따로 정리하겠습니다. 
      turnData = (float)rad2 / bodylength;
      ccAngle = 180 - 2 * atan(turnData);

      //서보모터 회전
      servo.write(ccAngle);     //서보모터 각도 설정
      delay(500);               //서브모터가 돌고 바로 스텝모터가 도는 것을 방지하기 위해 잠깐의 텀을 둡니다.

      //스텝모터 관련 계산
      ccDis = (float)0.01756 * ang2 * rad2;           //회전 이동거리
      ccTurnNum = (float)ccDis / wheelCircum;        //회전수. 회전수는 이동거리 나누기 바퀴 원주
      ccStepPerRevolution = (float)ccTurnNum * stepsPerRevolution;   //step per revolution
      ccSpeedNeed = ccTurnNum * 60;                  //회전속도(rpm)을 구하기 위해 필요한 변수
      ccStepSpeed = (float)ccSpeedNeed / tim2;        //회전속도(rpm)

      //회전 이동거리, 회전수, step per revolution, 회전속도를 확인하려면 주석을 해제하세요.
      /*
        Serial.print("회전이동거리 : ");
        Serial.println(ccDis);
        Serial.print("회전수");
        Serial.println(ccTurnNum);
        Serial.print("step per revolution : ");
        Serial.println(ccStepPerRevolution);
        Serial.print("회전속도 : ");
        Serial.println(ccStepSpeed);
      */

      //직진모드
      if (mod == 0) {
        //Serial.println("원형운동의 직진모드가 시작되었습니다.");
        goForward(stStepSpeed, stStepPerRevolution);
      }

      //후진모드
      else if (mod == 1) {
        //Serial.println("원형운동의 후진모드가 시작되었습니다.");
        goBackward(stStepSpeed, stStepPerRevolution);
      }

      //왕복모드
      else if (mod == 2) {
        //Serial.println("원형운동의 왕복모드가 시작되었습니다.");
        goForward(stStepSpeed, stStepPerRevolution);
        goBackward(stStepSpeed, stStepPerRevolution);
      }
    }

    //회전운동 모드
    else if (sep == 4) {

      //직선운동1 스텝모터 작동에 필요한 값 계산
      stTurnNum = (float)dis1 / wheelCircum;        //회전수
      stSpeedNeed = stTurnNum * 60;                //계산과정 추후에 정리
      stStepPerRevolution = (float)stTurnNum * stepsPerRevolution; //모터 한바퀴가 2048step이기 때문에 stepsPerRevolution을 곱함
      stStepSpeed = (float)stSpeedNeed / tim1;      //회전속도(rpm)

      //회전수, step per revolution, 회전속도(rpm)을 확인하려면 주석을 해제하세요
      /*
        Serial.print("직진 운동1에서의 회전수 : ");
        Serial.println(stTurnnum);
        Serial.print("직진 운동1에서의 step per revolution : ");
        Serial.println(stStepPerRevolution);
        Serial.print("직진 운동1에서의 회전속도(rpm) : ");
        Serial.println(stStepSpeed);
      */

      //스텝모터 회전 관련 계산
      ccDis = (float)0.01756 * ang2 * rad2;           //회전 이동거리
      ccTurnNum = (float)ccDis / wheelCircum;        //회전수. 회전수는 이동거리 나누기 바퀴 원주
      ccStepPerRevolution = (float)ccTurnNum * stepsPerRevolution;   //step per revolution
      ccSpeedNeed = ccTurnNum * 60;                  //회전속도(rpm)을 구하기 위해 필요한 변수
      ccStepSpeed = (float)ccSpeedNeed / tim2;        //회전속도(rpm)

      //회전 이동거리, 회전수, step per revolution, 회전속도를 확인하려면 주석을 해제하세요.
      /*
        Serial.print("회전이동거리 : ");
        Serial.println(ccDis);
        Serial.print("회전수");
        Serial.println(ccTurnNum);
        Serial.print("step per revolution : ");
        Serial.println(ccStepPerRevolution);
        Serial.print("회전속도 : ");
        Serial.println(ccStepSpeed);
      */

      //직선운동3 스텝모터 작동에 필요한 값 계산
      stTurnNum3 = (float)dis3 / wheelCircum;        //회전수
      stSpeedNeed3 = stTurnNum * 60;                //계산과정 추후에 정리
      stStepPerRevolution3 = (float)stTurnNum * stepsPerRevolution; //모터 한바퀴가 2048step이기 때문에 stepsPerRevolution을 곱함
      stStepSpeed3 = (float)stSpeedNeed / tim3;      //회전속도(rpm)

      //회전수, step per revolution, 회전속도(rpm)을 확인하려면 주석을 해제하세요
      /*
        Serial.print("직진 운동3에서의 회전수 : ");
        Serial.println(stTurnnum3);
        Serial.print("직진 운동3에서의 step per revolution : ");
        Serial.println(stStepPerRevolution3);
        Serial.print("직진 운동3에서의 회전속도(rpm) : ");
        Serial.println(stStepSpeed3);
      */


      //직진모드
      if (mod == 0) {
        //Serial.println("회전 운동 직진모드로 설정되었습니다.");

        //직진1
        //직선운동에서 서브모터 각도 수정
        servo.write(stAngle);    //변수 값으로 고정했습니다. 장치 개발 후 수정이 필요합니다.
        delay(500);              //서브모터가 돌고 바로 스텝모터가 도는 것을 방지하기 위해 잠깐의 텀을 둡니다.

        //직선운동에서 스텝모터 움직임
        goForward(stStepSpeed, stStepPerRevolution);

        //회전
        // 계산과정은 나중에 따로 정리하겠습니다.
        turnData = (float)rad2 / bodylength;
        ccAngle = 180 - 2 * atan(turnData);

        //서보모터 회전
        for (int i = 0; i < ccAngle; i++) {
          turnAngle += 1;
          servo.write(turnAngle);     //서보모터 각도 설정
        }

        //스텝모터 관련 계산
        ccDis = (float)0.01756 * ang2 * rad2;           //회전 이동거리
        ccTurnNum = (float)ccDis / wheelCircum;        //회전수. 회전수는 이동거리 나누기 바퀴 원주
        ccStepPerRevolution = (float)ccTurnNum * stepsPerRevolution;   //step per revolution
        ccSpeedNeed = ccTurnNum * 60;                  //회전속도(rpm)을 구하기 위해 필요한 변수
        ccStepSpeed = (float)ccSpeedNeed / tim2;        //회전속도(rpm)

        goForward(ccStepSpeed, ccStepPerRevolution);

        // 직진3
        //직선운동에서 서브모터 각도 수정
        servo.write(stAngle);    //변수 값으로 고정했습니다. 장치 개발 후 수정이 필요합니다.
        delay(500);              //서브모터가 돌고 바로 스텝모터가 도는 것을 방지하기 위해 잠깐의 텀을 둡니다.

        goForward(stStepSpeed, stStepPerRevolution);
      }

      if (mod == 1) {
        //Serial.println("회전 운동 후진모드로 설정되었습니다.");
        //직진1
        //직선운동에서 서브모터 각도 수정
        servo.write(stAngle);    //변수 값으로 고정했습니다. 장치 개발 후 수정이 필요합니다.
        delay(500);              //서브모터가 돌고 바로 스텝모터가 도는 것을 방지하기 위해 잠깐의 텀을 둡니다.

        //직선운동에서 스텝모터 움직임
        goBackward(stStepSpeed, stStepPerRevolution);

        //회전
        //계산과정은 나중에 따로 정리하겠습니다.
        turnData = (float)rad2 / bodylength;
        ccAngle = 180 - 2 * atan(turnData);

        //서보모터 회전
        for (int i = ccAngle; i > 0; i--) {
          turnAngle -= 1;
          servo.write(turnAngle);     //서보모터 각도 설정
        }


        //스텝모터 관련 계산
        ccDis = (float)0.01756 * ang2 * rad2;           //회전 이동거리
        ccTurnNum = (float)ccDis / wheelCircum;        //회전수. 회전수는 이동거리 나누기 바퀴 원주
        ccStepPerRevolution = (float)ccTurnNum * stepsPerRevolution;   //step per revolution
        ccSpeedNeed = ccTurnNum * 60;                  //회전속도(rpm)을 구하기 위해 필요한 변수
        ccStepSpeed = (float)ccSpeedNeed / tim2;        //회전속도(rpm)

        goBackward(ccStepSpeed, ccStepPerRevolution);

        // 직진3
        //직선운동에서 서브모터 각도 수정
        servo.write(stAngle);    //변수 값으로 고정했습니다. 장치 개발 후 수정이 필요합니다.
        delay(500);              //서브모터가 돌고 바로 스텝모터가 도는 것을 방지하기 위해 잠깐의 텀을 둡니다.

        goBackward(stStepSpeed, stStepPerRevolution);
      }

      else if (mod == 2) {
        //Serial.println("회전 운동 왕복모드 직진부로 설정되었습니다.");

        //직진1
        //직선운동에서 서브모터 각도 수정
        servo.write(stAngle);    //변수 값으로 고정했습니다. 장치 개발 후 수정이 필요합니다.
        delay(500);              //서브모터가 돌고 바로 스텝모터가 도는 것을 방지하기 위해 잠깐의 텀을 둡니다.

        //직선운동에서 스텝모터 움직임
        goForward(stStepSpeed, stStepPerRevolution);

        //회전
        // 계산과정은 나중에 따로 정리하겠습니다.
        turnData = (float)rad2 / bodylength;
        ccAngle = 180 - 2 * atan(turnData);

        //서보모터 회전
        for (int i = 0; i < ccAngle; i++) {
          turnAngle += 1;
          servo.write(turnAngle);     //서보모터 각도 설정
        }

        //스텝모터 관련 계산
        ccDis = (float)0.01756 * ang2 * rad2;           //회전 이동거리
        ccTurnNum = (float)ccDis / wheelCircum;        //회전수. 회전수는 이동거리 나누기 바퀴 원주
        ccStepPerRevolution = (float)ccTurnNum * stepsPerRevolution;   //step per revolution
        ccSpeedNeed = ccTurnNum * 60;                  //회전속도(rpm)을 구하기 위해 필요한 변수
        ccStepSpeed = (float)ccSpeedNeed / tim2;        //회전속도(rpm)

        goForward(ccStepSpeed, ccStepPerRevolution);

        // 직진3
        //직선운동에서 서브모터 각도 수정
        servo.write(stAngle);    //변수 값으로 고정했습니다. 장치 개발 후 수정이 필요합니다.
        delay(500);              //서브모터가 돌고 바로 스텝모터가 도는 것을 방지하기 위해 잠깐의 텀을 둡니다.

        goForward(stStepSpeed, stStepPerRevolution);

        //Serial.println("회전 운동 왕복모드 후진부로 설정되었습니다.");
        //직진1
        //직선운동에서 서브모터 각도 수정
        servo.write(stAngle);    //변수 값으로 고정했습니다. 장치 개발 후 수정이 필요합니다.
        delay(500);              //서브모터가 돌고 바로 스텝모터가 도는 것을 방지하기 위해 잠깐의 텀을 둡니다.

        //직선운동에서 스텝모터 움직임
        goBackward(stStepSpeed, stStepPerRevolution);

        //회전
        // 계산과정은 나중에 따로 정리하겠습니다.
        turnData = (float)rad2 / bodylength;
        ccAngle = 180 - 2 * atan(turnData);

        //서보모터 회전
        for (int i = ccAngle; i > 0; i--) {
          turnAngle -= 1;
        }
        servo.write(turnAngle);     //서보모터 각도 설정

        //스텝모터 관련 계산
        ccDis = (float)0.01756 * ang2 * rad2;           //회전 이동거리
        ccTurnNum = (float)ccDis / wheelCircum;        //회전수. 회전수는 이동거리 나누기 바퀴 원주
        ccStepPerRevolution = (float)ccTurnNum * stepsPerRevolution;   //step per revolution
        ccSpeedNeed = ccTurnNum * 60;                  //회전속도(rpm)을 구하기 위해 필요한 변수
        ccStepSpeed = (float)ccSpeedNeed / tim2;        //회전속도(rpm)

        goBackward(stStepSpeed, stStepPerRevolution);

        // 직진3
        //직선운동에서 서브모터 각도 수정
        servo.write(stAngle);    //변수 값으로 고정했습니다. 장치 개발 후 수정이 필요합니다.
        delay(500);              //서브모터가 돌고 바로 스텝모터가 도는 것을 방지하기 위해 잠깐의 텀을 둡니다.

        goBackward(stStepSpeed, stStepPerRevolution);

      }


    }
    //변수초기화 혹시 몰라서 넣어봅니다.
    turnAngle = 0;
  }
}
void goForward(float a, int b) {
  rightStepper.setSpeed(a);
  leftStepper.setSpeed(a);
  for (int i = 0; i < b; i++) {
    rightStepper.step(1);
    leftStepper.step(-1);
  }
}

void goBackward(float c, int d) {
  rightStepper.setSpeed(c);
  leftStepper.setSpeed(c);
  for (int i = 0; i < d; i++) {
    rightStepper.step(-1);
    leftStepper.step(1);
  }
}
