using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;

namespace EvaluationSys
{
    public class OrclDBManager : IDisposable
    {
        private OracleConnection _connection = new OracleConnection();

        public OrclDBManager()
        {
            _connection.ConnectionString = "SERVER=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.241.160)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=gepes)));uid=airuser;pwd=air;";
            _connection.Open();
        }

        public OrclDBManager(string ConnectionString)
        {
            _connection.ConnectionString = ConnectionString;
            _connection.Open();
        }

        public static String makeConnectionString(String host, int port, String name, String user, String pass)
        {
            String connectionTemplate = "SERVER=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));uid={3};pwd={4};";
            return String.Format(connectionTemplate, host, port, name, user, pass);
        }

        public List<String> test()
        {
            List<String> list = new List<String>();
            try
            {
                using (OracleCommand cmd = _connection.CreateCommand())
                {
                    cmd.CommandText = "select * from help";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(2))
                            {
                                String str = reader.GetString(2);
                                list.Add(str);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
            }

            return list;
        }

        public OracleConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
            GC.SuppressFinalize(_connection);
        }

        #endregion
    }

    public class DBConfig
    {
        public static string Address;
        public static int Port;
        public static string Server;
        public static string UserName;
        public static string Password;
    }

    public class OrclTranManager : IDisposable
    {
        private OrclDBManager _dBManager;
        private OrclTranOption _tranOption;
        private OracleCommand _orclCommand;
        private OracleTransaction _orclTransaction;

        public OrclTranManager(OrclDBManager dBManager, OrclTranOption tranOption)
        {
            _dBManager = dBManager;
            _tranOption = tranOption;

            _orclCommand = new OracleCommand();
            _orclCommand.Connection = _dBManager.Connection;
            switch (_tranOption)
            {
                case OrclTranOption.Require:
                    _orclTransaction = _dBManager.Connection.BeginTransaction();
                    _orclCommand.Transaction = _orclTransaction;
                    break;
                default:
                    break;
            }
        }

        public void DoRollback()
        {
            _orclTransaction.Rollback();
        }

        public void Complete()
        {
            switch (_tranOption)
            {
                case OrclTranOption.Require:
                    if (_orclTransaction != null && _orclTransaction.Connection != null)
                    {
                        _orclTransaction.Commit();
                    }
                    break;
                default:
                    break;
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            switch (_tranOption)
            {
                case OrclTranOption.Require:
                    if (_orclTransaction != null && _orclTransaction.Connection != null)
                    {

                    }
                    break;
                default:
                    break;
            }

        }

        #endregion

        public string CommandText
        {
            get
            {
                return _orclCommand.CommandText;
            }
            set
            {
                _orclCommand.CommandText = value;
            }
        }

        public CommandType CommandType
        {
            get
            {
                return _orclCommand.CommandType;
            }
            set
            {
                _orclCommand.CommandType = value;
            }
        }

        public OracleParameterCollection Parameters
        {
            get
            {
                return _orclCommand.Parameters;
            }
        }
        //wang20110408   增加异常处理
        public DataSet GetData()
        {
            DataSet dsRet = new DataSet();
            try
            {
                OracleDataAdapter da = new OracleDataAdapter(_orclCommand);
                da.Fill(dsRet);
            }
            catch (Exception err)
            {
                throw err;
            }

            return dsRet;
        }

        public DataTable GetDataTable()
        {
            DataTable dt = new DataTable("temp");
            try
            {
                OracleDataAdapter da = new OracleDataAdapter(_orclCommand);
                da.Fill(dt);
            }
            catch (Exception err)
            {
                throw err;
            }

            return dt;
        }

        public int Fill(DataSet dataSet)
        {
            OracleDataAdapter da = new OracleDataAdapter(_orclCommand);
            return da.Fill(dataSet);
        }

        public int Fill(DataTable dataTable)
        {
            OracleDataAdapter da = new OracleDataAdapter(_orclCommand);
            return da.Fill(dataTable);
        }

        public int ExecuteNonQuery()
        {
            return _orclCommand.ExecuteNonQuery();
        }

        public object ExecuteScalar()
        {
            return _orclCommand.ExecuteScalar();
        }

        public static OracleParameter AddInput(OracleParameterCollection parameters, String name, OracleType type, Object val)
        {
            OracleParameter parameter = new OracleParameter();
            parameter.Direction = ParameterDirection.Input;
            parameter.ParameterName = name;
            parameter.Value = val;
            parameter.OracleType = type;
            parameters.Add(parameter);
            return parameter;
        }

        public static OracleParameter AddOutput(OracleParameterCollection parameters, String name, OracleType type)
        {
            OracleParameter parameter = new OracleParameter();
            parameter.Direction = ParameterDirection.Output;
            parameter.ParameterName = name;
            parameter.OracleType = type;
            parameters.Add(parameter);
            return parameter;
        }

        public static OracleParameter AddReturnString(OracleParameterCollection parameters, String name, OracleType type, Int32 size)
        {
            OracleParameter parameter = new OracleParameter();
            parameter.Direction = ParameterDirection.ReturnValue;
            parameter.ParameterName = name;
            parameter.OracleType = type;
            parameter.Size = size;
            parameters.Add(parameter);
            return parameter;
        }

        public static OracleParameter AddReturnInt(OracleParameterCollection parameters, String name, OracleType type)
        {
            OracleParameter parameter = new OracleParameter();
            parameter.Direction = ParameterDirection.ReturnValue;
            parameter.ParameterName = name;
            parameter.OracleType = type;
            parameters.Add(parameter);
            return parameter;
        }
    }

    public enum OrclTranOption { Require, None };
}
