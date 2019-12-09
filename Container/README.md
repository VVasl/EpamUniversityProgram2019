<H1>Task:</H1>
<p>1) To create Dependency Injection/IoC Container;</p>
<p>2) Container should have ability to choose an appropriate lifetime for each registered service:
<p><b>Transient</b><p>
Transient lifetime services (RegisterTransient) are created each time they're requested from the service container.
 <p> <b>Singleton</b></p>
Singleton lifetime services (RegisterSingleton) are created the first time they're requested. Every subsequent request uses the same instance.<p>
<p>3) Container should implement factory pattern</p>
