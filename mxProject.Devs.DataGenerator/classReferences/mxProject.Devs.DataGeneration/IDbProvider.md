


# IDbProvider Interface



Provides the functionality needed to activate database objects.






## Inheritance tree

[Methods](#Methods)&nbsp;&nbsp;





---
## Methods
|Scope|Signature|Return Type|Summary|
|:--|:--|:--|:--|
| public | [CreateConnection(string, string)](#createconnectionstring-string-method) | IDbConnection | Create a database connection. |
---
### CreateConnection(string, string) Method

Create a database connection.
```c#
IDbConnection CreateConnection
(
	string connectionString
	, string connectionTypeName = null
)
```
#### Parameters
|Name|Parameter Type|I/O|Description|
|:--|:--|:-:|:--|
| connectionString | string |  | The connection string to the datasource. |
| connectionTypeName | string |  | The type name of the database connection. |
#### Return type


[Go to methods](#Methods)



