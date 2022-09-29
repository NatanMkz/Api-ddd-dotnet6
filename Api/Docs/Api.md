# Api

- [Api](#api)
  - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-response)
## Auth

### Register

```js
POST {{host}}/auth/register
```

#### Register Request
```json
{    
    "firstName": "Natan",
    "lastName": "Martins",
    "email": "natan@.com",
    "password": "dev"
}
```
#### Register Response

```json
200 OK
```json
{    
    "id": "1",
    "firstName": "Natan",
    "lastName": "Martins",
    "email": "natan@.com",
    "token": "dev"
}
```

### Login

#### Login Request

```json

{
  "email": "natan@.com",
  "password": "dev"
}
```
#### Login Response

```json
200 OK
```json
{
    "id": "1",
    "firstName": "Natan",
    "lastName": "Martins",
    "email": "natan@.com",
    "token": "dev"
}
```