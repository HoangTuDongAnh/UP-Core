# HTDA Framework – Core

Core is the foundation of HTDA Framework.

## Package Info
- Package: `com.htda.framework.core`
- Assembly: `HTDA.Framework.Core`
- Unity: `2022.3+`

## Included
- Framework identity: `CoreInfo`
- Logging facade: `HTDALog`, `ILogSink`, `UnityLogSink`
- Result types: `Result`, `Result<T>`
- Guard utilities: `Guard`
- Lifecycle contracts: `IInitializable`, `ITickable`, `IShutdown`
- Minimal event bus: `IEventBus`, `EventBus`

## Not included (by design)
No pooling, state machines, IO helpers, editor tools, or feature-heavy utilities.