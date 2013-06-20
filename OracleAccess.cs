using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace EvaluationSys
{
    public class OracleAccess
    {
        private static OracleAccess _instance;

        private OracleAccess()
        {

        }

        public new static OracleAccess GetInstance()
        {
            return _instance ?? (_instance = new OracleAccess());
        }



        public void ExecuteNonQuery(string command)
        {
            try
            {
                using (var orclDbManager = new OrclDBManager())
                {
                    using (var orclTranManager = new OrclTranManager(orclDbManager, OrclTranOption.None))
                    {
                        try
                        {
                            orclTranManager.CommandType = CommandType.Text;

                            orclTranManager.CommandText = command;

                            orclTranManager.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable GetDatatable(string command)
        {
            DataSet dataSet;

            try
            {
                using (var orclDbManager = new OrclDBManager())
                {
                    using (var orclTranManager = new OrclTranManager(orclDbManager, OrclTranOption.None))
                    {
                        try
                        {
                            orclTranManager.CommandType = CommandType.Text;

                            orclTranManager.CommandText = command;

                            dataSet = orclTranManager.GetData();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            if (dataSet.Tables.Count == 0)
            {
                return new DataTable();
            }

            return dataSet.Tables[0];
        }

    }
}
