using AutomobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public void DeleteCar(Car car) => CarManagement.Instance.Remove(car);

        public IEnumerable<Car> GetCars() => CarManagement.Instance.GetCarList();

        public void InsertCar(Car car) => CarManagement.Instance.AddNew(car);

        public void UpdateCar(Car car) => CarManagement.Instance.Update(car);

        public Car GetCarById(int carId) => CarManagement.Instance.GetCarById(carId);
        
    }
}