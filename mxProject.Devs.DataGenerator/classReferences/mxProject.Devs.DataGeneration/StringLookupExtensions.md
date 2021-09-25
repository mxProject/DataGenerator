


# StringLookupExtensions Class



Extension methods for System.Linq.ILookup`2 .






## Inheritance tree
* object

[Methods](#Methods)&nbsp;&nbsp;





---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
## Static Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [AsStringValue(ILookup&lt;string, string&gt;)](#asstringvalueilookupstring-string-method) | ILookup&lt;StringValue, StringValue&gt; |  |
| public | [AsStringValue&lt;TValue&gt;(ILookup&lt;string, TValue&gt;)](#asstringvaluetvalueilookupstring-tvalue-method) | ILookup&lt;StringValue, TValue&gt; |  |
---
### AsStringValue(ILookup&lt;string, string&gt;) Method


```c#
public static ILookup<StringValue, StringValue> AsStringValue
(
	this ILookup<string, string> lookup
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| lookup | ILookup&lt;string, string&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### AsStringValue&lt;TValue&gt;(ILookup&lt;string, TValue&gt;) Method


```c#
public static ILookup<StringValue, TValue> AsStringValue<TValue>
(
	this ILookup<string, TValue> lookup
)
```
## Generic Parameters
|Name|Description|Constraints|
|:--|:--|:--|
| TValue |  |  |
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| lookup | ILookup&lt;string, TValue&gt; |  |  |
#### Return type


[Go to methods](#Methods)

---
### Equals(object) Method

Inherited from  System.Object .
```c#
public virtual bool Equals
(
	object obj
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| obj | object |  |  |
#### Return type


[Go to methods](#Methods)

---
### Finalize Method

Inherited from  System.Object .
```c#
protected virtual void Finalize()
```

[Go to methods](#Methods)

---
### GetHashCode Method

Inherited from  System.Object .
```c#
public virtual int GetHashCode()
```
#### Return type


[Go to methods](#Methods)

---
### GetType Method

Inherited from  System.Object .
```c#
public Type GetType()
```
#### Return type


[Go to methods](#Methods)

---
### MemberwiseClone Method

Inherited from  System.Object .
```c#
protected object MemberwiseClone()
```
#### Return type


[Go to methods](#Methods)

---
### ToString Method

Inherited from  System.Object .
```c#
public virtual string ToString()
```
#### Return type


[Go to methods](#Methods)



