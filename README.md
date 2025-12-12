# ERPCore

A console-based ERP (Enterprise Resource Planning) system built with **C# (.NET 9)** and **Entity Framework Core**. This application manages data for customers, products, and sales orders, connected to an **Azure SQL Database**.

## 🚀 Features
- **Data Management:** CRUD operations for Customers, Products, and Orders.
- **ORM:** Uses Entity Framework Core for database interactions.
- **Cloud Connectivity:** Connects securely to Azure SQL Database.
- **Security:** Sensitive configuration (connection strings) is separated from the codebase using `appsettings.json`.

## 🛠️ Technologies
- .NET 9
- Entity Framework Core
- Microsoft SQL Server / Azure SQL
- C# Console Application

## ⚙️ Getting Started

### Prerequisites
- .NET 9 SDK installed.
- Access to an SQL Server (Local or Azure).

### Installation
1. **Clone the repository**
   ```bash
  git clone https://github.com/andersabjorn/ERPCore.git
   cd ERPCore
