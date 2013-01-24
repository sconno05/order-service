order-service
=============

A REST service for submitting orders with UI built in ASP.NET

To test
=============

1. Run the OrderService.
2. Run the OrderUI, enter an order name and price into the fields, and submit.
3. Run the OrderProcessingService.  Verify data is stored in the Orders table by opening Server Explorer in Visual Studio, and adding a new data connection to SQLEXPRESS - OrderProcessinService.OrdersContext. Right click the Orders table and select "Show Table Data".
