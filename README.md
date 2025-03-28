# InputController
ゲームパッドを入力してAruduinoを操作する
# 🎮 Gamepad to LED Matrix Controller

## 🚀 概要

ゲームパッドの入力をPCで受け取り、その信号をArduinoへ送信して**LEDマトリックスをリアルタイムで操作**するプロジェクトです。

**C# (Windowsアプリ) × Arduino × ハード制御**の連携を学びながら、\
入力デバイス → PC → マイコン → ハード制御 までを一貫して実装しました。

---

## 🛠️ 使用技術・構成

- **C# (.NET) + Visual Studio**
  - ゲームパッド入力の取得
  - Arduinoへのシリアル通信
- **Arduino R4 Wifi**
  - LEDマトリックス制御
  - シリアル通信受信
- **12×8 LED Matrix**
- **ゲームパッド（XInput対応）**

---

## 💻 プロジェクト構成

```
GamepadToLEDMatrix/
🔗 README.md
🔗 /InputController   # C# アプリ (Visual Studioプロジェクト)
🔗 /ArduinoSketch     # Arduino スケッチ (.inoファイル)
```

---

## ⚙️ セットアップ方法

### 1. Arduino側

1. `/ArduinoSketch/led_matrix_controller.ino` を Arduino IDEで開く
2. Arduino R4 Wifiにスケッチを書き込み

### 2. C#アプリ側

1. `/CSharpApp/` フォルダを Visual Studioで開く
2. NuGetパッケージ Install-Package SharpDX.XInput
3. ビルド → 実行
4. ゲームパッドを接続し、操作開始

---

## 💡 学習ポイント

- C#での**XInput制御**と**シリアル通信**
- Arduinoでの**リアルタイム受信処理**
- PC ↔ ハードウェア間のデータ連携
- 入力デバイス → アウトプットデバイスの設計・実装

---

## 📄 ライセンス

このプロジェクトは MITライセンス です。

