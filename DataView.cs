using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EvaluationSys
{
    public partial class DataView : Form
    {
        /// <summary>
        /// 配置标准集合
        /// </summary>
        DataSet dsCritical = new DataSet();
        /// <summary>
        /// 人员 分值表
        /// </summary>
        public DataTable dtScore = new DataTable();


        /// <summary>
        /// 学历分数
        /// </summary>
        private double graedu;
        /// <summary>
        /// 年龄分数
        /// </summary>
        private double graold;
        /// <summary>
        /// 执照分数
        /// </summary>
        private double graPermit;
        /// <summary>
        /// 工作年限分数
        /// </summary>
        private double graWordate;
        /// <summary>
        /// 等级分数
        /// </summary>
        private double graLevel;
        /// <summary>
        /// 英语分数
        /// </summary>
        private double graEnglish;
        /// <summary>
        /// 体检分数
        /// </summary>
        private double graCheckbody;
        /// <summary>
        /// 岗位加分
        /// </summary>
        private double graDuty;
        /// <summary>
        /// 岗位培训分数
        /// </summary>
        private double gratrainDuty;
        /// <summary>
        /// 赴外培训分数
        /// </summary>
        private double gratrainAboard;
        /// <summary>
        /// 奖励加分
        /// </summary>
        private double graAdd;
        /// <summary>
        /// 管制员和教员加分
        /// </summary>
        private double graTeacherAndChecker;
        /// <summary>
        /// 行政职务加分
        /// </summary>
        private double graHighPost;
        /// <summary>
        /// 总分
        /// </summary>
        private double total;
        /// <summary>
        /// 放单
        /// </summary>
        private double graPermitCheck;

        public DataView()
        {
            InitializeComponent();

            #region  初始化分值表结构

            DataColumn dc0 = new DataColumn("personname");
            DataColumn dc1 = new DataColumn("graedu", typeof(System.Double));
            DataColumn dc2 = new DataColumn("graold", typeof(System.Double));
            DataColumn dc3 = new DataColumn("graPermit", typeof(System.Double));
            DataColumn dc4 = new DataColumn("graWordate", typeof(System.Double));
            DataColumn dc5 = new DataColumn("graLevel", typeof(System.Double));
            DataColumn dc6 = new DataColumn("graEnglish", typeof(System.Double));
            DataColumn dc7 = new DataColumn("graCheckbody", typeof(System.Double));
            DataColumn dc8 = new DataColumn("gratrainDuty", typeof(System.Double));
            DataColumn dc9 = new DataColumn("gratrainAboard", typeof(System.Double));
            DataColumn dc10 = new DataColumn("graAdd", typeof(System.Double));
            DataColumn dc12 = new DataColumn("graDuty", typeof(System.Double));
            DataColumn dc11 = new DataColumn("total", typeof(System.Double));
            DataColumn dc13 = new DataColumn("Date", typeof(System.String));
            DataColumn dc14 = new DataColumn("Personid", typeof(System.String));
            DataColumn dc15 = new DataColumn("idcard", typeof(System.String));
            DataColumn dc16 = new DataColumn("CtrlYear", typeof(System.String));
            DataColumn dc17 = new DataColumn("CtrlDuty", typeof(System.Double));
            DataColumn dc18 = new DataColumn("HighPost", typeof(System.Double));
            DataColumn dc19 = new DataColumn("PermitCheck", typeof(System.Double));

            dtScore.Columns.Add(dc0);
            dtScore.Columns.Add(dc1);
            dtScore.Columns.Add(dc2);
            dtScore.Columns.Add(dc3);
            dtScore.Columns.Add(dc4);
            dtScore.Columns.Add(dc5);
            dtScore.Columns.Add(dc6);
            dtScore.Columns.Add(dc7);
            dtScore.Columns.Add(dc8);
            dtScore.Columns.Add(dc9);
            dtScore.Columns.Add(dc10);
            dtScore.Columns.Add(dc11);
            dtScore.Columns.Add(dc12);
            dtScore.Columns.Add(dc13);
            dtScore.Columns.Add(dc14);
            dtScore.Columns.Add(dc15);
            dtScore.Columns.Add(dc16);
            dtScore.Columns.Add(dc17);
            dtScore.Columns.Add(dc18);
            dtScore.Columns.Add(dc19);
            #endregion

            #region 加载标准
            ExcelAccess excel = new ExcelAccess();
            dsCritical = excel.GetExcelData(Application.StartupPath + "\\管制员打分.xls");
            #endregion
        }

        #region 各打分项计算逻辑
        /// <summary>
        /// 管制学历
        /// </summary>
        /// <param name="atcEducation"></param>
        /// <param name="atcDegree"></param>
        /// <returns></returns>
        private string getEducationScore(string personId)
        {
            String selectAtcBodyCheckSql = "select t.getdegree,t.geteducation from tb_education_ctrl t where t.personid='" + personId + "' order by t.graduationdatetime desc";
            DataTable dtEducation = OracleAccess.GetInstance().GetDatatable(selectAtcBodyCheckSql);

            string atcEducation = "";
            string atcDegree = "";
            ////可能最近取得的学历不是最高学历，此处为获取该人员的最高学历
            //if (dtEducation != null && dtEducation.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dtEducation.Rows.Count; i++)
            //    {
            //        if (atcDegree.Length == 0 && atcEducation.Length == 0)
            //        { 
            //            if(dtEducation.Rows[0]["geteducation"].ToString()=="博士研究生" || dtEducation.Rows[0]["getdegree"].ToString()=="博士")
            //        }
            //    }
            //}
            //else
            //{
            //    return "0";
            //}
            if (dsCritical != null)
            {
                DataTable dt = dsCritical.Tables["学历要求$"];
                if (dt != null)
                {
                    if (dtEducation != null && dtEducation.Rows.Count > 0)
                    {
                        atcEducation = dtEducation.Rows[0]["geteducation"].ToString();
                        atcDegree = dtEducation.Rows[0]["getdegree"].ToString();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (atcEducation == dt.Rows[i]["管制学历"].ToString() && atcDegree == dt.Rows[i]["管制学位"].ToString())
                            {
                                return dt.Rows[i]["管制分数"].ToString();
                            }
                        }
                    }
                    else
                    {
                        return "0";
                    }

                }
            }
            return "0";
        }
        /// <summary>
        /// 非管制学历
        /// </summary>
        /// <param name="personId"></param>
        /// <returns></returns>
        private string getEducationUncontrolScore(string personId, DateTime worksince)
        {
            String selectAtcBodyCheckSql = "select t.getdegree,t.geteducation,t.GRADUATIONDATETIME from TB_EDUCATION_UNCTRL t where t.personid='" + personId + "' order by t.graduationdatetime desc";
            DataTable dtEducation = OracleAccess.GetInstance().GetDatatable(selectAtcBodyCheckSql);

            if (dtEducation != null && dtEducation.Rows.Count > 0)
            {
                string education = dtEducation.Rows[0]["geteducation"].ToString();
                string degree = dtEducation.Rows[0]["getdegree"].ToString();
                DateTime time = DateTime.Parse(dtEducation.Rows[0]["GRADUATIONDATETIME"].ToString());
                int gotYear = 1;
                try
                {
                    if ((time - worksince).Days / 365 <= 1)
                    {
                        gotYear = 1;
                    }
                    else
                    {
                        gotYear = (time - worksince).Days / 365 + 1;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                if (dsCritical != null)
                {
                    DataTable dt = dsCritical.Tables["学历要求$"];
                    if (dt != null)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            if (education == dt.Rows[i]["普通学历"].ToString() && degree == dt.Rows[i]["普通学位"].ToString())
                            {
                                return (double.Parse(dt.Rows[i]["加分分数"].ToString()) / gotYear).ToString();
                            }
                        }
                    }
                }
            }
            return "0";
        }
        /// <summary>
        /// 体检
        /// </summary>
        /// <param name="birthday"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        private string getBodyCheckScore(DateTime birthday, String Id)
        {

            DataTable dtBodyCheck = dsCritical.Tables["体检要求$"];
            if (dtBodyCheck == null || dtBodyCheck.Rows.Count == 0)
            {
                return "0";
            }
            String selectAtcBodyCheckSql = "select checkuplevel,to_char(gotdate,'yyyy-MM-dd') as gotdate from tb_bodycheckinfo where personid = '" + Id + "' order by gotdate desc";
            DataTable dt = OracleAccess.GetInstance().GetDatatable(selectAtcBodyCheckSql);
            if (dt != null && dt.Rows.Count > 0)
            {
                String checkuplevel = dt.Rows[0]["checkuplevel"].ToString();
                DateTime gotdate = DateTime.Parse(dt.Rows[0]["gotdate"].ToString());

                for (int i = 0; i < dtBodyCheck.Rows.Count; i++)
                {
                    if (checkuplevel == null)
                    {
                        return "0";
                    }
                    else
                    {
                        int startAge = Int32.Parse(dtBodyCheck.Rows[i]["起始年龄"].ToString());
                        int endAge = Int32.Parse(dtBodyCheck.Rows[i]["终止年龄"].ToString());
                        int restrictYear = Int32.Parse(dtBodyCheck.Rows[i]["时间限制（年）"].ToString());
                        int score = Int32.Parse(dtBodyCheck.Rows[i]["分数"].ToString());
                        if (dtBodyCheck.Rows[i]["体检级别"].ToString() == checkuplevel)
                        {
                            if (DateTime.Now <= birthday.AddYears(endAge) && DateTime.Now > birthday.AddYears(startAge)
                                && DateTime.Now <= gotdate.AddYears(restrictYear))
                            {
                                return score.ToString();
                            }
                        }
                        else
                        {
                            return "0";
                        }
                    }
                }
            }
            return "0";
        }
        /// <summary>
        /// 英语
        /// </summary>
        /// <param name="currentEnglishType"></param>
        /// <param name="currentEnglishLevel"></param>
        /// <returns></returns>
        private string getEnglishScore(String currentEnglishType, String currentEnglishLevel)
        {

            DataTable dt = dsCritical.Tables["英语要求$"];
            if (dt == null || dt.Rows.Count == 0)
            {
                return "0";
            }
            String currentenglishtype = currentEnglishType;
            String currentenglishlevel = currentEnglishLevel;

            if (currentenglishtype == null)
            {
                return "0";
            }
            else
            {
                if (currentenglishlevel != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["英语类别"].ToString() == currentenglishtype)
                        {
                            if (currentenglishlevel == dt.Rows[i]["英语等级"].ToString())
                            {
                                return dt.Rows[i]["分数"].ToString();
                            }
                        }
                    }
                }
                else
                {
                    return "0";
                }
            }
            return "0";
        }
        /// <summary>
        /// 职级职等
        /// </summary>
        /// <param name="currentDutyLevel"></param>
        /// <param name="currentPostLevel"></param>
        /// <returns></returns>
        private string getAtcLevelScore(String currentDutyLevel, String currentPostLevel)
        {
            DataTable dt = dsCritical.Tables["管制员等级要求$"];
            if (dt == null || dt.Rows.Count == 0)
            {
                return "0";
            }
            String currentdutylevel = currentDutyLevel;
            String currentpostlevel = currentPostLevel;

            //判断职级
            if (currentdutylevel == null || currentPostLevel == null)
            {
                return "0";
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["职等"].ToString() == currentpostlevel && dt.Rows[i]["职级"].ToString() == currentdutylevel)
                    {
                        return dt.Rows[i]["分数"].ToString();
                    }
                }
            }

            return "0";
        }
        /// <summary>
        /// 年龄
        /// </summary>
        /// <param name="birthDay"></param>
        /// <returns></returns>
        private string getAgeScore(DateTime birthDay)
        {
            DataTable dt = dsCritical.Tables["年龄要求$"];
            if (dt == null || dt.Rows.Count == 0)
            {
                return "0";
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["起始年龄"] != null && dt.Rows[i]["结束年龄"] != null)
                {
                    int sAge = Int32.Parse(dt.Rows[i]["起始年龄"].ToString());
                    int eAge = Int32.Parse(dt.Rows[i]["结束年龄"].ToString());

                    if (birthDay.AddYears(sAge) < DateTime.Now && birthDay.AddYears(eAge) >= DateTime.Now)
                    {
                        return dt.Rows[i]["分数"].ToString();
                    }
                }
            }
            return "0";
        }
        /// <summary>
        /// 执照
        /// </summary>
        /// <param name="currentpost"></param>
        /// <param name="licenseList"></param>
        /// <returns></returns>
        private string getPermitScore(String currentpost, String licenseList)
        {
            DataTable dt = dsCritical.Tables["执照要求$"];
            if (dt == null || dt.Rows.Count == 0)
            {
                return "0";
            }

            int addScore = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["岗位"] == null || dt.Rows[i]["岗位"].ToString() == "")
                {
                    if (dt.Rows[i]["分数"] != null)
                    {
                        addScore = Int32.Parse(dt.Rows[i]["分数"].ToString());
                        break;
                    }
                }
            }

            #region

            Dictionary<string, double> dic = new Dictionary<string, double>();
            double PostTotalScore = 0;
            double perScore = 0;
            string[] licenseArray = licenseList.Split(',');
            List<string> lst = new List<string>();
            List<string> lstC = new List<string>();

            lst.Clear();
            if (licenseArray.Length > 1)
            {
                lst = licenseArray.ToList<string>();
            }
            else if (licenseArray.Length == 1)
            {
                if (licenseArray[0].Length > 0)
                    lst.Add(licenseArray[0]);
            }
            dic.Clear();
            string criteriaStr = "";
            for (int i = 0; i < dt.Rows.Count; i++) //从标准中找到相应岗位的信息
            {

                if (dt.Rows[i]["岗位"] != null || dt.Rows[i]["岗位"].ToString() != "")
                {
                    if (dt.Rows[i]["岗位"].ToString() == currentpost)
                    {

                        double perPostTotalScore = double.Parse(dt.Rows[i]["分数"].ToString());
                        string criteria = dt.Rows[i]["执照(单岗位)"].ToString();
                        if (criteriaStr.Length > 0)
                            criteriaStr += "," + criteria;
                        else
                            criteriaStr += criteria;
                        PostTotalScore += perPostTotalScore;
                        List<string> lstCriteria = new List<string>();
                        if (criteria.Contains(","))
                        {
                            lstCriteria = criteria.Split(',').ToList<string>();
                        }
                        else
                        {
                            lstCriteria.Add(criteria);
                        }
                        lstC.AddRange(lstCriteria);
                        for (int j = 0; j < lstCriteria.Count; j++)
                        {
                            dic.Add(lstCriteria[j], perPostTotalScore / lstCriteria.Count);
                        }
                    }
                }
            }
            for (int i = 0; i < lst.Count; i++)
            {
                if (lstC.Contains(lst[i]))
                {
                    lstC.Remove(lst[i]);
                    lst.Remove(lst[i]);
                    i--;
                }

            }
            if (lstC.Count > 0)
            {
                for (int i = 0; i < lstC.Count; i++)
                {
                    double per = dic[lstC[i]];
                    PostTotalScore -= per;
                }
            }
            if (lst.Count > 0)
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    PostTotalScore += addScore;
                }
            }
            return PostTotalScore.ToString();
            #endregion
            //string[] licenseArray = licenseList.Split(',');
            //List<string> lst = new List<string>();
            //if (currentpost != null)
            //{
            //    for (int i = 0; i < dt.Rows.Count; i++)
            //    {
            //        if (dt.Rows[i]["岗位"] != null || dt.Rows[i]["岗位"].ToString() != "")
            //        {
            //            if (dt.Rows[i]["岗位"].ToString() == currentpost)
            //            {
            //                lst.Clear();
            //                if (licenseArray.Length > 1)
            //                {
            //                    lst = licenseArray.ToList<string>();
            //                }
            //                else if (licenseArray.Length == 1)
            //                {
            //                    if (licenseArray[0].Length > 0)
            //                        lst.Add(licenseArray[0]);
            //                }
            //                double Score = Int32.Parse(dt.Rows[i]["分数"].ToString());

            //                string criteriaStr = dt.Rows[i]["执照"].ToString();
            //                if (!string.IsNullOrEmpty(criteriaStr))
            //                {
            //                    List<string> lstCriteria = new List<string>();
            //                    if (criteriaStr.Contains(","))
            //                    {
            //                        lstCriteria = criteriaStr.Split(',').ToList<string>();
            //                    }
            //                    else
            //                    {
            //                        lstCriteria.Add(criteriaStr);
            //                    }
            //                    double per = double.Parse((Score / lstCriteria.Count).ToString());
            //                    if (lst.Count > 0)
            //                        for (int j = 0; j < lstCriteria.Count; j++)
            //                        {
            //                            if (lst.Contains(lstCriteria[j]))
            //                            {
            //                                lst.Remove(lstCriteria[j]);
            //                                lstCriteria.Remove(lstCriteria[j]);
            //                                j--;
            //                            }
            //                        }
            //                    if (lstCriteria.Count > 0)
            //                    {
            //                        Score = double.Parse(Math.Round(Score - per * lstCriteria.Count, 0).ToString());
            //                    }
            //                    if (lst.Count > 0)
            //                    {
            //                        Score = Score + addScore * lst.Count;
            //                    }

            //                    return Score.ToString();
            //                }
            //                else
            //                {
            //                    return "0";
            //                }


            //            }


            //        }
            //    }
            //}
            return "0";
        }
        /// <summary>
        /// 工作年限
        /// </summary>
        /// <param name="workSince"></param>
        /// <returns></returns>
        private string getWorkYearsScore(DateTime workSince, DateTime controlWorkSince)
        {

            DataTable dt = dsCritical.Tables["工作年限要求$"];
            if (dt == null || dt.Rows.Count == 0)
            {
                return "0";
            }

            double score = 0;
            if (workSince != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["起始时间(管制)"] != null && dt.Rows[i]["结束时间(管制)"] != null)
                    {
                        if (dt.Rows[i]["起始时间(管制)"] != DBNull.Value && dt.Rows[i]["结束时间(管制)"] != DBNull.Value)
                        {
                            int sYear = Int32.Parse(dt.Rows[i]["起始时间(管制)"].ToString());
                            int eYear = Int32.Parse(dt.Rows[i]["结束时间(管制)"].ToString());

                            if (workSince.AddYears(sYear) <= DateTime.Now && workSince.AddYears(eYear) > DateTime.Now)
                            {
                                score += Convert.ToDouble(dt.Rows[i]["分数(管制)"].ToString());
                            }
                        }
                    }

                }
            }
            if (controlWorkSince != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["起始时间(普通)"] != null && dt.Rows[i]["结束时间(普通)"] != null)
                    {
                        int sYear = Int32.Parse(dt.Rows[i]["起始时间(普通)"].ToString());
                        int eYear = Int32.Parse(dt.Rows[i]["结束时间(普通)"].ToString());

                        if (workSince.AddYears(sYear) <= DateTime.Now && workSince.AddYears(eYear) > DateTime.Now)
                        {
                            score += Convert.ToDouble(dt.Rows[i]["分数(普通)"].ToString());
                        }
                    }

                }
            }
            return score.ToString();

        }
        /// <summary>
        /// 管制职务
        /// </summary>
        /// <param name="Duty"></param>
        /// <returns></returns>
        private string getDutyScore(String Duty)
        {
            DataTable dt = dsCritical.Tables["管制职务分数$"];
            if (dt == null || dt.Rows.Count == 0)
            {
                return "0";
            }
            String duty = Duty;

            if (duty != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["职务"].ToString() == duty)
                    {
                        return dt.Rows[i]["分数"].ToString();
                    }
                }

            }
            return "0";

        }
        /// <summary>
        /// 赴外培训
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string getAbroadTrainAScore(String id)
        {
            DataTable dtCriteria = dsCritical.Tables["赴外培训$"];
            if (dtCriteria == null || dtCriteria.Rows.Count == 0)
            {
                return "0";
            }
            String baseId = id;
            double upLimitScore = 0;
            double totalScore = 0;
            int timeScope = 0;
            for (int i = 0; i < dtCriteria.Rows.Count; i++)
            {
                if (dtCriteria.Rows[i]["加分上限"].ToString().Length > 0)
                {
                    upLimitScore = double.Parse(dtCriteria.Rows[i]["加分上限"].ToString());
                }
                //取消时间范围 @2013-6-17
                //if (dtCriteria.Rows[i]["时间范围"].ToString().Length > 0)
                //{
                //    timeScope = Int32.Parse(dtCriteria.Rows[i]["时间范围"].ToString());
                //}
            }

            //查询赴外培训数量及时间
            String selectAtctrainAboardSql = "select y.* from TB_PERSONABROADTRAININFO y" +
                                             " where personid = '" + baseId + "'";

            DataTable dt = OracleAccess.GetInstance().GetDatatable(selectAtctrainAboardSql);

            int cnt = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                //int yearRange = Int32.Parse(dtCriteria.Rows[0]["时间范围"].ToString());
                int freq = Int32.Parse(dtCriteria.Rows[0]["次数"].ToString());
                double score = double.Parse(dtCriteria.Rows[0]["分数"].ToString());
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DateTime dtime = DateTime.Parse(dt.Rows[i]["enddate"].ToString());
                    //if (dtime.AddYears(yearRange) >= DateTime.Now)
                    {
                        cnt++;
                    }
                }
                totalScore = (cnt / freq) * score;
                if (totalScore >= upLimitScore)
                {
                    return upLimitScore.ToString();
                }
                else
                {
                    return totalScore.ToString();
                }

            }
            return "0";
        }
        /// <summary>
        /// 岗位培训
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string getDutyTrainScore(String id, DateTime controlWorkSince)
        {

            DataTable dtCriteria = dsCritical.Tables["岗位培训$"];
            if (dtCriteria == null || dtCriteria.Rows.Count == 0)
            {
                return "0";
            }
            String baseId = id;
            double upLimitScore = 0;//分数上限
            double addUpLimit = 0;
            double totalScore = 0;
            int timeScope = 0;
            int workYears = (DateTime.Now - controlWorkSince).Days / 365;
            for (int i = 0; i < dtCriteria.Rows.Count; i++)
            {
                if (dtCriteria.Rows[i]["分数上限（基础项）"].ToString().Length > 0)
                {
                    upLimitScore = double.Parse(dtCriteria.Rows[i]["分数上限（基础项）"].ToString());
                }
                if (dtCriteria.Rows[i]["加分上限（加分项）"].ToString().Length > 0)
                {
                    addUpLimit = double.Parse(dtCriteria.Rows[i]["加分上限（加分项）"].ToString());
                }
                if (dtCriteria.Rows[i]["时间范围（加分项）"].ToString().Length > 0)
                {
                    timeScope = Int32.Parse(dtCriteria.Rows[i]["时间范围（加分项）"].ToString());
                }
            }


            /*#########################---------------基础项-------------##############################*/
            String baseTrainDutySql = @"select personid,
                                           traintype,
                                           to_char(t.enddate,'yyyy') as datetime,
                                           sum(t.theorytime) + sum(t.simulatetime) + sum(t.operatetime) as courseCount
                                      from TB_PERSONPOSTTRAININFO t
                                      group by personid,
                                           traintype,to_char(t.enddate,'yyyy') having personid = '" + baseId + "'";

            DataTable dtBase = OracleAccess.GetInstance().GetDatatable(baseTrainDutySql);
            int totalCount = Convert.ToInt32((DateTime.Now - controlWorkSince).TotalDays / 365);
            if (dtBase != null && dtBase.Rows.Count > 0)
            {
                for (int i = 0; i < dtCriteria.Rows.Count; i++)
                {
                    if (dtCriteria.Rows[i]["培训类别（基础项）"].ToString().Length > 0)
                    {

                        int RealCount = 0;
                        double CritariaCourseCount = Convert.ToDouble(dtCriteria.Rows[i]["时间要求（基础项）"].ToString());
                        double upScore = Convert.ToDouble(dtCriteria.Rows[i]["分数上限（基础项）"].ToString());
                        for (int j = 0; j < dtBase.Rows.Count; j++)
                        {
                            if (dtCriteria.Rows[i]["培训类别（基础项）"].ToString() == dtBase.Rows[j]["traintype"].ToString())
                            {
                                double courseCount = Convert.ToDouble(dtBase.Rows[j]["courseCount"].ToString());

                                if (CritariaCourseCount <= courseCount)
                                {
                                    RealCount++;
                                }
                            }
                        }
                        totalScore += upScore * RealCount / totalCount;

                    }
                }
            }

            totalScore = Round(totalScore, 0);


            /*#########################---------------附加项-------------##############################*/
            String trainDutySql = "select * from TB_PERSONPOSTTRAININFO where personid = '" + baseId + "'";

            DataTable dt = OracleAccess.GetInstance().GetDatatable(trainDutySql);
            double additionScore = 0;
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int j = 0; j < dtCriteria.Rows.Count; j++)
                {
                    int cnt = 0;
                    string type = dtCriteria.Rows[j]["培训类别（加分项）"].ToString();
                    int freq = Int32.Parse(dtCriteria.Rows[j]["满足次数（加分项）"].ToString());
                    double score = double.Parse(dtCriteria.Rows[j]["分数（加分项）"].ToString());
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DateTime gotDate = DateTime.Parse(dt.Rows[i]["ENDDATE"].ToString());
                        if (dt.Rows[i]["traintype"].ToString() == type && gotDate.AddYears(timeScope) >= DateTime.Now)
                        {
                            cnt++;
                        }
                    }
                    additionScore += (cnt / freq) * score;
                    if (additionScore >= upLimitScore)
                    {
                        additionScore = upLimitScore; break;
                    }

                }

                return (totalScore + additionScore).ToString();
            }
            return "0";

        }
        /// <summary>
        /// 奖惩加分
        /// </summary>
        /// <param name="id"></param>
        /// <param name="workSince"></param>
        /// <returns></returns>
        private string getAddScore(String id, DateTime workSince)
        {

            DataTable dtCriteria = dsCritical.Tables["奖励分数$"];
            if (dtCriteria == null || dtCriteria.Rows.Count == 0)
            {
                return "0";
            }
            String baseId = id;

            String sql = "select * from tb_rewardinfo  where personid = '" + baseId + "'";

            DataTable dtAward = OracleAccess.GetInstance().GetDatatable(sql);
            sql = "select * from tb_punishinfo where personid = '" + baseId + "'";
            DataTable dtPunish = OracleAccess.GetInstance().GetDatatable(sql);
            double scores = 0;
            int cnt = 0;
            int rewardYearScope = 0;
            int punishYearScope = 0;

            //for (int i = 0; i < dtCriteria.Rows.Count; i++)
            //{
            //    if (dtCriteria.Rows[i]["奖励时间范围"].ToString().Length > 0)
            //    {
            //        rewardYearScope = Int32.Parse(dtCriteria.Rows[i]["奖励时间范围"].ToString());
            //    }
            //    if (dtCriteria.Rows[i]["惩罚时间范围"].ToString().Length > 0)
            //    {
            //        punishYearScope = Int32.Parse(dtCriteria.Rows[i]["惩罚时间范围"].ToString());
            //    }
            //}
            if (dtAward != null && dtAward.Rows.Count > 0)
            {
                for (int j = 0; j < dtCriteria.Rows.Count; j++)
                {
                    cnt = 0;
                    string level = dtCriteria.Rows[j]["奖励级别"].ToString();
                    double sScore = double.Parse(dtCriteria.Rows[j]["分数"].ToString());
                    for (int i = 0; i < dtAward.Rows.Count; i++)
                    {
                        DateTime gotDate = DateTime.Parse(dtAward.Rows[i]["REWARDDATE"].ToString());
                        if (dtAward.Rows[i]["REWARDLEVEL"].ToString() == level)
                        {
                            cnt++;
                        }
                    }
                    scores += cnt * sScore;
                }
            }
            if (dtPunish != null && dtPunish.Rows.Count > 0)
            {
                bool flag = false;//是否存在吊销执照情况
                int revokeCriteriaCount = 0;//吊销执照次数标准
                double revokeCriteriaScore = 0;//吊销执照加分标准
                int revokeCount = 0;//吊销执照次数
                int suspendCriteriaCount = 0;//暂停执照次数标准
                double revokeScore = 0;//吊销执照得分

                //读取标准
                for (int i = 0; i < dtCriteria.Rows.Count; i++)
                {
                    if (dtCriteria.Rows[i]["惩罚级别"].ToString() == "吊销执照")
                    {
                        revokeCriteriaScore = double.Parse(dtCriteria.Rows[i]["得分"].ToString());
                        revokeCriteriaCount = int.Parse(dtCriteria.Rows[i]["惩罚次数"].ToString());
                    }
                    if (dtCriteria.Rows[i]["惩罚级别"].ToString() == "暂停执照")
                    {
                        suspendCriteriaCount = int.Parse(dtCriteria.Rows[i]["惩罚次数"].ToString());

                    }
                }
                //分析实际数据
                for (int i = 0; i < dtPunish.Rows.Count; i++)
                {
                    DateTime gotDate = DateTime.Parse(dtPunish.Rows[i]["happendate"].ToString());
                    if (dtPunish.Rows[i]["PUNISHTYPE"].ToString() == "吊销执照")
                    {
                        revokeCount++;
                        flag = true;
                    }
                }
                if (!flag)
                {
                    scores += revokeCriteriaScore * (revokeCount / revokeCriteriaCount);
                    cnt = 0;
                    for (int i = 0; i < dtPunish.Rows.Count; i++)
                    {
                        DateTime gotDate = DateTime.Parse(dtPunish.Rows[i]["happendate"].ToString());
                        if (dtPunish.Rows[i]["PUNISHTYPE"].ToString() == "暂停执照")
                        {
                            cnt++;
                        }
                    }
                    if (cnt < suspendCriteriaCount)
                    {
                        int years = Convert.ToInt32((DateTime.Now - workSince).TotalDays / 365);
                        scores += years / (cnt + 1);
                    }
                }
            }
            else
            {
                //没有处罚 +分等于工作年限
                scores += Convert.ToInt32((DateTime.Now - workSince).TotalDays / 365);
            }
            return scores.ToString();
        }

        /// <summary>
        /// 行政职务加分
        /// </summary>
        /// <param name="duty"></param>
        /// <returns></returns>
        private string getAdminPostScore(String duty)
        {
            DataTable dt = dsCritical.Tables["行政职务分数$"];
            if (dt == null || dt.Rows.Count == 0)
            {
                return "0";
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["行政职务"] != null && dt.Rows[i]["行政职务"].ToString() != "")
                {
                    if (dt.Rows[i]["分数"] != null && dt.Rows[i]["分数"].ToString() == duty)
                    {
                        return dt.Rows[i]["分数"].ToString();
                    }
                }
            }
            return "0";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string getTeacherAndCheckerScore(string id)
        {
            DataTable dt = dsCritical.Tables["检查员和教员$"];
            if (dt == null || dt.Rows.Count == 0)
            {
                return "0";
            }
            double score = 0;
            string sql = "select * from tb_checkerinfo t where personid='" + id + "'";

            DataTable dtchecker = OracleAccess.GetInstance().GetDatatable(sql);

            if (dtchecker != null && dtchecker.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[0]["管制水平级别"].ToString() == "管制检察员")
                    {
                        score += double.Parse(dt.Rows[0]["分数"].ToString());
                        break;
                    }
                }
            }

            sql = "select * from tb_ctrlteacherinfo t where personid='" + id + "'";

            DataTable dtteacher = OracleAccess.GetInstance().GetDatatable(sql);

            if (dtteacher != null && dtteacher.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[0]["管制水平级别"].ToString() == "管制教员")
                    {
                        score += double.Parse(dt.Rows[0]["分数"].ToString());
                        break;
                    }
                }
            }
            return score.ToString();
        }
        /// <summary>
        /// 放单
        /// </summary>
        /// <param name="currentpost"></param>
        /// <param name="licenseList"></param>
        /// <param name="personId"></param>
        /// <returns></returns>
        private string getCheckScore(String currentpost, String licenseList, String personId)
        {
            DataTable dt = dsCritical.Tables["放单$"];
            if (dt == null || dt.Rows.Count == 0)
            {
                return "0";
            }
            string sql = "select personid,max(licsencetype) as license from (select * from tb_permitcheckinfo where checkresult='是' ) a group by personid,licsencetype having personid='" + personId + "'";

            DataTable dtCheck = OracleAccess.GetInstance().GetDatatable(sql);
            int addScore = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["岗位"] == null || dt.Rows[i]["岗位"].ToString() == "")
                {
                    if (dt.Rows[i]["分数"] != null)
                    {
                        addScore = Int32.Parse(dt.Rows[i]["分数"].ToString());
                        break;
                    }
                }
            }

            #region

            Dictionary<string, double> dic = new Dictionary<string, double>();
            double PostTotalScore = 0;
            double perScore = 0;
            string[] licenseArray = licenseList.Split(',');
            List<string> lst = new List<string>();
            List<string> lstC = new List<string>();

            lst.Clear();
            if (licenseArray.Length > 1)
            {
                lst = licenseArray.ToList<string>();
            }
            else if (licenseArray.Length == 1)
            {
                if (licenseArray[0].Length > 0)
                    lst.Add(licenseArray[0]);
            }
            dic.Clear();
            string criteriaStr = "";
            for (int i = 0; i < dt.Rows.Count; i++) //从标准中找到相应岗位的信息
            {

                if (dt.Rows[i]["岗位"] != null || dt.Rows[i]["岗位"].ToString() != "")
                {
                    if (dt.Rows[i]["岗位"].ToString() == currentpost)
                    {

                        double perPostTotalScore = double.Parse(dt.Rows[i]["分数"].ToString());
                        string criteria = dt.Rows[i]["执照(单岗位)"].ToString();
                        if (criteriaStr.Length > 0)
                            criteriaStr += "," + criteria;
                        else
                            criteriaStr += criteria;
                        PostTotalScore += perPostTotalScore;
                        List<string> lstCriteria = new List<string>();
                        if (criteria.Contains(","))
                        {
                            lstCriteria = criteria.Split(',').ToList<string>();
                        }
                        else
                        {
                            lstCriteria.Add(criteria);
                        }
                        lstC.AddRange(lstCriteria);
                        for (int j = 0; j < lstCriteria.Count; j++)
                        {
                            dic.Add(lstCriteria[j], perPostTotalScore / lstCriteria.Count);
                        }
                    }
                }

            }
            for (int i = 0; i < lst.Count; i++)
            {
                if (lstC.Contains(lst[i]))
                {
                    bool flag = false;//在放单中是否同执照的放单
                    for (int j = 0; j < dtCheck.Rows.Count; j++)
                    {
                        string license = dtCheck.Rows[j]["license"].ToString();
                        if (license == lst[i])
                        {
                            flag = true;
                            break;
                        }
                    }
                    //有该执照而没放单，则减去改执照应的分数
                    if (!flag)
                    {
                        double per = dic[lst[i]];
                        PostTotalScore -= per;
                    }
                    lstC.Remove(lst[i]);
                    lst.Remove(lst[i]);

                    i--;
                }

            }
            if (lstC.Count > 0)//没有该执照
            {
                for (int i = 0; i < lstC.Count; i++)
                {
                    double per = dic[lstC[i]];
                    PostTotalScore -= per;
                }

            }
            if (lst.Count > 0)//其他执照
            {
                for (int i = 0; i < lst.Count; i++)
                {
                    PostTotalScore += addScore;
                }
            }
            return PostTotalScore.ToString();
            #endregion
        }
        #endregion

        /// <summary>
        /// 分析
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_analyse_Click(object sender, EventArgs e)
        {
            this.btn_save.Enabled = false;
            this.btn_selectAll.Enabled = false;
            dtScore.Clear();
            if (startAge.Value > endAge.Value)
            {
                MessageBox.Show("开始年龄应小于结束年龄！", "警告");
                return;
            }
            string personName = txt_name.Text;
            string Idcard = txt_Idcard.Text;
            #region 查询人员数据

            string sqlStr = "select t.*,getlicensetype(t.id) as permitList " +
                                "from TB_PERSONBASEINFO t,  tb_area k , tb_station s " +
                                "where t.station = s.stationid " +
                                "and t.area = k.areaid " +

                                "and (t.currentpost like '%区域%' or t.currentpost like '%进近%' or " +
                                "t.currentpost like '%塔台%') " +

                                "and (s.stationname not like '%机关%' and s.stationname not like '%培训中心%') " +
                                "and station like '00%' " +
                                "and t.state = 0";
            if (!string.IsNullOrEmpty(personName))
            {
                sqlStr += " and t.personname like '%" + personName + "%' ";
            }
            if (!string.IsNullOrEmpty(Idcard))
            {
                sqlStr += " and t.idcard='" + Idcard + "' ";
            }

            //查询人员数据
            DataTable dt = OracleAccess.GetInstance().GetDatatable(sqlStr);//得到人员信息集合，遍历集合取值

            #endregion

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("没有查询到人员。", "提示");
                return;
            }

            if (dt != null)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string workSince = "CONTROLWORKSINCE";
                    string personId = dt.Rows[i]["id"].ToString();
                    string idcard = dt.Rows[i]["idcard"].ToString();

                    #region 计算分项分值

                    //学历分数
                    graedu = double.Parse(getEducationScore(personId)) +
                        double.Parse(getEducationUncontrolScore(personId, DateTime.Parse(dt.Rows[i][workSince].ToString())));
                    //年龄分数
                    graold = double.Parse(getAgeScore(DateTime.Parse(dt.Rows[i]["birthday"].ToString())));
                    //执照分数
                    graPermit = double.Parse(getPermitScore(dt.Rows[i]["CURRENTPOST"].ToString(), dt.Rows[i]["permitList"].ToString()));
                    //工作年限分数
                    graWordate = double.Parse(getWorkYearsScore(DateTime.Parse(dt.Rows[i]["workSince"].ToString()), DateTime.Parse(dt.Rows[i][workSince].ToString())));
                    //等级分数
                    graLevel = double.Parse(getAtcLevelScore(dt.Rows[i]["CURRENTDUTYLEVEL"].ToString(), dt.Rows[i]["CURRENTPOSTLEVEL"].ToString()));
                    //英语分数
                    graEnglish = double.Parse(getEnglishScore(dt.Rows[i]["CURRENTENGLISHTYPE"].ToString(), dt.Rows[i]["CURRENTENGLISHLEVEL"].ToString()));
                    //体检分数
                    graCheckbody = double.Parse(getBodyCheckScore(DateTime.Parse(dt.Rows[i]["birthday"].ToString()), personId));
                    //岗位加分
                    graDuty = double.Parse(getDutyScore(dt.Rows[i]["duty"].ToString()));
                    //岗位培训分数
                    gratrainDuty = double.Parse(getDutyTrainScore(personId, DateTime.Parse(dt.Rows[i][workSince].ToString()))); ;
                    //外培训分数
                    gratrainAboard = double.Parse(getAbroadTrainAScore(personId));
                    //奖励加分
                    graAdd = double.Parse(getAddScore(personId, DateTime.Parse(dt.Rows[i]["CONTROLWORKSINCE"].ToString())));
                    //行政职务
                    graHighPost = double.Parse(getAdminPostScore(dt.Rows[i]["DUTY"].ToString()));

                    //教员和检查员
                    graTeacherAndChecker = double.Parse(getTeacherAndCheckerScore(personId));

                    graPermitCheck = double.Parse(getCheckScore(dt.Rows[i]["CURRENTPOST"].ToString(), dt.Rows[i]["permitList"].ToString(),personId));
                    #endregion

                    //计算总分
                    total = graedu + graold + graPermit + graWordate + graLevel + graEnglish + graCheckbody + gratrainDuty + gratrainAboard + graAdd + graHighPost + graTeacherAndChecker + graPermitCheck;

                    #region 存入dataTable
                    //
                    DataRow dr = dtScore.NewRow();
                    dr["personid"] = personId;
                    dr["idcard"] = idcard;
                    dr["CtrlYear"] = DateTime.Parse(dt.Rows[i]["CONTROLWORKSINCE"].ToString()).ToShortDateString();
                    dr["personname"] = dt.Rows[i]["personname"].ToString();
                    dr["Date"] = DateTime.Now.ToString();
                    dr["graedu"] = Math.Round(graedu, 1);
                    dr["graold"] = Math.Round(graold, 1);
                    dr["graPermit"] = Math.Round(graPermit, 1);
                    dr["graWordate"] = Math.Round(graWordate, 1);
                    dr["graLevel"] = Math.Round(graLevel, 1);
                    dr["graEnglish"] = Math.Round(graEnglish, 1);
                    dr["graCheckbody"] = Math.Round(graCheckbody, 1);
                    dr["gratrainDuty"] = Math.Round(gratrainDuty, 1);
                    dr["graDuty"] = Math.Round(graDuty, 1);
                    dr["gratrainAboard"] = Math.Round(gratrainAboard, 1);
                    dr["graAdd"] = Math.Round(graAdd, 1);
                    dr["total"] = Math.Round(total, 1);

                    dr["PermitCheck"] = Math.Round(graPermitCheck, 1);
                    dr["CtrlDuty"] = Math.Round(graTeacherAndChecker, 1);
                    dr["HighPost"] = Math.Round(graHighPost, 1);
                    dtScore.Rows.Add(dr);
                    #endregion
                }
            }

            try
            {
                this.dataGridView1.DataSource = dtScore;

                this.btn_save.Enabled = true;
                this.btn_selectAll.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if ((bool)((DataGridViewCheckBoxCell)row.Cells["Column15"]).Value)
                {
                    string sql = "insert into atcgrade (personname,EDUCATIONGRA,AGEGRA,LICENSEGRA,WORKAGEGRA,ATCLEVELGRA,ENGLISHGRA,BODYCHECKGRA,DUTYPOSTGRA,TRAINPOSTGRA,TRAINABOARDGRA,REWARDGRA,GOTDATE,TOTAL,ID,IDCARD,CTRLYEAR,POST,TEACHERANDCHECKER,PermitCheck) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}',to_date('{12}','yyyy/MM/dd hh24:mi:ss'),'{13}','{14}','{15}','{16}','{17}','{18}','{19}')";
                    string personId = row.Cells["Column16"].Value.ToString();
                    sql = string.Format(sql, row.Cells["Column1"].Value.ToString(), row.Cells["Column2"].Value.ToString(), row.Cells["Column3"].Value.ToString(), row.Cells["Column4"].Value.ToString(), row.Cells["Column5"].Value.ToString(), row.Cells["Column6"].Value.ToString(), row.Cells["Column7"].Value.ToString(), row.Cells["Column8"].Value.ToString(), row.Cells["Column9"].Value.ToString(), row.Cells["Column10"].Value.ToString(), row.Cells["Column11"].Value.ToString(), row.Cells["Column12"].Value.ToString(), DateTime.Parse(row.Cells["Column14"].Value.ToString()), row.Cells["Column13"].Value.ToString(), row.Cells["Column16"].Value.ToString(), row.Cells["Column17"].Value.ToString(), row.Cells["Column18"].Value.ToString(), row.Cells["Column19"].Value.ToString(), row.Cells["Column20"].Value.ToString(), row.Cells["Column21"].Value.ToString());


                    try
                    {
                        OracleAccess.GetInstance().ExecuteNonQuery("delete atcgrade where id='" + personId + "'");
                        OracleAccess.GetInstance().ExecuteNonQuery(sql);
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("保存失败！", "提示");
                    }
                }
            }
            MessageBox.Show("保存成功！", "提示");
        }

        private void btn_selectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Column15"].Value == null)
                    row.Cells["Column15"].Value = true;
                else
                    row.Cells["Column15"].Value = !((bool)(row.Cells["Column15"].Value));
            }
        }


        /// <summary>
        /// 实现数据的四舍五入法
        /// </summary>
        /// <param name="v">要进行处理的数据</param>
        /// <param name="x">保留的小数位数</param>
        /// <returns>四舍五入后的结果</returns>
        private double Round(double v, int x)
        {
            bool isNegative = false;
            //如果是负数
            if (v < 0)
            {
                isNegative = true;
                v = -v;
            }

            int IValue = 1;
            for (int i = 1; i <= x; i++)
            {
                IValue = IValue * 10;
            }
            double Int = Math.Round(v * IValue + 0.5, 0);
            v = Int / IValue;

            if (isNegative)
            {
                v = -v;
            }

            return v;
        }
    }
}
