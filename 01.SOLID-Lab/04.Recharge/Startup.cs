namespace Recharge
{
    using System;
    using Models;

    public class Startup
    {
        public static void Main()
        {
            Employee employee = new Employee("Ivan Ivanov");
            Robot robot = new Robot("T1000", 100);
            RechargeStation rechargeStation = new RechargeStation();
            rechargeStation.Recharge(robot);

            employee.Work(8);
            robot.Work(24);
            Console.WriteLine(robot.CurrentPower);
        }
    }
}