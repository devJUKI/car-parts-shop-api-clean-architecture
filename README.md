# Car Parts Shop API

Car parts shop API made with ASP.NET Core using Clean Architecture principles (CQRS/MediatR with Global Exception Handling).

## 📜 System's Purpose
This API is for system which is designed for individuals to post advertisements for car parts sourced from used vehicles. The system will consist of three components:
1. A **web application**.  
2. A **database**.  
3. An **API** that connects the web application and the database.

To post an advertisement on this system, a person needs to register, create their own shop, and then create an advertisement. In the advertisement, they must provide information about the car from which the parts are being sold, and the advertisement will be assigned to a selected shop. After providing information about the car, the user specifies which parts from the car are for sale. Once the advertisement is posted, it becomes visible to all system users, including unregistered ones.

## 🚀 How to Run

### Create the Database & Apply Migration
#### Option 1: Using .NET CLI
Run the following command in your terminal:
```bash
dotnet ef database update
```
#### Option 2: Using Visual Studio Powershell
Run the following command in the Package Manager Console:
```bash
Update-Database
```

You're now ready to run the API! 🚗💨

## 🛠 Functional requirements
### Unregistered users can:
- 🔑 Log in
- ✍️ Register
- 👀 View:
  - Advertisements
  - Shops
  - Parts

### Registered users can:
- 🚪 Log out
- 🏪 Create a Shop:
  - Enter shop name
  - Specify shop location
- 📣 Post Advertisements:
  - Car Details:
    - Car make, model, body type, fuel type, gearbox type
    - First registration date
    - Mileage, displacement, and power
  - Parts Details:
    - Part name
    - Price
- ✏️ Modify:
  - Ads, vehicle information, or part details
- ❌ Delete:
  - Ads, shops, or parts for sale

### Administrators can:
- ✏️ Modify (all users'):
  - Ads, vehicle information, or part details
- ❌ Delete (all users'):
  - Ads, shops, or parts for sale

## 📚 API Endpoints

### 🔒 Authentication
| Method    | Endpoint                   | Description        | Response Code |
|-----------|----------------------------|--------------------|---------------|
| `POST`    | `/api/login`               | Login              | 200           |
| `POST`    | `/api/register`            | Register           | 200           |

### 🏪 Shops
| Method    | Endpoint                   | Description        | Response Code |
|-----------|----------------------------|--------------------|---------------|
| `GET`     | `/api/shops`               | List all shops     | 200           |
| `GET`     | `/api/shops/{id}`          | Get one shop       | 200           |
| `POST`    | `/api/shops`               | Create a shop      | 201           |
| `PUT`     | `/api/shops/{id}`          | Modify a shop      | 200           |
| `DELETE`  | `/api/shops/{id}`          | Remove a shop      | 204           |

### 🚗 Cars
| Method    | Endpoint                            | Description               | Response Code |
|-----------|-------------------------------------|---------------------------|---------------|
| `GET`     | `/api/shops/{id}/cars`              | List all cars in a shop   | 200           |
| `GET`     | `/api/shops/{id}/cars/{id}`         | Get one car in a shop     | 200           |
| `POST`    | `/api/shops/{id}/cars`              | Create a car in a shop    | 201           |
| `PUT`     | `/api/shops/{id}/cars/{id}`         | Modify a car in a shop    | 200           |
| `DELETE`  | `/api/shops/{id}/cars/{id}`         | Remove a car in a shop    | 204           |

### 🛠 Parts
| Method    | Endpoint                                       | Description                  | Response Code |
|-----------|------------------------------------------------|------------------------------|---------------|
| `GET`     | `/api/shops/{id}/cars/{id}/parts`              | List all parts of a car      | 200           |
| `GET`     | `/api/shops/{id}/cars/{id}/parts/{id}`         | Get one part of a car        | 200           |
| `POST`    | `/api/shops/{id}/cars/{id}/parts`              | Create a part for a car      | 201           |
| `PUT`     | `/api/shops/{id}/cars/{id}/parts/{id}`         | Modify a part of a car       | 200           |
| `DELETE`  | `/api/shops/{id}/cars/{id}/parts/{id}`         | Remove a part of a car       | 204           |

