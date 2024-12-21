# Car Parts Shop

##	System's Purpose
This API is for system which is designed for individuals to post advertisements for car parts sourced from used vehicles. The system will consist of three components: a web application, a database, and an API that will facilitate communication between the web application and the database.

To post an advertisement on this system, a person needs to register, create their own shop, and then create an advertisement. In the advertisement, they must provide information about the car from which the parts are being sold, and the advertisement will be assigned to a selected shop. After providing information about the car, the user specifies which parts from the car are for sale. Once the advertisement is posted, it becomes visible to all system users, including unregistered ones.

## How to Run

### Create the Database  
Open **SQL Server** and create a new database named: `CarPartsShop`
### Update the Database
Apply the existing migration to set up the database schema:
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

##	Functional requirements
An unregistered user will be able to:
- Log in
- Register
- View advertisements
- View shops
- View parts

Registered user of the system will be able to:
- Log out
- Create a store:
    - Enter a name
    - Enter store location
- Create an ad:
    - Choose a car make
    - Choose a car model
    - Choose the date of first registration
    - Choose a body type
    - Choose a fuel type
    - Select gearbox type
    - Enter the mileage
    - Enter displacement
    - Enter power
    - Assign parts for sale:
        - Enter name
        - Enter price
- Delete ad
- Delete shop
- Delete part for sale
- Change ad details
- Change vehicle information
- Change part information

The administrator will be able to:
- Delete a shop
- Delete an ad
- Delete a part

## API Endpoints

### Authentication
| Method    | Endpoint                   | Description        | Response Code |
|-----------|----------------------------|--------------------|---------------|
| `POST`    | `/api/login`               | Login              | 200           |
| `POST`    | `/api/register`            | Register           | 200           |

### Shops
| Method    | Endpoint                   | Description        | Response Code |
|-----------|----------------------------|--------------------|---------------|
| `GET`     | `/api/shops`               | List all shops     | 200           |
| `GET`     | `/api/shops/{id}`          | Get one shop       | 200           |
| `POST`    | `/api/shops`               | Create a shop      | 201           |
| `PUT`     | `/api/shops/{id}`          | Modify a shop      | 200           |
| `DELETE`  | `/api/shops/{id}`          | Remove a shop      | 204           |

### Cars
| Method    | Endpoint                            | Description               | Response Code |
|-----------|-------------------------------------|---------------------------|---------------|
| `GET`     | `/api/shops/{id}/cars`              | List all cars in a shop   | 200           |
| `GET`     | `/api/shops/{id}/cars/{id}`         | Get one car in a shop     | 200           |
| `POST`    | `/api/shops/{id}/cars`              | Create a car in a shop    | 201           |
| `PUT`     | `/api/shops/{id}/cars/{id}`         | Modify a car in a shop    | 200           |
| `DELETE`  | `/api/shops/{id}/cars/{id}`         | Remove a car in a shop    | 204           |

### Parts
| Method    | Endpoint                                       | Description                  | Response Code |
|-----------|------------------------------------------------|------------------------------|---------------|
| `GET`     | `/api/shops/{id}/cars/{id}/parts`              | List all parts of a car      | 200           |
| `GET`     | `/api/shops/{id}/cars/{id}/parts/{id}`         | Get one part of a car        | 200           |
| `POST`    | `/api/shops/{id}/cars/{id}/parts`              | Create a part for a car      | 201           |
| `PUT`     | `/api/shops/{id}/cars/{id}/parts/{id}`         | Modify a part of a car       | 200           |
| `DELETE`  | `/api/shops/{id}/cars/{id}/parts/{id}`         | Remove a part of a car       | 204           |

