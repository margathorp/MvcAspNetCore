using System;
using System.Collections.Generic;
<%
    var fields = Fields.split("|");
    var nome = "";
    var tipo = "";
    var mask = "";
    var hidden = "";   
%>
namespace <%=Projeto%>.Models.ViewModel
{
    public class <%=ObjContext%>ViewModel
    {   public int Actions {get;set;}    
         <% for(var i = 0; i < fields.length; i++){ nome = fields[i].split(",")[0]; tipo = fields[i].split(",")[1]; mask = fields[i].split(",")[2];hidden = fields[i].split(",")[3];databasename = fields[i].split(",")[4];nometela = fields[i].split(",")[5];required = fields[i].split(",")[6];requiredtxt = fields[i].split(",")[7];%>%>
        public <%=tipo%> <%=nome%> {get;set;}
        <%}%>
    }
}