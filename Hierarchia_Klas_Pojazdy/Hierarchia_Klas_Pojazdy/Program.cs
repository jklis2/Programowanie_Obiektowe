using System;
using System.Collections.Generic;

namespace Vehicle
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> Vehicles = new List<Vehicle>();
            LandVehicle bike = new LandVehicle("Bike",  FuelType.None, 0, 2);
            Vehicles.Add(bike);
            AirVehicle plane = new AirVehicle("F32",  FuelType.AviationFuel, 100, 3);
            Vehicles.Add(plane);
            AmphibiousVehicle amfibia = new AmphibiousVehicle("Amfibia", FuelType.Diesel, 620, 6, 9);
            Vehicles.Add(amfibia);
            NavalVehicle ship = new NavalVehicle("Ship", FuelType.Mazout, 40000, 5000);
            Vehicles.Add(ship);
            LandVehicle car = new LandVehicle("Car", FuelType.Gas, 110, 4);
            Vehicles.Add(car);
            LandVehicle superCar = new LandVehicle("Bugatti", FuelType.Gas, 400, 4);
            Vehicles.Add(superCar);

            bike.Start();
            bike.Accelerate(9);

            plane.Start();
            plane.Accelerate(72);
            plane.SwitchEnviroment(VehicleType.Land, VehicleType.Air);
            plane.Accelerate(100);

            amfibia.Start();
            amfibia.SwitchEnviroment(VehicleType.Land, VehicleType.Naval);

            ship.Start();
            ship.Accelerate(15);

            car.Start();
            car.Accelerate(100);

            superCar.Start();
            superCar.Accelerate(500);

            foreach(Vehicle vehicle in Vehicles)
            {
                Console.WriteLine(vehicle.Name);
            }

            Console.WriteLine();

            foreach (Vehicle vehicle in Vehicles)
            {
                if(vehicle.CurrentVehicleType == VehicleType.Land)
                    Console.WriteLine(vehicle.Name);
            }

            Console.WriteLine();

            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle.CurrentVehicleType == VehicleType.Air)
                    vehicle.Speed *= vehicle.AirSpeedMod;
                if (vehicle.CurrentVehicleType == VehicleType.Naval)
                    vehicle.Speed *= vehicle.NavalSpeedMod;
            }
            Vehicles.Sort((p, q) => p.Speed.CompareTo(q.Speed));
            Vehicles.Reverse();
            foreach (Vehicle vehicle in Vehicles)
            {
                Console.WriteLine(vehicle.Name +" "+vehicle.Speed);
            }

            Console.WriteLine();
            foreach (Vehicle vehicle in Vehicles)
            {
                if (vehicle.CurrentVehicleType == VehicleType.Land)
                    Console.WriteLine(vehicle.Name + " " + vehicle.Speed);
            }
        }
    }
}