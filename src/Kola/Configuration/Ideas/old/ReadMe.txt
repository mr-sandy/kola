1. Split configuration into two:
 - config for the engine (which is used to initialise the ending during the bootstrap)
 - config for the hosting setup (which is returned by the bootstrapper)

 Should the configs be immutable?  Will refactoring mutable bits out spoil the plugin stuff?

 Perhaps the KolaRegistry shouold have an abstraction for an IOC container rather than holding the engine?  
 How do I intend to instantiate the various handlers without an IOC?