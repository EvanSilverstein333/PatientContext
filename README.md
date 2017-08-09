# PatientContext #

This project is a generic bounded context for managing patient information, which can easily be incorporated into any desktop or web application. The project supports CRUD operations for the following data: 
* Patient identity - name, date of birth, sex
* Patient visit - date, diagnosis
* Healthcard - health number, version code, expiry date

### Features ###

The project supports the following features:
* Logging
* Caching
* Performance metrics
* Optimistic concurrency

### Getting Started ###

This project uses 3 WCF services to enable communication with a given application. The PatientManagerCommandService and PatientManagerQueryService are located in [AbstractFactories directory](https://github.com/EvanSilverstein333/PatientContext/tree/master/Infrastructure/AbstractFactories), while an external service is used as a message bus. The 3 services are listed below.  
* PatientManagerCommandService - used for operations that change state (create, update, delete)
* PatientManagerQueryService - used for reading operations
* Publisher - a topic-based publisher that notifies listeners of events that occur

Communcation can be achieved with the following steps:

#### Step 1) - Configure services ####
Configuration for each of these services is located in [Services directory](https://github.com/EvanSilverstein333/PatientContext/tree/master/Infrastructure/Services), each of which can be customized to meet your requirements. Proceed to the next step when you are satisfied with your configuration.

#### Step 2) - Add contract assembly to your application
The contract assembly contains the components for communicating with the services. The contents of this assembly are located in [Contract directory](https://github.com/EvanSilverstein333/PatientContext/tree/master/Contract).

#### Step 3) - Add services to your application ####
Add the services to your application based on the binding configurations from Step 1 (for help on adding services: https://msdn.microsoft.com/en-us/library/cc636424(v=ax.50).aspx).  

### Examples ###
After completing the steps in the Getting Started section you are ready to use this project in your own application. An example of using each service is provided below.

#### PatientManagerCommandService ####
The components available to use with this service are provided in the [Commands directory](https://github.com/EvanSilverstein333/PatientContext/tree/master/Contract/Commands) of the Contract Assembly. For example (assuming a standard MVC client application):

```
public class PatientController : Controller
{
    using PatientManager.Contract.Dto;
    using PatientManager.Contract.Commands;
    
    //other stuff
    
    public void UpdatePatient(PatientDto patient)
    {
        var command = new UpdatePatientCommand(patient);
        var service = new PatientManagerCommandProcessorClient();
        service.Submit(command);
    }
}
```

#### PatientManagerQueryService ####
The components available to use with this service are provided in the [Queries directory](https://github.com/EvanSilverstein333/PatientContext/tree/master/Contract/Queries) of the Contract Assembly. For example (assuming a standard MVC client application):

```
public class PatientController : Controller
{
    using PatientManager.Contract.Dto;
    using PatientManager.Contract.Queries;
    
    //other stuff
    
    public PatientDto GetPatient(Guid patientId)
    {
        var query = new GetPatientByIdQuery(patientId);
        var service = new PatientManagerQueryProcessorClient();
        var patient = service.Submit(query);
        return patient as PatientDto;
    }
}
```

#### Publisher ####
The Publisher service is configured as a duplex channel with 1-way communication to notify all listeners of a specific event when that event occurs. Each listener may subscribe to 1 or muliple events. A listener is established by implementing the "IPublisherCallback" contract, which can be found in the namespace created upon adding the Publisher service. The IPublisherCallback contract is defined by the following 2 methods:
* public static void SubscribeToMessages() - this should be called once at the start of your application to begin listening to events
* public void MessageHandler(MessageWrapper messageWrapper) - this is called each time the publisher notifies the listener of an event

The components available to use with this service are provided in the [Events directory](https://github.com/EvanSilverstein333/PatientContext/tree/master/Contract/Events) of the Contract Assembly. For example:
```
public class PatientManagerMessageCallback : IPublisherCallback
{
    using System.ServiceModel;  //required for InstanceContext (duplex channel) 
    using PatientManger.Contract.Events; 
    
    
    public static void SubscribeToMessages()
    {
        private static InstanceContext context = new InstanceContext(this) 
        var publisher = new PublisherClient(context);
        publisher.Subscribe(PatientRemovedEvent);
        publisher.Subscribe(PatientIdentityChangedEvent);
    }

    public void MessageHandler(MessageWrapper messageWrapper)
    {

        var eventType = messageWrapper.Message.GetType();
        if(eventType == typeof(PatientRemovedEvent))
        {
            //do something
        }
        else
        {
            //do something else
        }
    }
}
```

### Installation ###
This repo contains a setup project for installation on a local machine. It is currently configured to be installed as a windows service, which will run automatically when the local machine starts up.

### Authors ###

* Evan Silverstein
