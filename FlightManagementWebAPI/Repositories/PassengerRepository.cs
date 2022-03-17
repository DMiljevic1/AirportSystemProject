using DomainModel.Models;
using FlightManagementWebAPI.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlightManagementWebAPI.Repositories
{
    public class PassengerRepository
    {
        private readonly AirportSystemContext _airportSystemContext;
        public PassengerRepository(AirportSystemContext airportSystemContext)
        {
            _airportSystemContext = airportSystemContext;
        }
        public List<Passenger> GetPassengers()
        {
            return _airportSystemContext.Passengers.ToList();
        }
        public void InsertPassenger(Passenger passenger)
        {
            _airportSystemContext.Passengers.Add(passenger);
            _airportSystemContext.SaveChanges();
        }

        public void UpdatePassenger(Passenger passenger)
        {
            var passengerForUpdate = GetPassengerById(passenger.Id);
            if (passengerForUpdate != null)
            {
                passengerForUpdate.FirstName = passenger.FirstName;
                passengerForUpdate.LastName = passenger.LastName;
                passengerForUpdate.Sex = passenger.Sex;
                passengerForUpdate.Seat = passenger.Seat;
                passengerForUpdate.NumberOfLuggage = passenger.NumberOfLuggage;
                passengerForUpdate.LuggageWeight = passenger.LuggageWeight;
                passengerForUpdate.FullNameOnDocument = passenger.FullNameOnDocument;
                passengerForUpdate.TypeOfDocument = passenger.TypeOfDocument;
                passengerForUpdate.NumberOfDocument = passenger.NumberOfDocument;
                passengerForUpdate.ExpireDate = passenger.ExpireDate;

                _airportSystemContext.SaveChanges();
            }

        }
        public Passenger GetPassengerById(int passengerId)
        {
            return _airportSystemContext.Passengers.FirstOrDefault(passenger => passenger.Id.Equals(passengerId));
        }

        public void DeletePassenger(int passengerId)
        {
            var passengerForDelete = GetPassengerById(passengerId);
            if (passengerForDelete != null)
            {
                _airportSystemContext.Passengers.Remove(passengerForDelete);
                _airportSystemContext.SaveChanges();
            }
        }
        public void CheckIn(int passengerId)
        {
            var passenger = GetPassengerById(passengerId);
            if (passenger != null)
            {
                passenger.IsChecked = true;
                _airportSystemContext.SaveChanges();
            }
        }
    }
}
