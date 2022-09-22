**CHALLENGE**s
Post-Covid scenario:
People are now free to travel everywhere but because of the pandemic, a lot of hotels
went bankrupt. Some former famous travel places are left with only one hotel.
You’ve been given the responsibility to develop a booking API for the very last hotel in Cancun.
The requirements are:
- API will be maintained by the hotel’s IT department.
- As it’s the very last hotel, the quality of service must be 99.99 to 100% => no downtime
- For the purpose of the test, we assume the hotel has only one room available
- To give a chance to everyone to book the room, the stay can’t be longer than 3 days
and can’t be reserved more than 30 days in advance.
- All reservations start at least the next day of booking,
- To simplify the use case, a “DAY’ in the hotel room starts from 00:00 to 23:59:59.
- Every end-user can check the room availability, place a reservation, cancel it or modify it.
- To simplify the API is insecure. 


** How to execute?**

1. go under folder:
booking-api\Booking

2. execute migration:

dotnet ef database update --project ".\4.Infra\Booking.Infrastructure.DatabaseEFCore\Booking.Infrastructure.DatabaseEFCore.csproj" --connection "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Booking;Persist Security Info=True; Integrated Security=True;"

3. run project

** Swagger**
https://localhost:7056/swagger/index.html

** Existent data**
The project contains two existent users, and an existent room that are created from seed's migration.