# ElectronicsShop_App
This workshop is to develop a web site for an Electronics Shop. The shop sells 3 categories of products , The shop owner wanted this web site in order to display the electronics products and their prices.Moreover, the shop owner asked to have a registration system for the customers, where customers will be able to register, sign in. Registered customers will be able to place orders by filling a form for a single item he selects, and that item will be delivered to him and paid in by Cash on delivery (payment is not handled through the web site).


# ElectronicsShop_App
# Description
This workshop is to develop a web site for an Electronics Shop. The shop sells 3 categories of products: TVs,
Laptops, and sound systems. The shop owner wanted this web site in order to display the electronics products
and their prices.
Moreover, the shop owner asked to have a registration system for the customers, where customers will be able
to register, sign in.
Registered customers will be able to place orders by filling a form for a single item he selects, and that item will
be delivered to him and paid in by Cash on delivery (payment is not handled through the web site). for Backend with .net core mvc and razor pages , JQuery Ajax to frontend , EF Core (Code First) for ORM with Clean Archictecutre for all the solution

# Table of Contents
This solution contain 5 layers

1 - ElectronicShop.Deomain : this layer contain business entity that is represent business in database 
2 - ElectronicShop.Application : this layer contain the DbContext class that has all DbSets of All Project and have the configuration for the entityframework core and dbContext to make the migration , And Contain the Application Interfaces and Repositpry Implementation 
3 - ElectronicShop.Infrastructure : this layer contain the business implementation for workshop with it's interface 
4 - ElectronicShop.WebUI : .NET Core MVC that represent the UI
5 - ElectronicShop.Resources : have some shared resources

# Installation
To install solution make sure you have 
1 - .NET Core installed in your machine 
2 - clone the repository 
3 - open package manager console and in default project dropdown select CleanArc.Context and run command update-database to add database in your sql server 
4 - make the solution run WebUI projects and this is final step

# Usage
the applaction contain one Home Page accoring to home controller and Login form for authnticate user

# Refrences
Clean Arch : 1 - https://dev.to/joxiah/clean-architecture-in-asp-net-core-47o2
