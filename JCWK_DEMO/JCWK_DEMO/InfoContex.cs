using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JCWK_DEMO
{
    public class InfoContex
    {
        private VEHICLE_DISPATCH m_VEHICLE_DISPATCH = null;
        private LOGIN_VEHICLE_INFO m_LOGIN_VEHICLE_INFO = null;
        public InfoContex(string strJCLSH)
        {
            DbHelper dbHelper = new DbHelper(@"JCX-server\localdb", "sa", "", "IVS_NEW");
            m_VEHICLE_DISPATCH = dbHelper.Query<VEHICLE_DISPATCH>(SqlHelper<VEHICLE_DISPATCH>.GetSearchSql(strJCLSH));
            string strSql = $"{SqlHelper<LOGIN_VEHICLE_INFO>.GetSearchSql()} WHERE VEHICLEID = '{m_VEHICLE_DISPATCH.VEHICLEID}'";
            m_LOGIN_VEHICLE_INFO = dbHelper.Query<LOGIN_VEHICLE_INFO>(strSql);
        }

        public string GetStr()
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"[检测信息]");
            //sb.AppendLine($"检验流水号={m_VEHICLE_DISPATCH.AJLSH}");
            //sb.AppendLine($"车牌号码={m_VEHICLE_DISPATCH.HPHM}");
            //sb.AppendLine($"号牌种类={m_LOGIN_VEHICLE_INFO.HPZL}");
            //sb.AppendLine($"车辆类型={m_LOGIN_VEHICLE_INFO.CLZL}");
            //sb.AppendLine($"车身颜色={m_LOGIN_VEHICLE_INFO.CSYS}");
            //sb.AppendLine($"是否外廓尺寸=是");
            //sb.AppendLine($"是否整备质量=否");
            //sb.AppendLine($"车主单位=");
            //sb.AppendLine($"引车员=程恒政");
            //sb.AppendLine($"底盘类型=");
            //sb.AppendLine($"底盘号码={m_LOGIN_VEHICLE_INFO.VIN}");
            //sb.AppendLine($"发动机号={m_LOGIN_VEHICLE_INFO.FDJH}");
            //sb.AppendLine($"发动机型号={m_LOGIN_VEHICLE_INFO.FDJXH}");
            //sb.AppendLine($"厂牌型号={m_LOGIN_VEHICLE_INFO.CPMC}");
            //sb.AppendLine($"最高设计车速=");
            //sb.AppendLine($"最大设计总质量={m_LOGIN_VEHICLE_INFO.ZZL}");
            //sb.AppendLine($"是否新车=否");
            //sb.AppendLine($"出厂日期={m_LOGIN_VEHICLE_INFO.CCRQ}");
            //sb.AppendLine($"检测类型={m_VEHICLE_DISPATCH.JYLB}");
            //sb.AppendLine($"检测线号=1");
            //sb.AppendLine($"检测次数={m_VEHICLE_DISPATCH.JCCS}");
            //sb.AppendLine($"车轴数={m_LOGIN_VEHICLE_INFO.ZZS}");
            //sb.AppendLine($"出厂长={m_LOGIN_VEHICLE_INFO.CSC}");
            //sb.AppendLine($"出厂宽={m_LOGIN_VEHICLE_INFO.CSK}");
            //sb.AppendLine($"出厂高={m_LOGIN_VEHICLE_INFO.CSG}");
            //sb.AppendLine($"出厂重量={m_LOGIN_VEHICLE_INFO.ZZL}");
            //sb.AppendLine($"总质量={m_LOGIN_VEHICLE_INFO.ZZL}");
            //sb.AppendLine($"整备质量={m_LOGIN_VEHICLE_INFO.ZBZL}");
            //sb.AppendLine($"栏板高度=");
            //sb.AppendLine($"挂车出厂长=");
            //sb.AppendLine($"挂车出厂宽=");
            //sb.AppendLine($"挂车出厂高=");
            //sb.AppendLine($"货箱出厂长=");
            //sb.AppendLine($"货箱出厂宽=");
            //sb.AppendLine($"货箱出厂高=");
            //sb.AppendLine($"一二轴轴距={m_LOGIN_VEHICLE_INFO.ZJ}");
            //sb.AppendLine($"二三轴轴距=0");
            //sb.AppendLine($"三四轴轴距=0");
            //sb.AppendLine($"四五轴轴距=0");
            

            sb.AppendLine($"检验流水号={m_VEHICLE_DISPATCH.AJLSH}");
            sb.AppendLine($"车牌号码={m_VEHICLE_DISPATCH.HPHM.Replace("挂", "")}");
            sb.AppendLine($"号牌种类={m_VEHICLE_DISPATCH.HPZL}");
            sb.AppendLine($"车辆类型={m_LOGIN_VEHICLE_INFO.CLZL}");
            sb.AppendLine($"车身颜色={m_LOGIN_VEHICLE_INFO.CSYS}");
            sb.AppendLine($"车主单位=");
            sb.AppendLine($"底盘类型=");
            sb.AppendLine($"底盘号码={m_VEHICLE_DISPATCH.VIN}");
            sb.AppendLine($"发动机号=");
            sb.AppendLine($"发动机型号=");
            sb.AppendLine($"厂牌型号={m_LOGIN_VEHICLE_INFO.PPXH}");
            sb.AppendLine($"最高设计车速=");
            sb.AppendLine($"最大设计总质量=");
            sb.AppendLine($"是否新车=否");
            sb.AppendLine($"出厂日期={m_LOGIN_VEHICLE_INFO.CCRQ}");
            sb.AppendLine($"检测类型={m_VEHICLE_DISPATCH.JYLB}");
            sb.AppendLine($"是否检测外廓尺寸=是");
            sb.AppendLine($"是否检测整备质量=否");
            sb.AppendLine($"检测线号=1");
            sb.AppendLine($"检测次数={m_VEHICLE_DISPATCH.JCCS}");
            sb.AppendLine($"车轴数={m_LOGIN_VEHICLE_INFO.ZZS}");
            sb.AppendLine($"出厂长={m_LOGIN_VEHICLE_INFO.CSC}");
            sb.AppendLine($"出厂宽={m_LOGIN_VEHICLE_INFO.CSK}");
            sb.AppendLine($"出厂高={m_LOGIN_VEHICLE_INFO.CSG}");
            sb.AppendLine($"出厂重量=");
            sb.AppendLine($"栏板高度=");
            sb.AppendLine($"挂车出厂长=");
            sb.AppendLine($"挂车出厂宽=");
            sb.AppendLine($"挂车出厂高=");
            sb.AppendLine($"货箱出厂长=");
            sb.AppendLine($"货箱出厂宽=");
            sb.AppendLine($"货箱出厂高=");
            sb.AppendLine($"一二轴轴距={(string.IsNullOrEmpty(m_LOGIN_VEHICLE_INFO.ZJ) ? "0" : m_LOGIN_VEHICLE_INFO.ZJ)}");
            sb.AppendLine($"二三轴轴距=0");
            sb.AppendLine($"三四轴轴距=0");
            sb.AppendLine($"四五轴轴距=0");
            sb.AppendLine($"检验员=");
            sb.AppendLine($"引车员=");
            return sb.ToString();
        }
    }
}
