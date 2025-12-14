# IK

Unity 기반의 FABRIK(Forward And Backward Reaching Inverse Kinematics) 알고리즘 프로젝트

## 주요 특징

- **효율적인 FABRIK 알고리즘 구현**: Forward와 Backward pass를 통한 빠른 IK 계산
- **계층적 체인 구조**: 복잡한 다중 체인 구조 지원
- **유연한 솔버 시스템**: 커스텀 솔버 확장 가능
- **실시간 계산**: LateUpdate에서 자동으로 IK 계산

## 프로젝트 구조
```
IK/
├── Assets/
│   ├── 3DModels/          # 3D 모델 리소스
│   ├── Characters/        # 캐릭터 리소스
│   ├── Scenes/           
│   │   └── SampleScene.unity  # 샘플 씬
│   ├── Scripts/
│   │   ├── Fabrik.cs          # 메인 FABRIK 컨트롤러
│   │   ├── FabrikChain.cs     # IK 체인 노드
│   │   ├── FabrikSolver.cs    # 솔버 베이스 클래스
│   │   ├── FootSolver.cs      # 발 IK 솔버 (예제)
│   │   ├── TestCode.cs        # 테스트 코드
│   │   └── Extensions/        # 확장 메서드
│   |
```
