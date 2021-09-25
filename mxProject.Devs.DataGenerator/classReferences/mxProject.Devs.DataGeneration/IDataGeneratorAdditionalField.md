


# IDataGeneratorAdditionalField Interface



Provides the required functionality for an additional field.






## Inheritance tree

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
| public | [CreateValueGetterAsync](#createvaluegetterasync-method) | ValueTask&lt;Func&lt;IDataGenerationRecord, object&gt;&gt; | Creates a method to get the value of the field. |
---
### CreateValueGetterAsync Method

Creates a method to get the value of the field.
```c#
ValueTask<Func<IDataGenerationRecord, object>> CreateValueGetterAsync()
```
#### Return type


[Go to methods](#Methods)



