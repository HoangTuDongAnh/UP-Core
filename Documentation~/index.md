# UP-Core – Documentation

## 1. Mục tiêu

- Cung cấp các **primitive** và **pattern nhẹ** dùng xuyên project/game.
- Tránh over-engineer: không reflection scan, không container nặng, dễ debug.

## 2. Diagnostics

### HTDALog
- Wrapper log cho phép thay `ILogSink`.
- `UnityLogSink` là sink mặc định cho Unity Console.

Khuyến nghị:
- Dùng log level / tag nếu bạn mở rộng.
- Giữ log API nhỏ để tránh phụ thuộc.

## 3. LifeCycle primitives

- `IInitializable`: khởi tạo
- `ITickable`: tick theo dt
- `IShutdown`: shutdown

Các interface này hữu ích khi bạn muốn tự build game loop / service loop.

## 4. Singleton

### Khi nào dùng
- Service nhỏ, tồn tại xuyên scene: Audio, Save, Analytics…
- Tránh dùng singleton cho object gameplay ngắn hạn.

### Bộ singleton trong Core
- `Singleton<T>`: pure C# (không Unity)
- `MonoSingleton<T>`: singleton cho MonoBehaviour, auto-create nếu chưa có.
- `PersistentMonoSingleton<T>`: tự `DontDestroyOnLoad`.

## 5. Command (Puzzle-friendly)

Command mini là lựa chọn rất hợp cho puzzle:
- Mỗi move = 1 command
- Undo/Redo dễ và sạch

### ICommand
- `CanExecute()`
- `Execute()`
- `Undo()`

### CommandHistory
- `Do(cmd)`, `Undo()`, `Redo()`, `Clear()`

## 6. ServiceRegistry

- Registry theo type, O(1) lookup.
- Dùng để giảm phụ thuộc singleton (nhất là ở bootstrap).
- Có thể dùng chung với SceneFlow `GameBootstrap.Services`.

## 7. Factory / Strategy / Decorator

Các module này chỉ gồm interface + helper nhỏ:

- Factory: chuẩn hoá tạo object theo interface
- Strategy: chuẩn hoá thuật toán thay đổi theo context
- Decorator: chain modifier (score/damage/rule modifiers)

## 8. Quy ước đặt namespace / folder

Khuyến nghị:
- Không đưa các module “hệ thống” nặng vào Core.
- Giữ `Primitives/*` là nơi đặt các pattern nhẹ, dễ tái dùng.
