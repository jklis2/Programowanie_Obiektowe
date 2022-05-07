using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle
{
    class NavalVehicle : Vehicle, INaval
    {
        private int displacement;

        public int Displacement
        {
            get => displacement;
            set => displacement = value;
        }

        public NavalVehicle(string _name, FuelType _fuelType, int _horsepower, int _displacement) : base(_name, _fuelType, _horsepower)
        {
            CurrentVehicleType = VehicleType.Naval;
            Displacement = _displacement;
            SetSpeedConstraints(CurrentVehicleType);
            AddType(VehicleType.Naval);
        }

        public override string ToString()
        {
            return $"1:{typeof(NavalVehicle)} \n" +
                   $"2:Aktualne środowisko: {CurrentVehicleType}\n" +
                   $"3:Aktualnie się porusza: {IsMoving}\n" +
                   $"4:Minimalna prędkość: {MinSpeed} km/h, Maksymalna prędkość: {MaxSpeed} km/h\n" +
                   $"5:Aktualna prędkość poruszania się: {Speed} km/h\n" +
                   $"6:Typ silniku i moc koni mechanicznych: {FuelType}, {HorsePower} KM\n" +
                   $"7:Wyporność: {Displacement}";
        }
    }
}