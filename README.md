# UP-Core (HTDA.Framework.Core)

UP-Core là nền tảng dùng chung cho toàn bộ framework: log/diagnostics, lifecycle primitives và các pattern nhẹ (Singleton/Command/Service/Factory/Strategy/Decorator).

## Thành phần chính

- **Diagnostics**
    - `HTDALog`, `ILogSink`, `UnityLogSink`
- **LifeCycle**
    - `IInitializable`, `ITickable`, `IShutdown`
    - Singleton:
        - `Singleton<T>` (pure C#)
        - `MonoSingleton<T>`
        - `PersistentMonoSingleton<T>`
- **Primitives**
    - Command:
        - `ICommand`, `CommandHistory`, `CompositeCommand`
    - Service:
        - `ServiceRegistry`
    - Factory:
        - `IFactory<T>`, `IFactory<TIn,TOut>`, `FactoryRegistry<TKey,T>`
    - Strategy:
        - `IStrategy<TContext,TResult>`, `StrategySelector<TContext,TResult>`
    - Decorator:
        - `IDecorator<T>`, `DecoratorChain<T>`

## Cài đặt

Add package local / git như bình thường. UP-Core không có Sample.

## Ví dụ nhanh

### Singleton (Mono)
```csharp
public sealed class AudioManager : PersistentMonoSingleton<AudioManager>
{
    protected override void OnSingletonAwake()
    {
        // init
    }
}
```

### Command (Undo/Redo)
```csharp
var history = new CommandHistory();
history.Do(new SwapTilesCommand(board, a, b));
history.Undo();
history.Redo();
```

### ServiceRegistry (khuyên dùng cho bootstrap)
```csharp
var services = new ServiceRegistry();
services.Register<ISceneLoader>(loader);
var sceneLoader = services.Get<ISceneLoader>();
```

## Notes

- UP-Core cố tình **tối giản**, không DI container nặng, không MVP framework.
- Các module khác (Events/Pooling/FSM/SceneFlow) nên reference UP-Core để dùng primitives.
