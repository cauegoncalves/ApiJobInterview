# Interview - Technical Assignment - Caue Gonçalves dos Santos #

This project was created to answer a technical assignment for a IT company based on Netherlands. The purpose of the project was to present my skills as a Senior Software Engineer and how I would build a testable, maintanable and scalable application using design and architecture best practices.

* The [Assignment](docs/assignment.pdf) 

### **What have I applied in the project?**

- #### **Design Patterns**
    - **Singleton**: Used in the repository instance
    - **Abstract Factory**: Used to construct the product type*
    - **Facade**: Encapsulate the Order Service complexity (Save and Calculate)
    - **Strategy**: Choosing the right component for each infrastruture peace
    - **Repository**: Repository pattern to store and retrieve data

##### \* There are many ways to solve this problem, for example: using a EF In Memory, using a database. But considering the limited scope of the API and the purpose of the development, applying a design pattern will prove some OOP skill.


- #### **SOLID Principles**
    - **Single Responsability**: Each class and each method has one responsability.
    - **Open Close**: We can add new Product Types without impacting the existing ones.
    - **Dependency Inversion**: The repository, storage service and order service, the entire application is working with abstraction, not implementation. The responsible for inject the implementatios is the IoC project.

- #### **.Net Features**
    - **LINQ**: At the aggregation function in the storage service
    - **Dependency Injection**: Almost the entire project
    - **Dictionary**: Used as repository. O(1) of complexity.
    - **nUnit**: To test the projects

- #### **Packages**
    - **Log**: simple Serilog implementation to output logs to the console
    - **Health Checks**: simple health check implementation
    - **MVC Testing**: to perform API integrated tests

- #### **Testing**
    - **Unit tests**: In the class and components
    - **Integrated test**: In the API using HttpClient


### **How to run the API?**

Access the src/cgds.manufacture/cgds.manufacture.api and run the command:
```bash
dotnet run
```
Or open the project in Visual Studio and hit the Run button.

### **How to test the API?**
There are two routes on the API:

1) GET - /api/order/{orderId}
   - To obtain the order details, where {orderId} is the identifier (int) of the order.

2) POST - /api/order/
   - To include an order with items. *PS: An order will be replaced if a new order be POSTed with the same orderId. It's a feature, not a bug!*
```json
{
	"orderId": 1,
	"items": [
			{
				"productType": "photoBook",
				"quantity": 1
			},
			{
				"productType": "calendar",
				"quantity": 3
			},
			{
				"productType": "mug",
				"quantity": 5
			}
		]
}
```

---


Be safe and have a nice day.

---