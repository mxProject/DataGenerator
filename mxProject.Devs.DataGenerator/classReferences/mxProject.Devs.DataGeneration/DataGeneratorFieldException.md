


# DataGeneratorFieldException Class



Exception indicating that the field definition is incorrect.






## Inheritance tree
* System.Exception
* object
## Implemented interfaces
* System.Runtime.Serialization.ISerializable

[Constructors](#Constructors)&nbsp;&nbsp;
[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;
[Events](#Events)&nbsp;&nbsp;

---
## Constructors
|Scope|Signature|Summary|
|:--|:--|:--|
| public | [.ctor(string, string, Exception)](#ctorstring-string-exception-constructor) | Creates a new instance. |
| public | [.ctor(string, string[], Exception)](#ctorstring-string-exception-constructor) | Creates a new instance. |
---
### .ctor(string, string, Exception) Constructor

Creates a new instance.
```c#
public DataGeneratorFieldException(
	string message
	, string fieldName
	, Exception innerException
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| message | string | The message. |
| fieldName | string | The field name. |
| innerException | Exception | The inner exception. |

[Go to constructors](#Constructors)

---
### .ctor(string, string[], Exception) Constructor

Creates a new instance.
```c#
public DataGeneratorFieldException(
	string message
	, string[] fieldNames
	, Exception innerException
)
```
#### Parameters
|Name|Parameter Type|Description|
|:--|:--|:--|
| message | string | The message. |
| fieldNames | string[] | The field names. |
| innerException | Exception | The inner exception. |

[Go to constructors](#Constructors)


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [Data](#data-property) | IDictionary | Inherited from  System.Exception . |
| public | [FieldNames](#fieldnames-property) | string[] | Gets the field name. |
| public | [HelpLink](#helplink-property) | string | Inherited from  System.Exception . |
| public | [HResult](#hresult-property) | int | Inherited from  System.Exception . |
| public | [InnerException](#innerexception-property) | Exception | Inherited from  System.Exception . |
| public | [Message](#message-property) | string | Inherited from  System.Exception . |
| public | [Source](#source-property) | string | Inherited from  System.Exception . |
| public | [StackTrace](#stacktrace-property) | string | Inherited from  System.Exception . |
| public | [TargetSite](#targetsite-property) | MethodBase | Inherited from  System.Exception . |
---
### Data Property

Inherited from  System.Exception .
```c#
public virtual IDictionary Data { get; }
```

[Go to properties](#Properties)

---
### FieldNames Property

Gets the field name.
```c#
public string[] FieldNames { get; }
```

[Go to properties](#Properties)

---
### HelpLink Property

Inherited from  System.Exception .
```c#
public virtual string HelpLink { get; set; }
```

[Go to properties](#Properties)

---
### HResult Property

Inherited from  System.Exception .
```c#
public int HResult { get; set; }
```

[Go to properties](#Properties)

---
### InnerException Property

Inherited from  System.Exception .
```c#
public Exception InnerException { get; }
```

[Go to properties](#Properties)

---
### Message Property

Inherited from  System.Exception .
```c#
public virtual string Message { get; }
```

[Go to properties](#Properties)

---
### Source Property

Inherited from  System.Exception .
```c#
public virtual string Source { get; set; }
```

[Go to properties](#Properties)

---
### StackTrace Property

Inherited from  System.Exception .
```c#
public virtual string StackTrace { get; }
```

[Go to properties](#Properties)

---
### TargetSite Property

Inherited from  System.Exception .
```c#
public MethodBase TargetSite { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GetBaseException](#getbaseexception-method) | Exception | Inherited from  System.Exception . |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetObjectData(SerializationInfo, StreamingContext)](#getobjectdataserializationinfo-streamingcontext-method) | void | Inherited from  System.Exception . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Exception . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [ToString](#tostring-method) | string | Inherited from  System.Exception . |
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
### GetBaseException Method

Inherited from  System.Exception .
```c#
public virtual Exception GetBaseException()
```
#### Return type


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
### GetObjectData(SerializationInfo, StreamingContext) Method

Inherited from  System.Exception .
```c#
public virtual void GetObjectData
(
	SerializationInfo info
	, StreamingContext context
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| info | SerializationInfo |  |  |
| context | StreamingContext |  |  |

[Go to methods](#Methods)

---
### GetType Method

Inherited from  System.Exception .
```c#
public Type GetType()
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

Inherited from  System.Exception .
```c#
public virtual string ToString()
```
#### Return type


[Go to methods](#Methods)


---
## Events
|Scope|Name|EventHandler Type|Summary|
|:--|:--|:--|:--|
| protected | [SerializeObjectState](#serializeobjectstate-event) | EventHandler&lt;SafeSerializationEventArgs&gt; | Inherited from  System.Exception . |
---
### SerializeObjectState Event

Inherited from  System.Exception .

[Go to events](#Events)


