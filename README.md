# IK

Unity 기반의 FABRIK(Forward And Backward Reaching Inverse Kinematics) 알고리즘 프로젝트

---

## 🌎 README (다국어 버전)

<details>
<summary><strong>🇰🇷 한국어 (Korean)</strong></summary>

### IK

Unity 기반의 FABRIK(Forward And Backward Reaching Inverse Kinematics) 알고리즘 프로젝트

#### 주요 특징

* **효율적인 FABRIK 알고리즘 구현**: Forward와 Backward pass를 통한 빠른 IK 계산
* **계층적 체인 구조**: 복잡한 다중 체인 구조 지원
* **유연한 솔버 시스템**: 커스텀 솔버 확장 가능
* **실시간 계산**: LateUpdate에서 자동으로 IK 계산

#### 프로젝트 구조

```
IK/
├── Assets/
│   ├── 3DModels/          # 3D 모델 리소스
│   ├── Characters/        # 캐릭터 리소스
│   ├── Scenes/
│   │   └── SampleScene.unity  # 샘플 씬
│   ├── Scripts/
│   │   ├── Fabrik.cs          # 메인 FABRIK 컨트롤러
│   │   ├── FabrikChain.cs     # IK 체인 노드
│   │   ├── FabrikSolver.cs    # 솔버 베이스 클래스
│   │   ├── FootSolver.cs      # 발 IK 솔버 (예제)
│   │   ├── TestCode.cs        # 테스트 코드
│   │   └── Extensions/        # 확장 메서드
│   |
```

</details>

<details>
<summary><strong>🇯🇵 日本語 (Japanese)</strong></summary>

### IK

UnityベースのFABRIK (Forward And Backward Reaching Inverse Kinematics) アルゴリズムプロジェクト

#### 主な特徴

* **効率的なFABRIKアルゴリズムの実装**: ForwardとBackwardパスによる迅速なIK計算
* **階層的チェーン構造**: 複雑なマルチチェーン構造をサポート
* **柔軟なソルバーシステム**: カスタムソルバーの拡張が可能
* **リアルタイム計算**: LateUpdateで自動的にIKを計算

#### プロジェクト構造

```
IK/
├── Assets/
│   ├── 3DModels/          # 3Dモデルリソース
│   ├── Characters/        # キャラクターリソース
│   ├── Scenes/
│   │   └── SampleScene.unity  # サンプルシーン
│   ├── Scripts/
│   │   ├── Fabrik.cs          # メイン FABRIK コントローラー
│   │   ├── FabrikChain.cs     # IK チェーンノード
│   │   ├── FabrikSolver.cs    # ソルバー ベースクラス
│   │   ├── FootSolver.cs      # 足 IK ソルバー (例)
│   │   ├── TestCode.cs        # テストコード
│   │   └── Extensions/        # 拡張メソッド
│   |
```

</details>

<details>
<summary><strong>🇬🇧 English</strong></summary>

### IK

A Unity-based project implementing the FABRIK (Forward And Backward Reaching Inverse Kinematics) algorithm.

#### Key Features

* **Efficient FABRIK Algorithm Implementation**: Fast IK calculation through Forward and Backward passes.
* **Hierarchical Chain Structure**: Supports complex multi-chain systems.
* **Flexible Solver System**: Allows for extension with custom solvers.
* **Real-time Calculation**: Automatic IK calculation is performed in LateUpdate.

#### Project Structure

```
IK/
├── Assets/
│   ├── 3DModels/          # 3D Model Resources
│   ├── Characters/        # Character Resources
│   ├── Scenes/
│   │   └── SampleScene.unity  # Sample Scene
│   ├── Scripts/
│   │   ├── Fabrik.cs          # Main FABRIK Controller
│   │   ├── FabrikChain.cs     # IK Chain Node
│   │   ├── FabrikSolver.cs    # Solver Base Class
│   │   ├── FootSolver.cs      # Foot IK Solver (Example)
│   │   ├── TestCode.cs        # Test Code
│   │   └── Extensions/        # Extension Methods
│   |
```

</details>
