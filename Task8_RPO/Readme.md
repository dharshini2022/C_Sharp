**1. Generic Classes**
A generic class is a class that takes a type parameter within angle brackets (< >) so that the class can operate on different data types while maintaining compile-time type safety.

**Advantages**
* Type Safety: Detect type errors at compile-time instead of runtime.
* Code Reusability: Write a single class or method that works with multiple data types.
* Performance: Avoids boxing/unboxing in value types, improving execution speed.

**Example:**
class ClassName<T>{

}
* Here T refers to the placeholder for type parameter which is specified during the object creation time.
* T refers to 1 parameter only. It is not like **args in python.

**2. Interfaces**
* It provides complete abstraction with only abstracted methods and no fields.
* By default the methods are abstracted (no body) and public.
* It can't be instantiated. (no object)
* It is implemented by child class using (:)
