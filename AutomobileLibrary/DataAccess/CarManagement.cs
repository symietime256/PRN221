using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AutomobileLibrary.DataAccess
{
    public class CarManagement
    {
        private static CarManagement instance = null;
        public static readonly object instanceLock = new object();
        private CarManagement() { }
        public static CarManagement Instance
        {
            get
            {
                lock(instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CarManagement();
                    }
                    return instance;
                }
            }
        }


        public IEnumerable<Car> GetCarList()
        {
            List<Car> cars;
            try
            {
                var myStock = new MyStockContext();
                cars = myStock.Cars.ToList();
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return cars;
        }

        public Car GetCarById(int carId)
        {
            Car car = null;
            try
            {
                var myStock = new MyStockContext();
                car = myStock.Cars.SingleOrDefault(car => car.CarId == carId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return car;
        }

        public void AddNew(Car car)
        {
            try
            {
                Car _car = GetCarById(car.CarId);
                if (_car == null)
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Cars.Add(car);
                    myStockDB.SaveChanges();
                } else
                {
                    throw new Exception("Car is already existed.");
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void Update(Car car)
        {
            try
            {
                Car c = GetCarById(car.CarId);
                if (c != null)
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Entry<Car>(car).State = EntityState.Modified;
                    myStockDB.SaveChanges();
                } else
                {
                    throw new Exception("Car is not existed.");
                }
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Remove(Car car)
        {
            try
            {
                Car _car = GetCarById(car.CarId);
                if (_car != null)
                {
                    var myStockDB = new MyStockContext();
                    myStockDB.Cars.Remove(_car);
                    myStockDB.SaveChanges();
                } else
                {
                    throw new Exception("Car is not existed.");
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
