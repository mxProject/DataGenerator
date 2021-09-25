


# IDataGeneratorFieldEnumeration Interface



Provides the required functionality for a data generator field.






## Inheritance tree
## Implemented interfaces
* System.IDisposable

[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldName](#fieldname-property) | string | Gets the field name. |
| public | [ValueType](#valuetype-property) | Type | Gets the value type. |
---
### FieldName Property

Gets the field name.
```c#
string FieldName { get; }
```

[Go to properties](#Properties)

---
### ValueType Property

Gets the value type.
```c#
Type ValueType { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [GenerateNext](#generatenext-method) | bool | Generates the next new value. |
| public | [GetRawValue](#getrawvalue-method) | object | Gets the generated value. |
| public | [GetValue](#getvalue-method) | object | Gets the generated value. The value is converted to a well-known type. |
| public | [IsNullValue](#isnullvalue-method) | bool | Gets a value that indicates whether the generated value is null. |
| public | [Reset](#reset-method) | void | Resets the status of data generation processing. |
---
### GenerateNext Method

Generates the next new value.
```c#
bool GenerateNext()
```
#### Return type


[Go to methods](#Methods)

---
### GetRawValue Method

Gets the generated value.
```c#
object GetRawValue()
```
#### Return type


[Go to methods](#Methods)

---
### GetValue Method

Gets the generated value. The value is converted to a well-known type.
```c#
object GetValue()
```
#### Return type


[Go to methods](#Methods)

---
### IsNullValue Method

Gets a value that indicates whether the generated value is null.
```c#
bool IsNullValue()
```
#### Return type


[Go to methods](#Methods)

---
### Reset Method

Resets the status of data generation processing.
```c#
void Reset()
```

[Go to methods](#Methods)



