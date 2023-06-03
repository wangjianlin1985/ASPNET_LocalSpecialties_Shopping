﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class MyOrder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null)
        {
            Response.Write("<script>alert('请先登录!');top.location.href='index.aspx';</script>");
            return;
        }
        if (!IsPostBack)
        {
            BindOrderState();
            string sqlstr = " where 1=1 ";
            if (Request["orderNo"] != null && Request["orderNo"].ToString() != "")
            {
                sqlstr += "  and orderNo like '%" + Request["orderNo"].ToString() + "%'";
                orderNo.Text = Request["orderNo"].ToString();
            }
            
            if (Request["orderState"] != null && Request["orderState"].ToString() != "0")
            {
                sqlstr += "  and orderState=" + Request["orderState"].ToString();
                orderState.SelectedValue = Request["orderState"].ToString();
            }
           
            sqlstr += "  and username like '%" + Session["username"].ToString() + "%'";
             

            HWhere.Value = sqlstr;
            BindData("");
        }
    }
    private void BindOrderState()
    {
        orderState.DataSource = BLL.bllOrderState.getAllOrderState();
        orderState.DataTextField = "stateName";
        orderState.DataValueField = "stateId";
        orderState.DataBind();
        ListItem li = new ListItem("=请选择=", "0");
        orderState.Items.Add(li);
        orderState.SelectedValue = "0";
    }

    
 

    private void BindData(string strClass)
    {
        int DataCount = 0;
        int NowPage = 1;
        int AllPage = 0;
        int PageSize = Convert.ToInt32(HPageSize.Value);
        switch (strClass)
        {
            case "next":
                NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                break;
            case "up":
                NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                break;
            case "end":
                NowPage = Convert.ToInt32(HAllPage.Value);
                break;
            default:
                break;
        }
        DataTable dsLog = BLL.bllOrderInfo.GetOrderInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
        if (dsLog.Rows.Count == 0 || AllPage == 1)
        {
            LBEnd.Enabled = false;
            LBHome.Enabled = false;
            LBNext.Enabled = false;
            LBUp.Enabled = false;
        }
        else if (NowPage == 1)
        {
            LBHome.Enabled = false;
            LBUp.Enabled = false;
            LBNext.Enabled = true;
            LBEnd.Enabled = true;
        }
        else if (NowPage == AllPage)
        {
            LBHome.Enabled = true;
            LBUp.Enabled = true;
            LBNext.Enabled = false;
            LBEnd.Enabled = false;
        }
        else
        {
            LBEnd.Enabled = true;
            LBHome.Enabled = true;
            LBNext.Enabled = true;
            LBUp.Enabled = true;
        }
        RpOrderInfo.DataSource = dsLog;
        RpOrderInfo.DataBind();
        PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
        HNowPage.Value = Convert.ToString(NowPage++);
        HAllPage.Value = AllPage.ToString();
    }

    protected void LBHome_Click(object sender, EventArgs e)
    {
        BindData("");
    }
    protected void LBUp_Click(object sender, EventArgs e)
    {
        BindData("up");
    }
    protected void LBNext_Click(object sender, EventArgs e)
    {
        BindData("next");
    }
    protected void LBEnd_Click(object sender, EventArgs e)
    {
        BindData("end");
    }
    

    public string GetOrderStateorderState(string orderState)
    {
        return BLL.bllOrderState.getSomeOrderState(int.Parse(orderState)).stateName;
    }

    public string GetPayWaypayWay(string payWay)
    {
        return BLL.bllPayWay.getSomePayWay(int.Parse(payWay)).payWayName;
    }

    public string GetTransportWaytrasportWay(string trasportWay)
    {
        return BLL.bllTransportWay.getSomeTransportWay(int.Parse(trasportWay)).transportName;
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("M_OrderInfoList.aspx?orderNo=" + orderNo.Text.Trim() + "&&orderState=" + orderState.SelectedValue.Trim() );
    }
}
