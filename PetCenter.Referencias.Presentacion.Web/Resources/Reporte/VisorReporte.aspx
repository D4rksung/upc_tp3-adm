<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisorReporte.aspx.cs" Inherits="PetCenter.Referencias.Presentacion.Web.Resources.Reporte.VisorReporte" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <%--<link href="../Sitio/css/sitio.reporte.css" rel="stylesheet" type="text/css">--%>
</head>

<body>

   <%-- <form id="frm_VisorReporte" runat="server">
        <% if (!ConError)
           {%>
        <asp:ScriptManager ID="AjaxScriptManager" AsyncPostBackTimeout="0" runat="server" />
        <div>
            <rsweb:ReportViewer ID="Rpt_View" runat="server" Font-Names="Verdana"
                Font-Size="8pt" WaitMessageFont-Names="Verdana"
                WaitMessageFont-Size="12pt" Height="100%" Width="100%" ProcessingMode="Remote" CssClass="asistencia-reportview" ShowParameterPrompts="False" />
            <br />
        </div>
        <% }
           else
           {%>
        <div style="color: red">
            <a onclick="history.go(-1); return false;" class="back" title="Regresar">&lt;=Regresar</a>
            <h2 class="hh2">Se ha producido un error en el sistema, por favor inténtelo más tarde</h2>
            <%= MensajeError %>
        </div>
        <% } %>
    </form>--%>

</body>
</html>

