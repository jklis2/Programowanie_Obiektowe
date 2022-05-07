using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle
{
    class AmphibiousVehicle :Vehicle, INaval, ILand
    {
        private int numberOfWheels;

        public int NumberOfWheels
        {
            get => numberOfWheels;
            set => numberOfWheels = value;
        }

        private int displacement;

        public int Displacement
        {
            get => displacement;
            set => displacement = value;
        }

        public AmphibiousVehicle(string _name, FuelType _fuelType, int _horsepower, int _numberOfWheels, int _displacement) : base(_name, _fuelType, _horsepower)
        {
            CurrentVehicleType = VehicleType.Land;
            Displacement = _displacement;
            NumberOfWheels = _numberOfWheels;
            SetSpeedConstraints(CurrentVehicleType);
            AddType(VehicleType.Land);
            AddType(VehicleType.Naval);
        }

        public override string ToString()
        {
            return $"1:{typeof(AmphibiousVehicle)} \n" +
                   $"2:Aktualne środowisko: {CurrentVehicleType}\n" +
                   $"3:Aktualnie się porusza: {IsMoving}\n" +
                   $"4:Minimalna prędkość: {MinSpeed} km/h, Maksymalna prędkość: {MaxSpeed} km/h\n" +
                   $"5:Aktualna prędkość poruszania się: {Speed} km/h\n" +
                   $"6:Typ silniku i moc koni mechanicznych: {FuelType}, {HorsePower} KM\n" +
                   $"7:Ilość kół: {NumberOfWheels}\n" +
                   $"8:Wyporność: {Displacement}";
        }
    }
}