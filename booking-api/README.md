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

Cases:

- No downtime
- Apenas 1 quarto disponivel. Nao deve ser possivel bookar mais de um quarto
- Uma reserva não pode ser maior do que 3 dias. 
- Uma reserva nao pode ser feita com 30 dias de antecedencia
- Uma diaria acontece de 00:00 ate 23:59:59
- Cada usuario pode:
    - Checar disponilidade do quarto
    - fazer uma reserva (se datas disponiveis, e atender requisitos acima)
    - cancelar uma reserva ** confirmar requisitos para cancelamento - é possivel cancelar uma reserva em andamento?
    - modificar uma reserva ( se data disponivel) - é possivel  modificar uma reserva em andamento?
- API nao precisa de autenticacao


run:
- dotnet ef migrations add InitialCreate --project ".\1.Presentation\Booking.Api\Booking.Api.csproj"