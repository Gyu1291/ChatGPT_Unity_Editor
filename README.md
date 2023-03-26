# AICommand

ChatGPT API를 활용해 자연어로 유니티 게임 씬을 변경하는 기능을 가진 Editor script

2022.2버전보다 낮은 유니티 버전을 사용하는 지인들에게 프로젝트를 공유하기 위한 목적의 repository이며
본래 코드는 https://github.com/keijiro/AICommand 에서 가져왔음.

이 repository의 경우 2022.2버전보다 낮은 유니티 버전을 사용하는 유저들을 위해 라이브러리 호환성 수정 작업을 거쳤고
코드의 에러 방지를 체크하기 위한 일부 추가적인 수정을 거칠 예정임

## 사용방법
1. Edit>ProjectSettings에서 발급받은 ChatGPT secret key 입력
https://platform.openai.com/account/api-keys
2. Windows>AICommand에서 커맨드 입력

현재 repository의 경우 일부 커맨드가 하드코딩 되어있는데 이 부분 역시 수정할 예정

## NullReferenceError가 발생하는 경우

Json response에서 error가 발생하는 경우로 보통 잘못된 request를 보낼 때 발생
1. ChatGPT API 만료 -> ChatGPT Pro 등록하기
2. UnityWebRequest로 byte가 아닌 string 전송하는 경우

## C# compile error
ChatGPT가 씬 동작을 위해 작성한 코드가 틀린 경우. 이 경우 특별히 답이 없으며 그렇기 때문에
이런 방식으로 ChatGPT를 활용하기 위해서는 코드의 신뢰성을 보장받을 수 있는 작업이 필요하다.

## Examples
![out](https://github.com/Gyu1291/ChatGPT_Unity_Editor/blob/dev/ChatGPTUnity.gif)
