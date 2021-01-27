using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ctrl_Dll;

namespace CSV_Read_Html
{
    //=================================
    public struct _DirVal
    {
        public string DeskTop;
        public string Document;
        public string AppDir;
    }
    //=================================


    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        cls_FileCtrl clsFC = new cls_FileCtrl();
        cls_TextCtrl clsTC = new cls_TextCtrl();
        _DirVal dirVal = new _DirVal();

        string strNL = "\r\n";

        //******************************************************************************
        public MainWindow()
        {
            InitializeComponent();
            setDir();
        }


        //******************************************************************************
        void setDir()
        {
            dirVal.AppDir = clsFC.App_Directory_Acquisition();
            dirVal.DeskTop = clsFC.Desk_Top_Directory();
            dirVal.Document = clsFC.Mydocument_Directory();
        }


        //******************************************************************************
        private void Click_BTN_FileRead(object sender, RoutedEventArgs e)
        {
            TXB_FileName.Text = clsFC.File_Read_Dialog_CSV(dirVal.AppDir);
        }

        //******************************************************************************
        private void Click_BTN_Run(object sender, RoutedEventArgs e)
        {
            //string strBuf = clsFC.Txt_File_Read(TXB_FileName.Text);
            //string[] strVal = new string[clsTC.mCountChar(strBuf, (char)0x0A)];

            //strBuf = strBuf.Replace("\r", "");
            //strVal = strBuf.Split((char)0x0A);



            clsFC.mTextFileSave(SetHtml(), ref dirVal.DeskTop, false);
        }


        //******************************************************************************
        string SetHtml()
        {
            string strRtn = "";


            strRtn = "<html>" + strNL +
                        "<head>" + strNL +
                            "<meta charset = \"UTF-8\"/>" + strNL +
                            "<title> ページタイトル </title>" + strNL +
                            "<script src = \"https://code.highcharts.com/highcharts.js \"></script>" + strNL +
                        "</head>" + strNL +
                        "<body>" + strNL +
                            "<div id = \"container0\" style = \"width: 680px; height: 550px; margin: 0 auto\"></div>" + strNL +
                            "<script language = \"JavaScript\">" + strNL +
                            "window.onload = function() {" + strNL +
                            "Highcharts.chart('container0', {" + strNL +
                            // グラフ属性設定
                            // 各属性の詳細：https://api.highcharts.com/highcharts/
                            "title:{" + strNL +
                            "text: 'グラフタイトル'" + strNL +
                            "}," + strNL +
                            "xAxis:{" + strNL +
                            "title: { text: '横軸タイトル'}," + strNL +
                            "categories:['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12']" + strNL +
                            "}," + strNL +
                            "yAxis:{" + strNL +
                            "title: { text: '縦軸タイトル'}," + strNL +
                            "plotLines:[{" + strNL +
                                "value: 0," + strNL +
                                "width: 1," + strNL +
                                "color: '#808080'" + strNL +
                            "}]" + strNL +
                            "}," + strNL +
                            "tooltip:{" + strNL +
                                "valueSuffix: '(mA)単位'" + strNL +
                            "}," + strNL +
                            "legend:{" + strNL +
                                "layout: 'vertical'," + strNL +
                                "align: 'right'," + strNL +
                                "verticalAlign: 'middle'," + strNL +
                                "borderWidth: 0" + strNL +
                            "}," + strNL +
                            "series:[{" + strNL +
                                "name: 'チャートA'," + strNL +
                                    "data:[23.5, 32.2, 45.6, 20.3, 15.3, 56.4, 49.9, 53.5, 55.5, 33.2, 46.3, -15]" + strNL +
                                "}," + strNL +
                                "{" + strNL +
                                "name: 'チャートB'," + strNL +
                                    "data:[15.3, 18.2, 25.7, 23.1, 26.9, 27.4, 30.5, 38.6, 40.2, 48.3, 35.2, 25.4]" + strNL +
                                "}, " + strNL +
                                "{" + strNL +
                                "name: 'チャートC'," + strNL +
                                    "data:[18.5, 22.5, 29.3, 37.1, 39.3, 45.8, 44.3, 48.2, 43.6, 40.3, 37.7, 33.0]" + strNL +
                                "}," + strNL +
                                "{" + strNL +
                                "name: 'チャートD'," + strNL +
                                    "data:[7.2, 6.3, 8.9, 10.2, 12.5, 16.2, 18.2, 17.3, 16.5, 12.8, 10.3, 13.9]" + strNL +
                                "}," + strNL +
                                "{" + strNL +
                                "name: 'チャートE'," + strNL +
                                    "data:[36.6, 37.2, 39.1, 30.2, 30.9, 28.3, 25.3, 24.8, 23.3, 20.7, 18.3, 19.7]" + strNL +
                                "}" + strNL +
                            "]," + strNL +


                            "responsive:{" + strNL +
                                "rules:[{" + strNL +
                                    "condition:{" + strNL +
                                       "maxWidth: 600" + strNL +
                                    "}," + strNL +
                                    "chartOptions:{" + strNL +
                                        "legend:{" + strNL +
                                            "layout: 'horizontal'," + strNL +
                                            "align: 'center'," + strNL +
                                            "verticalAlign: 'top'" + strNL +
                                        "}" + strNL +
                                        "}" + strNL +
                                   "}]" + strNL +
                            "}" + strNL +
                            "});" + strNL +

                        "}" + strNL +
                        "</script>" + strNL +
                    "</body>" + strNL +
                "</html> ";


            return strRtn;
        }
    }
}
