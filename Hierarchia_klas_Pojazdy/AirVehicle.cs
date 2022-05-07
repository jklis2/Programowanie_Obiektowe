using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle
{
    class AirVehicle : Vehicle, ILand
    {
        private int numberOfWheels;

        public int NumberOfWheels
        {
            get => numberOfWheels;
            set => numberOfWheels = value;
        }

        public AirVehicle(string _name, FuelType _fuelType, int _horsepower, int _numberOfWheels) : base(_name, _fuelType, _horsepower)
        {
            CurrentVehicleType = VehicleType.Land;
            NumberOfWheels = _numberOfWheels;
            SetSpeedConstraints(CurrentVehicleType);
            AddType(VehicleType.Land);
            AddType(VehicleType.Air);
        }

        public override string ToString()
        {
            return $"1:{typeof(AirVehicle)} \n" +
                   $"2:Aktualne środowisko: {CurrentVehicleType}\n" +
                   $"3:Aktualnie się porusza: {IsMoving}\n" +
                   $"4:Minimalna prędkość: {MinSpeed} km/h, Maksymalna prędkość: {MaxSpeed} km/h\n" +
                   $"5:Aktualna prędkość poruszania się: {Speed} km/h\n" +
                   $"6:Typ silniku i moc koni mechanicznych: {FuelType}, {HorsePower} KM\n" +
                   $"7:Ilość kół: {NumberOfWheels}\n";
        }
    }
}