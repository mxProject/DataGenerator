


# DataGenerator Class



DataGenerator.






## Inheritance tree
* object
## Implemented interfaces
* System.IDisposable

[Properties](#Properties)&nbsp;&nbsp;
[Methods](#Methods)&nbsp;&nbsp;


---
## Properties
|Scope|Name|Property Type|Summary|
|:--|:--|:--|:--|
| public | [FieldCount](#fieldcount-property) | int | Gets the field count. |
---
### FieldCount Property

Gets the field count.
```c#
public int FieldCount { get; }
```

[Go to properties](#Properties)




---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [AsDataReader](#asdatareader-method) | [IDataGenerationReader](../mxProject.Devs.DataGeneration/IDataGenerationReader.md) | Wrap as a DataReader. |
| public | [Dispose](#dispose-method) | void | Inherited from  [DataGenerator](../mxProject.Devs.DataGeneration/DataGenerator.md) . |
| protected | [Dispose(bool)](#disposebool-method) | void | Disposes the resources it is using. |
| public | [Equals(object)](#equalsobject-method) | bool | Inherited from  System.Object . |
| protected | [Finalize](#finalize-method) | void | Inherited from  System.Object . |
| public | [GenerateNext](#generatenext-method) | bool | Generates the next new value. |
| public | [GetFieldIndex(string)](#getfieldindexstring-method) | int | Gets the index of the specified field name. |
| public | [GetFieldName(int)](#getfieldnameint-method) | string | Gets the name of the specified field. |
| public | [GetFieldRawValue(int)](#getfieldrawvalueint-method) | object | Gets the value of the specified field. |
| public | [GetFieldRawValue(string)](#getfieldrawvaluestring-method) | object | Gets the value of the specified field. |
| public | [GetFieldValue(int)](#getfieldvalueint-method) | object | Gets the value of the specified field. The value is converted to a well-known type. |
| public | [GetFieldValue(string)](#getfieldvaluestring-method) | object | Gets the value of the specified field. The value is converted to a well-known type. |
| public | [GetFieldValueIsNull(int)](#getfieldvalueisnullint-method) | bool | Gets a value that indicates whether the value of the specified field is null. |
| public | [GetFieldValueIsNull(string)](#getfieldvalueisnullstring-method) | bool | Gets a value that indicates whether the value of the specified field is null. |
| public | [GetHashCode](#gethashcode-method) | int | Inherited from  System.Object . |
| public | [GetType](#gettype-method) | Type | Inherited from  System.Object . |
| public | [GetValueType(int)](#getvaluetypeint-method) | Type | Gets the value type of the specified field. |
| protected | [MemberwiseClone](#memberwiseclone-method) | object | Inherited from  System.Object . |
| public | [Reset](#reset-method) | void | Resets the status of data generation processing. |
| public | [ToString](#tostring-method) | string | Inherited from  System.Object . |
---
### AsDataReader Method

Wrap as a DataReader.
```c#
public IDataGenerationReader AsDataReader()
```
#### Return type


[Go to methods](#Methods)

---
### Dispose Method

Inherited from  [DataGenerator](../mxProject.Devs.DataGeneration/DataGenerator.md) .
```c#
public virtual void Dispose()
```

[Go to methods](#Methods)

---
### Dispose(bool) Method

Disposes the resources it is using.
```c#
protected virtual void Dispose
(
	bool disposing
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| disposing | bool |  | A value that indicates whether it was called from the dispose method. |

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
### GenerateNext Method

Generates the next new value.
```c#
public bool GenerateNext()
```
#### Return type


[Go to methods](#Methods)

---
### GetFieldIndex(string) Method

Gets the index of the specified field name.
```c#
public int GetFieldIndex
(
	string name
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| name | string |  | The field name. |
#### Return type


[Go to methods](#Methods)

---
### GetFieldName(int) Method

Gets the name of the specified field.
```c#
public string GetFieldName
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
#### Return type


[Go to methods](#Methods)

---
### GetFieldRawValue(int) Method

Gets the value of the specified field.
```c#
public object GetFieldRawValue
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
#### Return type

#### Exceptions
|Exception Type|Message|
|:--|:--|
| InvalidOperationException | This generator is already EOF. |

[Go to methods](#Methods)

---
### GetFieldRawValue(string) Method

Gets the value of the specified field.
```c#
public object GetFieldRawValue
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The field name. |
#### Return type

#### Exceptions
|Exception Type|Message|
|:--|:--|
| InvalidOperationException | This generator is already EOF. |
| KeyNotFoundException | The specified field is not found. |

[Go to methods](#Methods)

---
### GetFieldValue(int) Method

Gets the value of the specified field. The value is converted to a well-known type.
```c#
public object GetFieldValue
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
#### Return type

#### Exceptions
|Exception Type|Message|
|:--|:--|
| InvalidOperationException | This generator is already EOF. |

[Go to methods](#Methods)

---
### GetFieldValue(string) Method

Gets the value of the specified field. The value is converted to a well-known type.
```c#
public object GetFieldValue
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The field name. |
#### Return type

#### Exceptions
|Exception Type|Message|
|:--|:--|
| InvalidOperationException | This generator is already EOF. |
| KeyNotFoundException | The specified field is not found. |

[Go to methods](#Methods)

---
### GetFieldValueIsNull(int) Method

Gets a value that indicates whether the value of the specified field is null.
```c#
public bool GetFieldValueIsNull
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
#### Return type

#### Exceptions
|Exception Type|Message|
|:--|:--|
| InvalidOperationException | This generator is already EOF. |

[Go to methods](#Methods)

---
### GetFieldValueIsNull(string) Method

Gets a value that indicates whether the value of the specified field is null.
```c#
public bool GetFieldValueIsNull
(
	string fieldName
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| fieldName | string |  | The field name. |
#### Return type

#### Exceptions
|Exception Type|Message|
|:--|:--|
| InvalidOperationException | This generator is already EOF.<exception cref="T:System.Collections.Generic.KeyNotFoundException">The specified field is not found.</exception> |

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
### GetValueType(int) Method

Gets the value type of the specified field.
```c#
public Type GetValueType
(
	int index
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| index | int |  | The field index. |
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
### Reset Method

Resets the status of data generation processing.
```c#
public void Reset()
```

[Go to methods](#Methods)

---
### ToString Method

Inherited from  System.Object .
```c#
public virtual string ToString()
```
#### Return type


[Go to methods](#Methods)



