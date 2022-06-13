using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicle
{
    public abstract class Vehicle
    {
        private string name;

        public string Name
        {
            get => name;
        }

        private VehicleType currentVehicleType;

        public VehicleType CurrentVehicleType
        {
            get => currentVehicleType;
            protected set => currentVehicleType = value;
        }

        private List<VehicleType> vehicleTypes;

        private bool isMoving = false;

        public bool IsMoving
        {
            get => isMoving;
        }
        private float speed = 0f;

        public float Speed
        {
            get => speed;
            set => speed = value;
        }
        private float minSpeed;

        public float MinSpeed
        {
            get => minSpeed;
        }
        private float maxSpeed;

        public float MaxSpeed
        {
            get => maxSpeed;
        }
        private FuelType fuelType;

        public FuelType FuelType
        {
            get => fuelType;
        }
        private int horsePower;

        public int HorsePower
        {
            get => horsePower;
        }
        private const float airSpeedMod = 3.6f;

        public float AirSpeedMod
        {
            get { return airSpeedMod; }
        }
        private const float navalSpeedMod = 1.852f;

        public float NavalSpeedMod
        {
            get { return navalSpeedMod; }
        }

        public Vehicle(string _name, FuelType _fuelType, int _horsepower)
        {
            name = _name;            
            fuelType = _fuelType;            
            horsePower = _horsepower;
            vehicleTypes = new List<VehicleType>();
        }

        public void Start()
        {
            isMoving = true;
            speed = 1f;
        }

        public void Stop()
        {
            if(currentVehicleType == VehicleType.Air)
                Console.WriteLine("You cant stop aircraft in the air!");                
            isMoving = false;
            speed = 0f;
        }

        public void Accelerate(float amount)
        {
            if(speed == 0f)
            {
                Start();
                speed += amount - 1f;
                if (speed > maxSpeed)
                    speed = maxSpeed;
            }
            else
            {
                speed += amount;
                if (speed > maxSpeed)
                    speed = maxSpeed;
            }
        }

        public void SlowDown(float amount)
        {
            speed -= amount;
            if (speed < minSpeed)
                speed = minSpeed;
        }

        protected void SetSpeedConstraints(VehicleType vehicleType)
        {
            switch (vehicleType)
            {
                case VehicleType.Land:
                    minSpeed = 1f;
                    maxSpeed = 350f;
                    break;
                case VehicleType.Air:
                    minSpeed = 20f;
                    maxSpeed = 200f;
                    break;
                case VehicleType.Naval:
                    minSpeed = 1f;
                    maxSpeed = 40f;
                    break;                
            }
        }

        protected void AddType(VehicleType vehicleType)
        {
            vehicleTypes.Add(vehicleType);
        }

        public void SwitchEnviroment(VehicleType current, VehicleType target)
        {
            if (current != currentVehicleType)
                Console.WriteLine($"{nameof(current)} must match current vehicle type");                
            if (!vehicleTypes.Contains(target))
                Console.WriteLine($"{nameof(target)} must be available for that vehicle");               
            if (current == target)
                Console.WriteLine($"{nameof(target)} must be diffrent than current vehicle type");                

            switch (current)
            {
                case VehicleType.Land:
                    switch (target)
                    {                        
                        case VehicleType.Air:
                            if (speed >= 72f)
                            {
                                currentVehicleType = VehicleType.Air;
                                speed = speed / AirSpeedMod;
                                SetSpeedConstraints(target);
                            }
                            else
                            {
                                Console.WriteLine("You are too slow to take off");
                            }
                            break;
                        case VehicleType.Naval:
                            currentVehicleType = VehicleType.Naval;
                            speed = speed / NavalSpeedMod;
                            SetSpeedConstraints(target);
                            if (speed < minSpeed)
                                speed = minSpeed;
                            break;                        
                    }
                    break;
                case VehicleType.Air:
                    switch (target)
                    {
                        case VehicleType.Land:
                            if (speed == 20f)
                            {
                                currentVehicleType = VehicleType.Land;
                                speed = speed * AirSpeedMod;
                                SetSpeedConstraints(target);

                            }
                            else
                            {
                                Console.WriteLine("You are too fast to land");
                            }
                            break;
                        case VehicleType.Naval:
                            break;
                    }
                    break;
                case VehicleType.Naval:
                    switch (target)
                    {
                        case VehicleType.Land:
                            currentVehicleType = VehicleType.Land;                            
                            speed = speed * NavalSpeedMod;
                            SetSpeedConstraints(target);
                            break;
                        case VehicleType.Air:
                            break;
                    }
                    break;               
            }
        }
    }
}