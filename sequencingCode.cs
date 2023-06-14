using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day04_02SequenctingCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = 1;
            while (choice != 0)
            {
                Console.WriteLine("1: SQLServer, 2: Oracle");
                int dbchoice = Convert.ToInt32(Console.ReadLine());

                DBFactory dBFactory = new DBFactory();

                Database obj = dBFactory.GetDatabase(dbchoice);

                Console.WriteLine("1: Insert, 2: Update, 3: Delete");
                choice = Convert.ToInt32(Console.ReadLine());
                if(choice == 0) { break; }

                switch (choice)
                {
                    case 1:
                        obj.Insert();
                        break;
                    case 2:
                        obj.Update();
                        break;
                    case 3:
                        obj.Delete();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
            Console.WriteLine("Press ENter To Close");
            Console.ReadLine();
        }

    }
    public class DBFactory
    {
        public Database GetDatabase(int dbChoice)
        {
            if (dbChoice == 1)
            {
                return new SqlServer();
            }
            else
            {
                return new Oracle();
            }
        }
    }

    public class Logger
    {
        private Logger() { }

        private static Logger logger = new Logger();

        public static Logger CurrentLogger
        {
            get { return logger; }
        }

        public void Log(string message)
        {
            Console.WriteLine("Log @ " + DateTime.Now.ToString() + " : " + message);
        }
    }

    public abstract class Database
    {
        private string _dbServerName;
        private string DbServerName { get { return _dbServerName; } set { _dbServerName = value; } }
        public Database(string DbServerName) { this.DbServerName = DbServerName; }
        public abstract void InsertImp();
        public abstract void UpdateImp();
        public abstract void DeleteImp();
        public void Insert()
        {
            InsertImp();
            Logger.CurrentLogger.Log("Log@" + DateTime.Now.ToString() + " : " + DbServerName + " Insert Called");
        }
        public void Update()
        {
            UpdateImp();
            Logger.CurrentLogger.Log("Log@" + DateTime.Now.ToString() + " : " + DbServerName + " Update Called");
        }
        public void Delete()
        {
            DeleteImp();
            Logger.CurrentLogger.Log("Log@" + DateTime.Now.ToString() + " : " + DbServerName + " Delete Called");
        }
    }

    public class SqlServer : Database
    {
        public SqlServer() : base("SQL") { }
        public override void InsertImp()
        {
            Console.WriteLine("SQL Server Insert Is Called");
        }

        public override void UpdateImp()
        {
            Console.WriteLine("SQL Server Update Is Called");
        }

        public override void DeleteImp()
        {
            Console.WriteLine("SQL Server Delete Is Called");
        }
    }

    public class Oracle : Database
    {
        public Oracle() : base("Oracle") { }
        public override void InsertImp()
        {
            Console.WriteLine("Oracle Server Insert Is Called");
        }

        public override void UpdateImp()
        {
            Console.WriteLine("Oracle Server Update Is Called");
        }

        public override void DeleteImp()
        {
            Console.WriteLine("Oracle Server Delete Is Called");
        }
    }
}
