﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MESProject
{
    public partial class WorkLog : Form
    {
        public WorkLog()
        {
            InitializeComponent();
        }

        private void WorkLog_Load(object sender, EventArgs e)
        {
            // Grid 디자인 세팅
            Common.SetGridDesign(WLGrid);
            Common.SetGridDesign(LotGrid);
            WLGrid.Font = new Font("Fixsys", 12, FontStyle.Regular);

            //콤보박스 초기값설정
            string[] proc = { "배합", "사출" };
            ProcCombo.Items.AddRange(proc);
            ProcCombo.SelectedIndex = 0;

            // 컬럼명 설정
            DataSearch();
            if (WLGrid.Rows.Count > 0)
            {
                string[] header = new string[] { "작업코드", "제품명", "작업상태", "설비코드", "계획수량", "생산수량", "불량수량", "작업시작일", "작업완료일", "계획일자", "비고" };
                for (int i = 0; i < header.Length; i++)
                {
                    WLGrid.Columns[i].HeaderText = $"{header[i]}";

                }
            }
            // LotGrid 컬럼명
            string Selected_lot = $"SELECT L.LOTID, L.LOTSTDTTM, L.LOTEDDTTM, "+
                $"CASE WHEN L.LOTID IN(SELECT DEFECT_LOTID FROM DEFECTLOT "+
                $"WHERE WOID='{woid}') THEN 'Y' ELSE 'N' END FROM LOT L, DEFECTLOT D "+
                $"WHERE WOID = '{woid}' AND L.LOTID = D.DEFECT_LOTID";
            Common.DB_Connection(Selected_lot, LotGrid);

            if (LotGrid.Rows.Count > 0)
            {
                LotGrid.Columns[0].HeaderText = "LOT코드";
                LotGrid.Columns[1].HeaderText = "시작시간";
                LotGrid.Columns[2].HeaderText = "종료시간";
                LotGrid.Columns[3].HeaderText = "불량";
            }

        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataSearch()
        {

            DateTime date1 = dateTimePicker1.Value;
            DateTime date2 = dateTimePicker2.Value;

            if (ProcCombo.SelectedIndex == 0)
            {
                //배합 콤보박스 선택 PROCID='P0001'
                string select_wo_mix = $"SELECT W.WOID, P.PRODNAME, CASE W.WOSTAT WHEN 'P' THEN '대기' WHEN 'S' THEN '진행중' WHEN 'E' THEN '종료' END AS WOSTAT, " +
                                       $"E.EQPTID, W.PLANQTY,COUNT(*),COUNT(D.DEFECT_LOTID), W.WOSTDTTM, W.WOEDDTTM, W.PLANDTTM, W.ETC" +
                                       $" FROM WORKORDER W, PRODUCT P, EQUIPMENT E, LOT L, DEFECTLOT D " +
                                       $"WHERE W.PROCID = E.PROCID AND W.PROCID = 'P0001' AND plandttm >= '{date1.Year}/{date1.Month}/{date1.Day}' and  " +
                                       $"plandttm <= '{date2.Year}/{date2.Month}/{date2.Day}' AND W.WOID = L.WOID(+) AND W.PRODID = P.PRODID AND L.LOTID = D.DEFECT_LOTID(+) AND W.WOSTAT NOT IN (SELECT W.WOSTAT FROM WORKORDER W WHERE W.WOSTAT = 'P') " +
                                       $"GROUP BY W.WOID, P.PRODNAME, W.WOSTAT, W.PLANQTY, E.EQPTID, W.PRODQTY, W.WOSTDTTM, W.WOEDDTTM, W.PLANDTTM, W.ETC";
                Common.DB_Connection(select_wo_mix, WLGrid);
                WLGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            else if (ProcCombo.SelectedIndex == 1)
            {
                //사출 콤보박스 선택 PROCID='P0002'
                string select_wo_injection = $"SELECT W.WOID, P.PRODNAME, CASE W.WOSTAT WHEN 'P' THEN '대기' WHEN 'S' THEN '진행중' WHEN 'E' THEN '종료' END, " +
                                             $"E.EQPTID, W.PLANQTY, COUNT(*),COUNT(D.DEFECT_LOTID), W.WOSTDTTM, W.WOEDDTTM, W.PLANDTTM, W.ETC " +
                                             $"FROM WORKORDER W, PRODUCT P, EQUIPMENT E, LOT L, DEFECTLOT D WHERE W.PROCID = E.PROCID AND " +
                                             $"W.PROCID = 'P0002' AND plandttm >= '{date1.Year}/{date1.Month}/{date1.Day}' and  plandttm <= '{date2.Year}/{date2.Month}/{date2.Day}' " +
                                             $"AND W.WOID = L.WOID(+) AND W.PRODID = P.PRODID AND L.LOTID = D.DEFECT_LOTID(+) AND W.WOSTAT NOT IN (SELECT W.WOSTAT FROM WORKORDER W WHERE W.WOSTAT = 'P')" +
                                             $"GROUP BY W.WOID, P.PRODNAME, W.WOSTAT, W.PLANQTY, E.EQPTID, W.PRODQTY, W.WOSTDTTM, W.WOEDDTTM, W.PLANDTTM, W.ETC";
                Common.DB_Connection(select_wo_injection, WLGrid);
                WLGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
        }

        private void InquiryBtn_Click(object sender, EventArgs e)
        {
            //조회버튼
            DataSearch();
            SetRowColor();
        }

        public string woid;

        private void WLGrid_MouseClick(object sender, MouseEventArgs e)
        {
            //WLGrid 선택했을때 LotGrid에 표시될 데이터값
            for (int i = 0; i < WLGrid.Rows.Count-1; i++)
            {

                if (WLGrid.Rows[i].Selected == true)
                {               
                    woid = WLGrid.Rows[i].Cells[0].Value.ToString();
                    string Selected_lot =   $"SELECT L.LOTID, L.LOTSTDTTM, L.LOTEDDTTM,"+
                                            $"CASE WHEN L.LOTID IN(SELECT DEFECT_LOTID FROM DEFECTLOT WHERE WOID='{woid}') THEN 'Y' ELSE 'N' END "+
                                            $"FROM LOT L, DEFECTLOT D "+
                                            $"WHERE WOID = '{woid}' AND L.LOTID = D.DEFECT_LOTID";

                    Common.DB_Connection(Selected_lot, LotGrid);
                    LotGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            if (LotGrid.Rows.Count > 0)
            {
                LotGrid.Columns[0].HeaderText = "LOT코드";
                LotGrid.Columns[1].HeaderText = "시작시간";
                LotGrid.Columns[2].HeaderText = "종료시간";
                LotGrid.Columns[3].HeaderText = "불량";
            }
        }
        public void SetRowColor()
        {
            for (int i = 0; i < WLGrid.Rows.Count - 1; i++)
            {
                if (WLGrid.Rows[i].Displayed)
                {
                    if (WLGrid.Columns.Contains("WOSTAT"))
                    {
                        if (WLGrid.Rows[i].Cells["WOSTAT"].Value.ToString().Contains("진행중"))
                        {
                            WLGrid.FirstDisplayedCell = WLGrid.Rows[i].Cells[0];
                            WLGrid.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;

                        }
                    }
                }
            }
        }

        private void WLGrid_DataSourceChanged(object sender, EventArgs e)
        {
            WLGrid.AutoResizeColumns(
                DataGridViewAutoSizeColumnsMode.AllCells);
        }
    }
}
