**Reflection**
We call “reflection” the ability that some programming languages have to inspect their own constructs dynamically. 
* It is used to inspect the program during run time. 
* Eg : Unit Testing. 
* It follows the below heirarchy:
* Assemblies contain modules
* Modules contain types
* Types contain members

* Assembly is complied code in C#
* Modules individual complied files in .exe and .dll format
* Types are class, interface, delegates, methoda, etc..

**Workflow**
1) Attributes\ RunnableAttribute.cs
* namespace : used to grp code logically
* namespace ReflectionRunner.Attribute => belongs to namespace of ReflectionRunner within that Attribute field.
* AttributeUsage defines a custom Attribute.
* AttributeTargets.Method => can be applicable for methods only

2) Tasks\ Task1.cs &&  Task2.cs
* Few methods have [Runnable] attribute to trigger their execution during runtime.

3) Services\ Runner.cs
* STEP 1: fetch all types from the assembly.
var assembly = Assembly.GetExecutingAssembly();
var types = assembly.GetTypes();

* STEP2: find all methods with Runnable Attribute and store it in a list.
var methods = type.GetMethods().Where(m => m.GetCustomAttributes(typeof(RunnableAttribute), false).Any()).ToList();

* STEP3: Check whether the method is static (no obj) or instance (requies obj for execution) and invoke the method

* instance ??= Activator.CreateInstance(type);
?? => null coalescing assignment operator. Creates an obj and reuse it.