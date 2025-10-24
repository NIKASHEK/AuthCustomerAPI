# AuthCustomerAPI

---

## Features
- JWT Authentication (Admin & User roles)  
- CRUD operations for Orders  
- Users can see only their own orders  
- Admins can filter orders by total amount  
- Logging with **Serilog**  

---

## Tech Stack
- .NET 8 / ASP.NET Core  
- Entity Framework Core (EF Core)  
- JWT Authentication  
- Serilog Logging  

---

## API Endpoints

| Method | Route | Role | Description |
|--------|-------|------|-------------|
| GET    | `/api/OrderAPI/getOrders` | Admin | Retrieve all orders |
| GET    | `/api/OrderAPI/getMyOrders` | User  | Retrieve own orders |
| GET    | `/api/OrderAPI/getOrderById/{id}` | Admin/User | Retrieve order by ID |
| POST   | `/api/OrderAPI/createOrder` | Admin/User | Create a new order |
| PUT    | `/api/OrderAPI/updateOrder/{id}` | Admin/User | Update an existing order |
| DELETE | `/api/OrderAPI/deleteOrder/{id}` | Admin/User | Delete an order |
| GET    | `/api/OrderAPI/filterOrders` | Admin | Filter orders by total amount |
| PATCH  | `/api/OrderAPI/updatePartialOrder/{id}` | Admin/User | Partial update of an order |
