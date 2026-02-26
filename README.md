
# Blog Backend API - Project Overview

## Project Goal

Create a backend for blog application

- Support full CRUD operations
- All users to create account and login
- deploy to azure
- use SCRUM workflow concepts
- Introduces Azure Devops Practices

## Stack

  - Backend will be in .Net 9, ASP.NET core, EF Core, SQL Server
  - Front end will be done in Next JS with TypeScript. Deploy with TBA (Vercel or Azure)

## Application Features

### User Capabilities

- Create an account
- Login
- Delete account

### Blog Features

 - View all publised blog posts
 - Filter blog posts
 - Create new posts
 - Edit existing posts
 - Delete posts
 - publish/ Unpublish posts

 ### Pages (Frontend connected to API)

 - Create account page
 - Blog view post page of published items
 - Dashboard page (This is the profile page will edit, delete, and publish and unpublish our blog posts)
 - **Blog Page**
    - Display all published blog items

- **Dashboard**
    - User profile page
    - Create blog posts
    - Edit blog posts
    - Delete blog posts

## Project folder Structure

## Controllers

#### User Controller

Handles all user interaction

Endpoints:

- Login
- Add user
- Update Users
- Delte User

#### BlogController

Handles all blog operations

Endpoints:

- Create Blog Item (C)
- Get all blog items (R)
- Get Blog Items by Category (R)
- Get Blog items by tags (R)
- Get Blog items by date (R)
- Get published Blog Items (R)
- Update Blog Item (U)
- Delete Blog Item (D)
- Get Blog Items by UserId

> Delete will be used for soft delete / publish logic

---

## Models

### UserModel

```csharp

int Id
string Username
string Salt
string Hash

### BlogItemModel

int Id
int UserId
string PublisherName
string Title
string Image
string Description
string Date
string Category
string Tags
bool IsPublished
bool IsDeleted

## Items Saved to our DB
### We need a way to sign in withn our name and password

```csharp

### LoginModel

    string Username
    string Password

### CreateAccountModel
    int Id=0 
    string Username
    string Password

### PasswordModel

    string Salt
    string Hash

```

### Services
    Context/Folder
    - DataContext
    - UserService/file
        - GetUserByUsername
        - Login
        - AddUser
        - Updateuser
        - DelteUser
### BlogItemService
    - AddBlogItems
    - GetAllBlogItems
    - GetBlogItemsByCategory
    - GetBlogItemsByTags
    - GetBlogItemsByDate
    - GetPublishedBlogItems
    - UpdateBlogItems
    - DelteBlogItems
    - GetUSerByID
### PasswordServices

    - Hash Password
    - Very Hash Password