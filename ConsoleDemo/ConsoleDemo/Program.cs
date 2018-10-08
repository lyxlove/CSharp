using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Linq;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program1 = new Program();
            program1.StopWatchTime();
            Console.ReadKey();
            return;
            string XMLbuf = "<?xml version=\"1.0\" encoding=\"GBK\"?><Request Name=\"RESULT_ZYJS\"><Result><Row><JCLSH>P180726P91441310001-01</JCLSH><ZYJSJCCS>1</ZYJSJCCS><ZYJSJG1>0.01</ZYJSJG1><ZYJSJG2>0.01</ZYJSJG2><ZYJSJG3>0.01</ZYJSJG3><ZYJSPJZ>0.01</ZYJSPJZ><ZYJSXZ>2.50</ZYJSXZ><ZYJS_PD>1</ZYJS_PD><ZYJSYW>0.0</ZYJSYW><ZYJSDSZS>0</ZYJSDSZS><ZYJSWD>0.0</ZYJSWD><ZYJSDQY>0.0</ZYJSDQY><ZYJSSD>0.0</ZYJSSD><KSSJ>2018-07-26 14:53:26</KSSJ><JSSJ>2018-07-26 14:55:13</JSSJ><HPHM>陕EZS098</HPHM></Row></Result><VehicleInfo><Row><VEHICLEID>02陕EZS098</VEHICLEID><JCXH>1</JCXH><JCZT_STATUS>0</JCZT_STATUS><GW_STATUS>0</GW_STATUS><JCCS>1</JCCS><JCLSH>P180726P91441310001-01</JCLSH><JYXM>X4,</JYXM><HPHM>陕EZS098</HPHM><HPZL>小型汽车</HPZL><HPZLDH>02</HPZLDH><CLZLDH>H31</CLZLDH><VIN>LS1D221B8C0438100</VIN><JYLB>在用机动车检验</JYLB><JYLBDH>01,</JYLBDH><QDXS>后驱</QDXS><QZDZ>二</QZDZ><YGGSNFKT>否</YGGSNFKT><RLLB>柴油</RLLB><ZBZL>2515</ZBZL><BSXLX>手动</BSXLX><CLSXSJ>2018-07-26 14:53:22</CLSXSJ><DLY>高巧文</DLY><YCY>1243</YCY><WGJYY>2143</WGJYY><WQCZY>3214</WQCZY><GXRQ>2018-07-26 14:41:31</GXRQ><ZZS>2</ZZS><LWCXWZJL>无</LWCXWZJL><SFSQCLC>0</SFSQCLC><LWCXWZJLDH>A</LWCXWZJLDH><HDZH>1700</HDZH><AJLSH>1807051502020028</AJLSH><ZZL>4440</ZZL><CLSSLB>常规(汽车)</CLSSLB><CLSSLBDH>01</CLSSLBDH><JYXM_LW>B1,B2,B0,C1,H1,H4,Z1,Z2,F1,DC,</JYXM_LW><DLRQ>2018-07-26 14:41:31</DLRQ><FDJH>F1301C00008</FDJH><FDJXH>YC4F100-30</FDJXH><PP>南骏牌</PP><CLZZCS>中国四川南骏汽车有限公司</CLZZCS><XH>CNJ1040ZD33B6</XH><PPXH>南骏牌CNJ1040ZD33B6</PPXH><QDXSDH>202</QDXSDH><QDZWZ>2,</QDZWZ><ZCZWZ>2,</ZCZWZ><QZDZDH>2</QZDZDH><YGGSNFKTDH>0</YGGSNFKTDH><RLLBDH>B</RLLBDH><RYBH>0#</RYBH><GYFS>电喷</GYFS><GYFSDH>4</GYFSDH><CCDJRQ>2013-03-27</CCDJRQ><CCRQ>2012-02-01</CCRQ><CYS>3</CYS><CSYS>白</CSYS><CSYSDH>A</CSYSDH><CLZL>轻型普通货车</CLZL><ZXZXJXS>独立悬架</ZXZXJXS><ZXZXJXSDH>0</ZXZXJXSDH><ZXZLX>单</ZXZLX><ZXZLXDH>1</ZXZLXDH><ZGSJCS>140</ZGSJCS><EDGL>75</EDGL><EDZS>3200</EDZS><JQFS>自然吸气</JQFS><JQFSDH>1</JQFSDH><FDJPL>3298</FDJPL><FDJGS>4</FDJGS><BSXLXDH>1</BSXLXDH><LJXSLC>50000</LJXSLC><LTQY>330</LTQY><SYXZ>货运</SYXZ><SYXZDH>Y18</SYXZDH><SYR>张伟</SYR><LXDH>3215455</LXDH><LXDZ>陕西省大荔县城关镇新庄三组</LXDZ><CSC>5990</CSC><CSK>2000</CSK><CSG>2300</CSG><ZJ>3300</ZJ><CHZHQQK>无</CHZHQQK><CHZHQQKDH>0</CHZHQQKDH><PQHCLZZ>无</PQHCLZZ><PQHCLZZDH>3</PQHCLZZDH><DWS>6</DWS><DCZZ>1255</DCZZ><SYQK>在用车</SYQK><SYQKDH>01</SYQKDH><CPMC>南骏牌</CPMC><HPYS>蓝色</HPYS><HPYSDH>01</HPYSDH><SFMJ>2</SFMJ></Row></VehicleInfo><ProcessData><Row><时间s>0</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:00:00</全程时序></Row><Row><时间s>1</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:00:01</全程时序></Row><Row><时间s>2</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:00:03</全程时序></Row><Row><时间s>3</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:00:06</全程时序></Row><Row><时间s>4</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:00:10</全程时序></Row><Row><时间s>5</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:00:15</全程时序></Row><Row><时间s>6</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:00:21</全程时序></Row><Row><时间s>7</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:00:28</全程时序></Row><Row><时间s>8</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:00:36</全程时序></Row><Row><时间s>9</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:00:45</全程时序></Row><Row><时间s>10</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:00:55</全程时序></Row><Row><时间s>11</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:01:06</全程时序></Row><Row><时间s>12</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:01:18</全程时序></Row><Row><时间s>13</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:01:31</全程时序></Row><Row><时间s>14</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:01:45</全程时序></Row><Row><时间s>15</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:02:00</全程时序></Row><Row><时间s>16</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:02:16</全程时序></Row><Row><时间s>17</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:02:33</全程时序></Row><Row><时间s>18</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:02:51</全程时序></Row><Row><时间s>19</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:03:10</全程时序></Row><Row><时间s>20</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:03:30</全程时序></Row><Row><时间s>21</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:03:51</全程时序></Row><Row><时间s>22</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:04:13</全程时序></Row><Row><时间s>23</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:04:36</全程时序></Row><Row><时间s>24</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:05:00</全程时序></Row><Row><时间s>25</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:05:25</全程时序></Row><Row><时间s>26</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:05:51</全程时序></Row><Row><时间s>27</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:06:18</全程时序></Row><Row><时间s>28</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:06:46</全程时序></Row><Row><时间s>29</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:07:15</全程时序></Row><Row><时间s>30</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:07:45</全程时序></Row><Row><时间s>31</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:08:16</全程时序></Row><Row><时间s>32</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:08:48</全程时序></Row><Row><时间s>33</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:09:21</全程时序></Row><Row><时间s>34</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:09:55</全程时序></Row><Row><时间s>35</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:10:30</全程时序></Row><Row><时间s>36</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:11:06</全程时序></Row><Row><时间s>37</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:11:43</全程时序></Row><Row><时间s>38</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:12:21</全程时序></Row><Row><时间s>39</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:13:00</全程时序></Row><Row><时间s>40</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:13:40</全程时序></Row><Row><时间s>41</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:14:21</全程时序></Row><Row><时间s>42</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:15:03</全程时序></Row><Row><时间s>43</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:15:46</全程时序></Row><Row><时间s>44</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:16:30</全程时序></Row><Row><时间s>45</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:17:15</全程时序></Row><Row><时间s>46</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:18:01</全程时序></Row><Row><时间s>47</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:18:48</全程时序></Row><Row><时间s>48</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:19:36</全程时序></Row><Row><时间s>49</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:20:25</全程时序></Row><Row><时间s>50</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:21:15</全程时序></Row><Row><时间s>51</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:22:06</全程时序></Row><Row><时间s>52</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:22:58</全程时序></Row><Row><时间s>53</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:23:51</全程时序></Row><Row><时间s>54</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:24:45</全程时序></Row><Row><时间s>55</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:25:40</全程时序></Row><Row><时间s>56</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:26:36</全程时序></Row><Row><时间s>57</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:27:33</全程时序></Row><Row><时间s>58</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:28:31</全程时序></Row><Row><时间s>59</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:29:30</全程时序></Row><Row><时间s>60</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:30:30</全程时序></Row><Row><时间s>61</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:31:31</全程时序></Row><Row><时间s>62</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:32:33</全程时序></Row><Row><时间s>63</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:33:36</全程时序></Row><Row><时间s>64</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:34:40</全程时序></Row><Row><时间s>65</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:35:45</全程时序></Row><Row><时间s>66</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:36:51</全程时序></Row><Row><时间s>67</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:37:58</全程时序></Row><Row><时间s>68</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:39:06</全程时序></Row><Row><时间s>69</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:40:15</全程时序></Row><Row><时间s>70</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:41:25</全程时序></Row><Row><时间s>71</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:42:36</全程时序></Row><Row><时间s>72</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:43:48</全程时序></Row><Row><时间s>73</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:45:01</全程时序></Row><Row><时间s>74</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:46:15</全程时序></Row><Row><时间s>75</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:47:30</全程时序></Row><Row><时间s>76</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:48:46</全程时序></Row><Row><时间s>77</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:50:03</全程时序></Row><Row><时间s>78</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:51:21</全程时序></Row><Row><时间s>79</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:52:40</全程时序></Row><Row><时间s>80</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:54:00</全程时序></Row><Row><时间s>81</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:55:21</全程时序></Row><Row><时间s>82</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:56:43</全程时序></Row><Row><时间s>83</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:58:06</全程时序></Row><Row><时间s>84</时间s><转速>0</转速><烟度>0.01</烟度><温度>0.0</温度><大气压kPa>0.0</大气压kPa><湿度>0.0</湿度><全程时序>2018-07-26 01:59:30</全程时序></Row></ProcessData></Request>";

            XDocument xDocument = XDocument.Parse(XMLbuf);


            //var query = from ps in xDocument.Element("Request").Elements("ProcessData").Elements("Row")

            //            select ps;
            //List<string> list5 = new List<string>();

            //query.ToList().ForEach(item =>
            //{
            //    list5.Add(item.Element("全程时序").Value);
            //    //Console.WriteLine("{0}-{1}-{2}", item.Element("温度").Value, item.Element("转速").Value, item.Element("全程时序").Value);
            //});
            //IEnumerable<XElement> elements = from e in xDocument.Elements("Request")
            //                                 select e;

            //foreach (XElement e in elements)
            //{
            //    Console.WriteLine("{0}-{1}", e.Name, e.Value);
            //}
            // var list1 = xDocument.Descendants("Result").Select(t => new { time = t.Element("JCLSH").Value });

            //var list1 = from a in xDocument.Elements("Request").Elements("ProcessData").Elements("Row")
            //            select new
            //            {
            //                time = a.Element("转速").Value
            //            };
            List<object> list2 = new List<object>();
            //foreach (var item in list1)
            //{
            //    list2.Add(item.time);
            //}

            var list1 = from a in xDocument.Descendants("ProcessData").Elements("Row")
                        select new
                        {
                            time = a.Element("全程时序").Value
                        };
            foreach (var item in list1)
            {
                list2.Add(item.time);
            }
            //Console.ReadKey();
            return;
            //postHttpRequest("http://localhost:8080/yzslz/servlet/ServletDemo01", "value=测试");
            string line = "lane=1;speed=30.3mph;acceleration=2.5mph/s";
            line = "2018-07-12 06:37:41 ManualCold(ManualCOLI)              CXP9024418/6_R47A72                 18.Q3      103s (1m43s)    145s (2m25s)    ";
            string regx = @"speed\s*=\s*([\d\.]+)\s*(mph|km/h|m/s)*";
            regx = "\\)\\s+\\d+s\\s+\\(";
            Regex reg = new Regex(regx);
            Match match = reg.Match(line);
            //那么在返回的结果中match.Groups[1].Value将含有数值，而match.Groups[2].Value将含有单位。
            var 值 = match.Groups[1].Value;//此处方便演示，在实际开发中请勿使用中文命名变量
            var 单位 = match.Groups[2].Value;
            Console.WriteLine("speed的值为：{0} speed的单位是:{1}", 值, 单位);
            Console.ReadKey();
            return;
            Program p = new Program();
            p.ReZS(1);
            Console.ReadKey();
            return;
            int i = 91;
            Console.WriteLine(i.ToString("00000"));

            string s1 = "99";
            Console.WriteLine(s1.ToString().PadLeft(5, '0'));

            return;
            MatchCollection ms = Regex.Matches("±50mm或±1.0%", @"\d+\.?\d*");
            foreach (Match m in ms)
            {
                string svv = m.Value.ToString();
            }

            Program program = new Program();
            string strMD5 = program.MD5Encoding("admin");

            DateTime dateTime = DateTime.Now;


            List<int> list = new List<int>();


            ChildEntity entity = new ChildEntity();
            entity.One = "1";
            entity.Two = "2";
            entity.Three = "3";
            entity.Four = "4";
            entity.Five = "5";
            entity.Six = "6";





            ParentEntity entity1 = (ParentEntity)entity;


            ChildEntity entity2 = entity1 as ChildEntity;
            string s = entity2.Four;


            ParentEntity entity3 = new ChildEntity();


            Animal animal = new Dog();
            animal.call();


            Animal animal1 = new Animal();
            Dog dog = (Dog)animal;

           
        }

        class Animal
        {
            public void call() { Console.WriteLine("无声的叫唤"); }
        }

        class Dog : Animal
        {
            // new的作用是隐藏父类的同名方法  
            public new void call() { Console.WriteLine("叫声：汪～汪～汪～"); }
            public void smell() { Console.WriteLine("嗅觉相当不错！"); }
        }

        private string MD5Encoding(string pwd)
        {
            MD5 mD5 = MD5.Create();
            byte[] bs = Encoding.UTF8.GetBytes(pwd);
            byte[] hs = mD5.ComputeHash(bs);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte b in hs)
            {
                stringBuilder.Append(b.ToString("x2"));
            }
            return stringBuilder.ToString();
        }

        private void Ts()
        {
            MD5Encoding("1");
        }

        private void StopWatchTime()
        {
            Stopwatch stopwatch = new Stopwatch();
            
            Thread.Sleep(3000);
            stopwatch.Stop();
            Console.WriteLine($"执行时间：{stopwatch.Elapsed}");
            stopwatch.Start();
            Thread.Sleep(5000);
            stopwatch.Stop();
            Console.WriteLine($"执行时间：{stopwatch.Elapsed}");
        }

        public static void postHttpRequest(string url, string param)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; rv:19.0) Gecko/20100101 Firefox/19.0";
            string requestForm = param;
            byte[] postdatabyte = Encoding.UTF8.GetBytes(requestForm);
            request.ContentLength = postdatabyte.Length;
            request.AllowAutoRedirect = false;
            request.KeepAlive = true;
            Stream stream;
            stream = request.GetRequestStream();
            stream.Write(postdatabyte, 0, postdatabyte.Length);
            stream.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(responseStream, Encoding.UTF8);
            string str_serializer = streamReader.ReadToEnd();
            //JavaScriptSerializer _jsonobj = new JavaScriptSerializer();
            //PermanentBean _obj = _jsonobj.Deserialize<JsonObject>(str_serializer).obj;
            //Console.WriteLine(_obj.permanent_num);
            Console.WriteLine(str_serializer);
            Console.ReadKey();
        }

        private void ReZS(int i)
        {
            try
            {
                if (i >= 9999)
                {
                    return;
                }
                else
                {
                    if (i == 1)
                    {
                        Console.Write(i.ToString() + "\n");
                        ReZS(i + 1);
                        return;
                    }
                    else
                    {
                        for (int j = 2; j <= i; j++)
                        {
                            if (i % j == 0)
                            {
                                ReZS(i + 1);
                                return;
                            }
                            if (i == j + 1)
                            {
                                if (i < 7788)
                                {
                                    Console.Write(i.ToString() + "\n");
                                    ReZS(i + 1);
                                    return;
                                }
                                else
                                {
                                    Console.Write(i.ToString() + "\n");
                                }
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

    public class ParentEntity
    {
        public string One { get; set; }

        public string Two { get; set; }

        public string Three { get; set; }
    }

    public class ChildEntity : ParentEntity
    {
        public string Four { get; set; }
        public string Five { get; set; }
        public string Six { get; set; }
    }
}
